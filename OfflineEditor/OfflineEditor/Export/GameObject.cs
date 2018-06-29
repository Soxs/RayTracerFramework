using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineEditor.Export
{

    public enum Type
    {
        Sphere
    }

    public class GameObject
    {

        public Vec3 m_Position;
        public Type m_ObjectType;
        public Vec3 m_SurfaceColour;
        public int m_Radius;
        public double m_Transparancy;
        public int m_Reflectivity;


        public GameObject(Type type, Vec3 position, int radius, Vec3 colour, double transparency, int reflectivity)
        {
            this.m_ObjectType = type;
            this.m_Position = position;
            this.m_SurfaceColour = colour;
            this.m_Radius = radius;
            this.m_Transparancy = transparency;
            this.m_Reflectivity = reflectivity;
        }

    }
}
