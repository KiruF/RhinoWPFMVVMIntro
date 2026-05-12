using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoWPFMVVVMIntro.Services
{
    public class MoveGeometryService
    {
        public MoveGeometryService()
        {

        }

        public GeometryBase Move(GeometryBase geometry, Vector3d translation)
        {
            Transform xform = Transform.Translation(translation);
            GeometryBase movedGeometry = geometry.Duplicate();
            movedGeometry.Transform(xform);
            return movedGeometry;

        }
        
    }
}
 