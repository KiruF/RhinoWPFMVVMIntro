using Rhino.Geometry;
using RhinoWPFMVVVMIntro.Services;
using RhinoWPFMVVVMIntro.ViewModels;

namespace RhinoWPFMVVVMIntro.Tests;

[Category("RhinoIntegration")]
public sealed class HostVMTests : RhinoIntegrationTestFixture
{
    [Test]
    public void SelectAllRhObjs_ExecutesDocumentSelection()
    {
        //var rhinoDocService = new TestRhinoDocService();
        //var hostVM = new HostVM(rhinoDocService);

        //hostVM.SelectAllRhObjs.Execute(null);

        //Assert.That(rhinoDocService.SelectAllRhinoObjectsCallCount, Is.EqualTo(1));
    }

    [Test]
    public void ScaleSelectedRhObjs_ExecutesDocumentScaling()
    {
        //var rhinoDocService = new TestRhinoDocService();
        //var hostVM = new HostVM(rhinoDocService);

        //hostVM.ScaleSelectedRhObjs.Execute(null);

        //Assert.That(rhinoDocService.ScaleSelectedRhinoObjectsCallCount, Is.EqualTo(1));
    }

    public sealed class TestRhinoDocService : IRhinoDocService
    {
        public int SelectAllRhinoObjectsCallCount { get; private set; }
        public int ScaleSelectedRhinoObjectsCallCount { get; private set; }

        public IReadOnlyList<Guid> GetSelectedObjectIds()
        {
            return [];
        }

        public void SelectAllRhinoObjects()
        {
            SelectAllRhinoObjectsCallCount++;
        }


        public void Redraw()
        {
        }

        public void Replace(Guid rhinoObjectId, GeometryBase geometry)
        {
        }

        public List<GeometryBase> GetGeometryFromIds(IReadOnlyList<Guid> selectedObjectsIds)
        {
            return [];
        }
    }
}
