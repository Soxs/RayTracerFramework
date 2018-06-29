// [header]
// A very basic raytracer example.
// [/header]
// [compile]
// c++ -o raytracer -O3 -Wall raytracer.cpp
// [/compile]
// [ignore]
// Copyright (C) 2012  www.scratchapixel.com
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// [/ignore]
#include <stdlib.h>
#include <cstdio>
#include <cmath>
#include <fstream>
#include <vector>
#include <iostream>
#include <cassert>
// Windows only
#include <algorithm>
#include <sstream>
#include <string.h>

//timer stuff
#include <chrono>
#include <ctime>

#include "main.h"
#include "Heap.h"
#include "Vec3.h"
#include "Sphere.h"
#include "MemoryPool.h"

#include "TinyXML\tinyxml.h"

#include <thread>


#define STARTMARKER 0xDEADC0DE
#define ENDMARKER 0xDEADBEEF

int m_Frames;
std::vector<Sphere> m_Spheres;
unsigned m_Width = 640, m_Height = 480;
bool m_UseThreading = true;
Vec3 m_CameraPosition = Vec3(0);
bool m_UseNotionofTime = true;

struct AllocHeader
{
	int iSignature;
	int iSize;
	Heap * pHeap;
	AllocHeader * pNext;
	AllocHeader * pPrev;
};

AllocHeader * firstHeader = nullptr;
AllocHeader * previousHeader = nullptr;

Heap * defaultHeap;
MemoryPool * memoryPool = nullptr;

void * operator new (size_t size, Heap * pHeap) {
	size_t iRequestedBytes = size + sizeof(AllocHeader) + sizeof(int);

	//if (memoryPool != nullptr)
	//	memoryPool->allocate((int) size);

	char * pMem = (char *)malloc(iRequestedBytes);
	AllocHeader * pHeader = (AllocHeader *)pMem;
	pHeader->iSignature = STARTMARKER;
	pHeader->pHeap = pHeap;
	pHeader->iSize = size;
	if (previousHeader != nullptr) {
		pHeader->pPrev = previousHeader;
		previousHeader->pNext = pHeader;
	}
	previousHeader = pHeader;

	if (firstHeader == nullptr)
		firstHeader = pHeader;

	void * pStartMemBlock = pMem + sizeof(AllocHeader);
	int* pEndMarker = (int*)((char *)pStartMemBlock + size);
	*pEndMarker = ENDMARKER;
	pHeap->AddAllocation(size);
	return pStartMemBlock;
}

void * operator new (size_t size) {
	if (defaultHeap == nullptr) {
		defaultHeap = Heap::CreateNewHeap("Default Heap");
	}
	return ::operator new(size, defaultHeap);
}

void operator delete (void * pMem) {
	AllocHeader * pHeader = (AllocHeader *)((char *)pMem - sizeof(AllocHeader));
	assert(pHeader->iSignature == STARTMARKER);
	int * pEndMarker = (int*)((char*)pMem + pHeader->iSize);
	assert(*pEndMarker == ENDMARKER);
	pHeader->pHeap->RemoveAllocation(pHeader->iSize);

	free(pHeader);
}

#if defined __linux__ || defined __APPLE__
// "Compiled for Linux
#else
// Windows doesn't define these values by default, Linux does
#define M_PI 3.141592653589793
#define INFINITY 1e8
#endif


//[comment]
// This variable controls the maximum recursion depth
//[/comment]
#define MAX_RAY_DEPTH 5

float mix(const float &a, const float &b, const float &mix)
{
	return b * mix + a * (1 - mix);
}


