using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoWPFMVVVMIntro.Services
{
    public class ScaleService
    {
        public ScaleService()
        {
            
        }

        public GeometryBase Scale(GeometryBase? geometry, double factor)
        {
            ArgumentNullException.ThrowIfNull(geometry);

            GeometryBase scaledGeometry = geometry.Duplicate();
            _ = scaledGeometry.Scale(factor);

            return scaledGeometry;
        }
    }
}
