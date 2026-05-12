using Rhino.DocObjects;
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

        public GeometryBase Move(GeometryBase? geometry)
        {
            ArgumentNullException.ThrowIfNull(geometry);
            Vector3d translation = GetTranslationDirection(geometry);
            Transform xform = Transform.Translation(translation);
            GeometryBase movedGeometry = geometry.Duplicate();
            _ = movedGeometry.Transform(xform);

            return movedGeometry;
        }
        
        private static Vector3d GetTranslationDirection(GeometryBase geometry)
        {
            BoundingBox bbox = geometry.GetBoundingBox(true);
            Point3d center = bbox.Center;
            Vector3d direction = center - Point3d.Origin;
            if (direction.IsTiny())
                throw new Exception("Cannot determine translation direction for geometry at the origin.");

            direction.Unitize();
            direction *= 10.0;

            return direction;
        }

    }
}
 