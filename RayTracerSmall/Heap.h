#pragma once

#include <cassert>
#include <stdlib.h>
#include <cstdio>
#include <iostream>

using namespace std;

#define NAMELENGTH 20

#define STARTMARKER 0xDEADC0DE
#define ENDMARKER 0xDEADBEEF



class Heap
{
public:
	struct AllocHeader
	{
		int iSignature;
		int iSize;
		Heap * pHeap;
		AllocHeader * pNext;
		AllocHeader * pPrev;
	};

	Heap(const char * name);
	~Heap();

	const char * GetName() const;
	void AddAllocation(size_t size);
	void RemoveAllocation(size_t size);
	size_t GetSize();
	

	

	void * Heap::operator new (size_t size) { //Prevent new heap from adding itself to a heap - causes endless loop when creating new heap.
		std::cout << "[Heap] New operator called for heap." << std::endl;

		size_t iRequestedBytes = size + sizeof(AllocHeader) + sizeof(int);
		char * pMem = (char *)malloc(iRequestedBytes);
		AllocHeader * pHeader = (AllocHeader *)pMem;
		pHeader->iSignature = STARTMARKER;
		pHeader->iSize = size;
		void * pStartMemBlock = pMem + sizeof(AllocHeader);
		int* pEndMarker = (int*)((char *)pStartMemBlock + size);
		*pEndMarker = ENDMARKER;
		return pStartMemBlock;
	}

	static Heap * CreateNewHeap(const char * name) {
		std::cout << "[Heap] Creating new heap: " << name << std::endl;
		Heap * h = new Heap(name);

		return h;
	}

private:
	char * m_name;
	size_t totalsize;
};