//[comment]
// This is the main trace function. It takes a ray as argument (defined by its origin
// and direction). We test if this ray intersects any of the geometry in the scene.
// If the ray intersects an object, we compute the intersection point, the normal
// at the intersection point, and shade this point using this information.
// Shading depends on the surface property (is it transparent, reflective, diffuse).
// The function returns a color for the ray. If the ray intersects an object that
// is the color of the object at the intersection point, otherwise it returns
// the background color.
//[/comment]
Vec3f trace(const Vec3f &rayorig, const Vec3f &raydir, const std::vector<Sphere> &spheres, const int &depth)
{
	//if (raydir.length() != 1) std::cerr << "Error " << raydir << std::endl;
	float tnear = INFINITY;
	const Sphere* sphere = NULL;
	// find intersection of this ray with the sphere in the scene
	for (unsigned i = 0; i < spheres.size(); ++i) {
		float t0 = INFINITY, t1 = INFINITY;
		if (spheres[i].intersect(rayorig, raydir, t0, t1)) {
			if (t0 < 0) t0 = t1;
			if (t0 < tnear) {
				tnear = t0;
				sphere = &spheres[i];
			}
		}
	}
	// if there's no intersection return black or background color
	if (!sphere) return Vec3f(2);
	Vec3f surfaceColor = 0; // color of the ray/surfaceof the object intersected by the ray
	Vec3f phit = rayorig + raydir * tnear; // point of intersection
	Vec3f nhit = phit - sphere->center; // normal at the intersection point
	nhit.normalize(); // normalize normal direction
					  // If the normal and the view direction are not opposite to each other
					  // reverse the normal direction. That also means we are inside the sphere so set
					  // the inside bool to true. Finally reverse the sign of IdotN which we want
					  // positive.
	float bias = 1e-4; // add some bias to the point from which we will be tracing
	bool inside = false;
	if (raydir.dot(nhit) > 0) nhit = -nhit, inside = true;
	if ((sphere->transparency > 0 || sphere->reflection > 0) && depth < MAX_RAY_DEPTH) {
		float facingratio = -raydir.dot(nhit);
		// change the mix value to tweak the effect
		float fresneleffect = mix(pow(1 - facingratio, 3), 1, 0.1);
		// compute reflection direction (not need to normalize because all vectors
		// are already normalized)
		Vec3f refldir = raydir - nhit * 2 * raydir.dot(nhit);
		refldir.normalize();
		Vec3f reflection = trace(phit + nhit * bias, refldir, spheres, depth + 1);
		Vec3f refraction = 0;
		// if the sphere is also transparent compute refraction ray (transmission)
		if (sphere->transparency) {
			float ior = 1.1, eta = (inside) ? ior : 1 / ior; // are we inside or outside the surface?
			float cosi = -nhit.dot(raydir);
			float k = 1 - eta * eta * (1 - cosi * cosi);
			Vec3f refrdir = raydir * eta + nhit * (eta *  cosi - sqrt(k));
			refrdir.normalize();
			refraction = trace(phit - nhit * bias, refrdir, spheres, depth + 1);
		}
		// the result is a mix of reflection and refraction (if the sphere is transparent)
		surfaceColor = (
			reflection * fresneleffect +
			refraction * (1 - fresneleffect) * sphere->transparency) * sphere->surfaceColor;
	}
	else {
		// it's a diffuse object, no need to raytrace any further
		for (unsigned i = 0; i < spheres.size(); ++i) {
			if (spheres[i].emissionColor.x > 0) {
				// this is a light
				Vec3f transmission = 1;
				Vec3f lightDirection = spheres[i].center - phit;
				lightDirection.normalize();
				for (unsigned j = 0; j < spheres.size(); ++j) {
					if (i != j) {
						float t0, t1;
						if (spheres[j].intersect(phit + nhit * bias, lightDirection, t0, t1)) {
							transmission = 0;
							break;
						}
					}
				}
				surfaceColor += sphere->surfaceColor * transmission *
					std::max(float(0), nhit.dot(lightDirection)) * spheres[i].emissionColor;
			}
		}
	}

	return surfaceColor + sphere->emissionColor;
}

