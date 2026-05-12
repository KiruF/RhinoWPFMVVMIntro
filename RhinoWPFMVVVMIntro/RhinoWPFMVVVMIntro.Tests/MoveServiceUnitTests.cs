using Rhino.Geometry;
using RhinoWPFMVVVMIntro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoWPFMVVVMIntro.Tests
{
    public class MoveServiceUnitTests
    {
        [Test]
        public void Move_NullGeometry_ThrowsArgumentNullException()
        {
            MoveGeometryService moveService = new();
            Assert.Throws<ArgumentNullException>(() => moveService.Move(null));
        }

        //[Test]
        //public void Scale_ValidGeometry_ScalingBy2()
        //{
        //    // Arrange
        //    var scaleService = new ScaleService();
        //    Box box = new Box(Plane.WorldXY, new Interval(0, 10), new Interval(0, 10), new Interval(0, 10));
        //    // Act
        //    GeometryBase testGeometry = scaleService.Scale(box.ToExtrusion(), 2.0);

        //    // Assert
        //    double volume = testGeometry.GetBoundingBox(true).Volume;
        //    Assert.That(volume, Is.EqualTo(8000).Within(0.01), "Expected volume to be 8000 after scaling by a factor of 2.");
        //}
    }
}
