using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineEditor.Export
{
    public class Vec3
    {

        public float x, y, z;

        public Vec3()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vec3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public override string ToString()
        {
            return "[" + x + ", " + y + ", " + z + "]";
        }

    }
}