////[comment]
//// Main rendering function. We compute a camera ray for each pixel of the image
//// trace it and return a color. If the ray hits a sphere, we return the color of the
//// sphere at the intersection point, else we return the background color.
////[/comment]
//void render(const std::vector<Sphere> &spheres, int iteration)
//{
//	auto start = std::chrono::high_resolution_clock::now();
//
//	// Recommended Testing Resolution
//	//unsigned width = 640, height = 480;
//
//	// Recommended Production Resolution
//	//unsigned width = 1920, height = 1080;
//
//	Vec3f *image = new Vec3f[m_Width * m_Height], *pixel = image;
//	float invWidth = 1 / float(m_Width), invHeight = 1 / float(m_Height);
//	float fov = 30, aspectratio = m_Width / float(m_Height);
//	float angle = tan(M_PI * 0.5 * fov / 180.);
//	// Trace rays
//	for (unsigned y = 0; y < m_Height; ++y) {
//		for (unsigned x = 0; x < m_Width; ++x, ++pixel) {
//			float xx = (2 * ((x + 0.5) * invWidth) - 1) * angle * aspectratio;
//			float yy = (1 - 2 * ((y + 0.5) * invHeight)) * angle;
//			Vec3f raydir(xx, yy, -1);
//			raydir.normalize();
//			*pixel = trace(Vec3f(0), raydir, spheres, 0);
//		}
//	}
//	// Save result to a PPM image (keep these flags if you compile under Windows)
//	std::stringstream ss;
//	ss << "./output/spheres" << iteration << ".ppm";
//	std::string tempString = ss.str();
//	char* filename = (char*)tempString.c_str();
//
//	std::ofstream ofs(filename, std::ios::out | std::ios::binary);
//	ofs << "P6\n" << m_Width << " " << m_Height << "\n255\n";
//	for (unsigned i = 0; i < m_Width * m_Height; ++i) {
//		ofs << (unsigned char)(std::min(float(1), image[i].x) * 255) <<
//			(unsigned char)(std::min(float(1), image[i].y) * 255) <<
//			(unsigned char)(std::min(float(1), image[i].z) * 255);
//	}
//	ofs.close();
//	delete[] image;
//
//	auto end = std::chrono::high_resolution_clock::now();
//	auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count();
//
//	std::cout << "[Chrono Timer] Render took " << duration << "ms to execute." << std::endl;
//}

float invWidth = 0, invHeight = 0, fov = 30, aspectratio = 0, angle = 0;
size_t threads = 0;
int threadCount = 0;
int pPerThread = 0;

std::ofstream outputWriterRay;
std::ofstream outputWriterPPM;

void threadRender(const std::vector<Sphere> &spheres, int start, int end, Vec3 *pixel)
{
	auto starttime = std::chrono::high_resolution_clock::now();
	for (unsigned y = 0; y < m_Height; ++y) {
		for (unsigned x = 0; x < m_Width; ++x, ++pixel) {
			float xx = (2 * ((x + 0.5) * invWidth) - 1) * angle * aspectratio;
			float yy = (1 - 2 * ((y + 0.5) * invHeight)) * angle;

			Vec3f raydir(xx, yy, -1);
			raydir.normalize();

			*pixel = trace(m_CameraPosition, raydir, spheres, 0);
		}
	}
	
	auto endtime = std::chrono::high_resolution_clock::now();
	auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(endtime - starttime).count();

	std::cout << "[Chrono Timer]> Thread Render took " << duration << "ms to execute." << std::endl;
	outputWriterRay << "Duration: " << duration << std::endl;
}

