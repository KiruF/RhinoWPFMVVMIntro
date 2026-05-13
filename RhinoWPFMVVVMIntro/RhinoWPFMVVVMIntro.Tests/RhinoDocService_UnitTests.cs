using NUnit.Framework;
using Rhino;
using Rhino.DocObjects;
using Rhino.Geometry;
using Rhino.Testing.Fixtures;
using RhinoWPFMVVVMIntro.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RhinoWPFMVVVMIntro.Tests
{
    /// <summary>
    /// Integration tests for RhinoDocService.
    /// These tests run inside Rhino test environment.
    /// </summary>
    [TestFixture]
    public class RhinoDocService_IntegrationTests : RhinoTestFixture
    {
        private RhinoDocService _service;

        [SetUp]
        public void Setup()
        {
            _service = new RhinoDocService();

            RhinoDoc doc = RhinoDoc.ActiveDoc;

            // Clean document before each test
            doc.Objects.Clear();
        }

        [Test]
        public void SelectAllRhinoObjects_ShouldSelectEveryObject()
        {
            // Arrange
            RhinoDoc doc = RhinoDoc.ActiveDoc;

            Sphere sphere1 = new Sphere(Point3d.Origin, 5);
            Sphere sphere2 = new Sphere(new Point3d(10, 0, 0), 5);

            doc.Objects.AddSphere(sphere1);
            doc.Objects.AddSphere(sphere2);

            // Act
            _service.SelectAllRhinoObjects();

            // Assert
            var selected = doc.Objects.GetSelectedObjects(false, false);

            Assert.That(selected.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetSelectedObjectIds_ShouldReturnSelectedIds()
        {
            // Arrange
            RhinoDoc doc = RhinoDoc.ActiveDoc;

            Guid id1 = doc.Objects.AddPoint(Point3d.Origin);
            Guid id2 = doc.Objects.AddPoint(new Point3d(5, 0, 0));

            doc.Objects.Select(id1);
            doc.Objects.Select(id2);

            // Act
            IReadOnlyList<Guid> result =
                _service.GetSelectedObjectIds();

            // Assert
            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result, Does.Contain(id1));
            Assert.That(result, Does.Contain(id2));
        }

        [Test]
        public void GetSelectedObjectIds_WhenNothingSelected_ShouldReturnEmptyList()
        {
            // Arrange
            RhinoDoc doc = RhinoDoc.ActiveDoc;

            doc.Objects.AddPoint(Point3d.Origin);

            // Act
            IReadOnlyList<Guid> result =
                _service.GetSelectedObjectIds();

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void CrazyRotate_ShouldDuplicateSelectedObjects()
        {
            // Arrange
            RhinoDoc doc = RhinoDoc.ActiveDoc;

            Guid id = doc.Objects.AddPoint(new Point3d(10, 0, 0));

            doc.Objects.Select(id);

            int countBefore = doc.Objects.Count;

            // Act
            _service.CrazyRotate();

            // Assert
            int countAfter = doc.Objects.Count;

            Assert.That(countAfter, Is.EqualTo(countBefore + 1));
        }

        [Test]
        public void CrazyRotate_ShouldKeepOriginalObject()
        {
            // Arrange
            RhinoDoc doc = RhinoDoc.ActiveDoc;

            Guid id = doc.Objects.AddPoint(new Point3d(10, 0, 0));

            doc.Objects.Select(id);

            // Act
            _service.CrazyRotate();

            // Assert
            RhinoObject original =
                doc.Objects.FindId(id);

            Assert.That(original, Is.Not.Null);
        }

        [Test]
        public void CrazyRotate_WhenNothingSelected_ShouldDoNothing()
        {
            // Arrange
            RhinoDoc doc = RhinoDoc.ActiveDoc;

            doc.Objects.AddPoint(Point3d.Origin);

            int countBefore = doc.Objects.Count;

            // Act
            _service.CrazyRotate();

            // Assert
            int countAfter = doc.Objects.Count;

            Assert.That(countAfter, Is.EqualTo(countBefore));
        }

        [Test]
        public void Redraw_ShouldExecuteWithoutException()
        {
            // Assert
            Assert.DoesNotThrow(() =>
            {
                _service.Redraw();
            });
        }
    }
}



//using NUnit.Framework;
//using Rhino;
//using Rhino.DocObjects;
//using Rhino.Geometry;
//using Rhino.Testing.Fixtures;
//using RhinoWPFMVVVMIntro.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace RhinoWPFMVVVMIntro.Tests
//{
//    [TestFixture]
//    public class RhinoDocService_UnitTests : RhinoTestFixture
//    {
//        private RhinoDocService _service;

//        [SetUp]
//        public void Setup()
//        {
//            _service = new RhinoDocService();
//            RhinoDoc.ActiveDoc.Objects.Clear();
//        }

//        [Test]
//        public void SelectAllRhinoObjects_ShouldSelectEveryObject()
//        {
//            // Arrange
//            RhinoDoc doc = RhinoDoc.ActiveDoc;

//            Sphere sphere1 = new Sphere(Point3d.Origin, 5);
//            Sphere sphere2 = new Sphere(new Point3d(10, 0, 0), 5);

//            doc.Objects.AddSphere(sphere1);
//            doc.Objects.AddSphere(sphere2);

//            // Act
//            _service.SelectAllRhinoObjects();

//            // Assert
//            var selected = doc.Objects.GetSelectedObjects(false, false);
//            Assert.That(selected.Count(), Is.EqualTo(2));
//        }

//        [Test]
//        public void GetSelectedObjectIds_ShouldReturnSelectedIds()
//        {
//            // Arrange
//            RhinoDoc doc = RhinoDoc.ActiveDoc;

//            Guid id1 = doc.Objects.AddPoint(Point3d.Origin);
//            Guid id2 = doc.Objects.AddPoint(new Point3d(5, 0, 0));

//            doc.Objects.Select(id1);
//            doc.Objects.Select(id2);

//            // Act
//            IReadOnlyList<Guid> result =
//                _service.GetSelectedObjectIds();

//            // Assert
//            Assert.That(result, Has.Count.EqualTo(2));
//            Assert.That(result, Does.Contain(id1));
//            Assert.That(result, Does.Contain(id2));
//        }

//        [Test]
//        public void GetSelectedObjectIds_WhenNothingSelected_ShouldReturnEmptyList()
//        {
//            // Arrange
//            RhinoDoc doc = RhinoDoc.ActiveDoc;

//            doc.Objects.AddPoint(Point3d.Origin);

//            // Act
//            IReadOnlyList<Guid> result =
//                _service.GetSelectedObjectIds();

//            // Assert
//            Assert.That(result, Is.Empty);
//        }

//        [Test]
//        public void CrazyRotate_ShouldDuplicateSelectedObjects()
//        {
//            // Arrange
//            RhinoDoc doc = RhinoDoc.ActiveDoc;

//            Guid id = doc.Objects.AddPoint(new Point3d(10, 0, 0));

//            doc.Objects.Select(id);

//            int countBefore = doc.Objects.Count;

//            // Act
//            _service.CrazyRotate();

//            // Assert
//            int countAfter = doc.Objects.Count;

//            Assert.That(countAfter, Is.EqualTo(countBefore + 1));
//        }

//        [Test]
//        public void CrazyRotate_ShouldNotRemoveOriginalObject()
//        {
//            // Arrange
//            RhinoDoc doc = RhinoDoc.ActiveDoc;
//            Guid id = doc.Objects.AddPoint(new Point3d(10, 0, 0));
//            doc.Objects.Select(id);

//            // Act
//            _service.CrazyRotate();

//            // Assert
//            RhinoObject original = doc.Objects.FindId(id);
//            Assert.That(original, Is.Not.Null);
//        }

//        [Test]
//        public void CrazyRotate_WhenNothingSelected_ShouldDoNothing()
//        {
//            // Arrange
//            RhinoDoc doc = RhinoDoc.ActiveDoc;
//            doc.Objects.AddPoint(Point3d.Origin);
//            int countBefore = doc.Objects.Count;

//            // Act
//            _service.CrazyRotate();

//            // Assert
//            int countAfter = doc.Objects.Count;
//            Assert.That(countAfter, Is.EqualTo(countBefore));
//        }

//        [Test]
//        public void Redraw_ShouldExecuteWithoutException()
//        {
//            // Assert
//            Assert.DoesNotThrow(() =>
//            {
//                _service.Redraw();
//            });
//        }
//    }
//}