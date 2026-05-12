using Rhino.Geometry;
using RhinoWPFMVVVMIntro.Services;

namespace RhinoWPFMVVVMIntro.Tests
{
    [TestFixture]
    public class LayerAssignmentServiceIntegrationTests : GlobalSetup
    {
        [Test]
        public void LayerAssignmentVM_NoObjectIsLost()
        {
            //Arrange
            List<Guid> objectIds = [];
            objectIds.Add(Document.Objects.AddSphere(new Sphere(Point3d.Origin, 5)));
            objectIds.Add(Document.Objects.AddSphere(new Sphere(Point3d.Origin, 15)));
            objectIds.Add(Document.Objects.AddSphere(new Sphere(Point3d.Origin, 25)));

            //Act
            LayerAssignmentService layerAssignmentService = new LayerAssignmentService();
            layerAssignmentService.AssignLayers(objectIds);

            //Assert
            Assert.That(Document.Objects.Count, Is.EqualTo(objectIds.Count));
        }

        [Test]
        public void LayerAssignmentVM_EachGeometryHasOneLayer()
        {
            //Arrange
            List<Guid> objectIds = [];
            objectIds.Add(Document.Objects.AddSphere(new Sphere(Point3d.Origin, 5)));
            objectIds.Add(Document.Objects.AddSphere(new Sphere(Point3d.Origin, 15)));
            objectIds.Add(Document.Objects.AddSphere(new Sphere(Point3d.Origin, 25)));

            //Act
            LayerAssignmentService layerAssignmentService = new LayerAssignmentService();
            layerAssignmentService.AssignLayers(objectIds);

            //Assert
            Assert.That(Document.Layers.Count, Is.EqualTo(objectIds.Count + 1));
        }

        [Test]
        public void LayerAssignmentVM_EachObjectLayerIsNamedAfterObject()
        {
            //Arrange
            List<Guid> objectIds = [];
            objectIds.Add(Document.Objects.AddSphere(new Sphere(Point3d.Origin, 5)));
            objectIds.Add(Document.Objects.AddSphere(new Sphere(Point3d.Origin, 15)));
            objectIds.Add(Document.Objects.AddSphere(new Sphere(Point3d.Origin, 25)));
            HashSet<string> objectNames = [.. objectIds.Select(x => x.ToString())];

            //Act
            LayerAssignmentService layerAssignmentService = new LayerAssignmentService();
            layerAssignmentService.AssignLayers(objectIds);

            //Assert
            for (int i = 0; i < objectIds.Count; i++)
                Assert.That(objectNames.Contains(Document.Objects.Find(objectIds[i]).Id.ToString()));
        }
    }
}