void renderWithThreading(const std::vector<Sphere> &spheres, int iteration, bool threading)
{
	std::vector<std::thread> threadArray;

	auto starttime = std::chrono::high_resolution_clock::now();


	Vec3f *image = new Vec3f[m_Width * m_Height], *pixel = image;

	if (threading) {
		// Trace rays
		for (int i = 0; i < threadCount; i++)
		{
			int pixelBegin = (m_Height / threads) * i;
			int pixelEnd = (m_Height / threads) * (i + 1);

			threadArray.push_back(std::thread(&threadRender, spheres, pixelBegin, pixelEnd, pixel));
		}

		for (int i = 0; i < threadCount; i++)
		{
			threadArray.at(i).join();
		}
	}
	else {
		for (unsigned y = 0; y < m_Height; ++y)
		{
			for (unsigned x = 0; x < m_Width; ++x, ++pixel)
			{
				float xx = (2 * ((x + 0.5) * invWidth) - 1) * angle * aspectratio;
				float yy = (1 - 2 * ((y + 0.5) * invHeight)) * angle;

				Vec3f raydir(xx, yy, -1);
				raydir.normalize();

				*pixel = trace(m_CameraPosition, raydir, spheres, 0);
			}
		}
	}

	// Save result to a PPM image (keep these flags if you compile under Windows)
	/*std::stringstream ss;
	ss << "./output/spheres" << iteration << ".ppm";
	std::string tempString = ss.str();
	char* filename = (char*)tempString.c_str();

	std::ofstream ofs(filename, std::ios::out | std::ios::binary);

	ofs << "P6\n" << m_Width << " " << m_Height << "\n255\n";

	for (unsigned i = 0; i < (m_Width * m_Height); ++i)
	{

		ofs << (unsigned char)(std::min(float(1), image[i].x) * 255) <<

			(unsigned char)(std::min(float(1), image[i].y) * 255) <<

			(unsigned char)(std::min(float(1), image[i].z) * 255);
	}
	ofs.close();

	delete[] image;*/
	
	std::stringstream ss;
	ss << "./output/spheres" << iteration << ".ppm";
	std::string tempString = ss.str();
	char* filename = (char*)tempString.c_str();

	int size = (int)((m_Width * m_Height) * 3);
	char * buffer = new char[size];

	std::ofstream ofs(filename, std::ios::out | std::ios::binary);
	ofs << "P6\n" << m_Width << " " << m_Height << "\n255\n";

	for (unsigned i = 0, imageIndex = 0; i < size; i+=3, ++imageIndex)
	{
		buffer[i] = (unsigned char)(std::min(float(1), image[imageIndex].x) * 255);
		buffer[i + 1] = (unsigned char)(std::min(float(1), image[imageIndex].y) * 255);
		buffer[i + 2] = (unsigned char)(std::min(float(1), image[imageIndex].z) * 255);
	}

	ofs.write(buffer, size);
	ofs.close();
	delete[] image; 

	auto endtime = std::chrono::high_resolution_clock::now();
	auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(endtime - starttime).count();

	std::cout << "[Chrono Timer] Render took " << duration << "ms to execute." << std::endl;

	outputWriterPPM << "Iteration: " << iteration << " - Duration: " << duration << std::endl;
	

}


void CreateScene(bool NotionOfTime) {

	for (int frame = 1; frame < (m_Frames + 1); frame++) {
		std::vector<Sphere> render_Spheres = m_Spheres;

		if (NotionOfTime) {
			render_Spheres.push_back(
				Sphere(
					Vec3f((frame - (m_Frames / 2)) * 10, 15, -75),
					5,
					Vec3f(1.00, 1, 0), 0, 0.5)
			);//sun colour as well as notion of time.

			render_Spheres.push_back(
				Sphere(
					Vec3f((frame - (m_Frames / 2) * 10) - 50, 15, -75),
					3,
					Vec3f(1.00, 1, 1), 0.5, 0.5)
			);//moon
		}

		if (frame > 1) {
			// apply animations to spheres.

		}

		renderWithThreading(render_Spheres, frame, m_UseThreading);
	}
}

void ReadXML() {

	std::cout << "#### LOADING SCENE FROM XML ####" << std::endl;

	TiXmlDocument sceneXML("./Exported_Scene.xml");

	//Load spheres, animation and number of frames;
	if (sceneXML.LoadFile()) {
		auto start = std::chrono::high_resolution_clock::now();

		std::cout << "Loaded XML file." << std::endl << std::endl;

		TiXmlElement *pRoot, *pParm;

		pRoot = sceneXML.FirstChildElement("Scene");

		if (pRoot)
		{
			std::cout << "Found Scene Data:" << std::endl;

			pParm = pRoot->FirstChildElement("GameObject");
			while (pParm) //Loop through the game objects
			{//Get each bit of data from each object
				const char* type = pParm->FirstChildElement("Type")->GetText();

				float X = std::stof(pParm->FirstChildElement("X")->GetText());
				float Y = std::stof(pParm->FirstChildElement("Y")->GetText());
				float Z = std::stof(pParm->FirstChildElement("Z")->GetText());

				float radius = std::stof(pParm->FirstChildElement("Radius")->GetText());
				float reflectivity = std::stof(pParm->FirstChildElement("Reflectivity")->GetText());
				double transparency = std::stod(pParm->FirstChildElement("Transparency")->GetText());

				float ColourR = std::stof(pParm->FirstChildElement("ColourR")->GetText());
				float ColourG = std::stof(pParm->FirstChildElement("ColourG")->GetText());
				float ColourB = std::stof(pParm->FirstChildElement("ColourB")->GetText());

				std::cout << "[Object] Type: " << type << ", X: " << X << ", Y: " << Y << ", Z: " << Z << ", Radius: " << radius << ", Transparency: " << transparency << ", Reflectivity: " << reflectivity << ", Colour RGB: " << ColourR << ", " << ColourG << ", " << ColourB << std::endl;

				//Sphere* newSphere = new Sphere(Vec3(X, Y, Z), radius, Vec3(ColourR, ColourG, ColourB), reflectivity, transparency);

				m_Spheres.push_back(Sphere(Vec3(X, Y, Z), radius, Vec3(ColourR, ColourG, ColourB), reflectivity, transparency));

				pParm = pParm->NextSiblingElement("GameObject");
			}

			pParm = pRoot->FirstChildElement("Settings");
			if (pParm) {
				m_Frames = std::stoi(pParm->FirstChildElement("NumberOfFrames")->GetText());
				m_Width = std::stoi(pParm->FirstChildElement("SceneWidth")->GetText());
				m_Height = std::stoi(pParm->FirstChildElement("SceneHeight")->GetText());
				m_UseThreading = (std::stoi(pParm->FirstChildElement("MultiThreading")->GetText()) == 1);
				float CameraX = std::stof(pParm->FirstChildElement("CameraX")->GetText());
				float CameraY = std::stof(pParm->FirstChildElement("CameraY")->GetText());
				float CameraZ = std::stof(pParm->FirstChildElement("CameraZ")->GetText());
				m_CameraPosition = Vec3(CameraX, CameraY, CameraZ);
				m_UseNotionofTime = (std::stoi(pParm->FirstChildElement("NotionOfTime")->GetText()) == 1);
				
				std::cout << "[Setting] Number of frames: " << m_Frames << std::endl;
				std::cout << "[Setting] Set resolution: " << m_Width << "x" << m_Height << std::endl;
				std::cout << "[Setting] Use multi-threading: " << m_UseThreading << std::endl;
				std::cout << "[Setting] Use notion of time: " << m_UseNotionofTime << std::endl;
				std::cout << "[Setting] Camera Position: X: " << CameraX << ", Y: " << CameraY << ", Z: " << CameraZ << std::endl;
			}

			

			auto end = std::chrono::high_resolution_clock::now();
			auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count();

			std::cout << std::endl << "[Chrono Timer] Loading XML took " << duration << "ms to execute." << std::endl;
			
			std::cout << "#### LOADED SETTINGS FROM XML ####" << std::endl << std::endl;
		}
	}
	else {
		std::cout << "Unable to load XML file." << std::endl;
	}



}

//[comment]
// In the main function, we will create the scene which is composed of 5 spheres
// and 1 light (which is also a sphere). Then, once the scene description is complete
// we render that scene, by calling the render() function.
//[/comment]
int main(int argc, char **argv)
{
	memoryPool = new MemoryPool();

	//Read XML for scene objects and settings.
	ReadXML();

	//Open streams once
	outputWriterRay.open("./output/raychronotimerlog.txt", fstream::app);
	outputWriterPPM.open("./output/ppmchronotimerlog.txt", fstream::app);

	//Initially calculate values for render.
	invWidth = 1 / float(m_Width);
	invHeight = 1 / float(m_Height);
	aspectratio = m_Width / float(m_Height);
	angle = tan(M_PI * 0.5 * fov / 180.);
	threads = std::thread::hardware_concurrency();
	threadCount = (int)threads;
	pPerThread = m_Height / (int)threads;

	//Create scene using data from XML file.
	CreateScene(m_UseNotionofTime);

	//close streams once
	outputWriterRay.close();
	outputWriterPPM.close();

	//Print heap information.
	std::cout << "Default Heap Size: " << defaultHeap->GetSize() << std::endl;

	std::getchar(); //prevent command prompt window from closing.

	return 0;
}
