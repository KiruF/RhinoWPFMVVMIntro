using RhinoWPFMVVVMIntro.Services;
using RhinoWPFMVVVMIntro.ViewModels;

namespace RhinoWPFMVVVMIntro.Tests;

[TestFixture]
public sealed class HostVMTests
{
    [Test]
    public void SelectAllRhObjs_ExecutesDocumentSelection()
    {
        var rhinoDocService = new TestRhinoDocService();
        var hostVM = new HostVM(rhinoDocService);

        hostVM.SelectAllRhObjs.Execute(null);

        Assert.That(rhinoDocService.SelectAllRhinoObjectsCallCount, Is.EqualTo(1));
    }

    sealed class TestRhinoDocService : IRhinoDocService
    {
        public int SelectAllRhinoObjectsCallCount { get; private set; }

        public void SelectAllRhinoObjects()
        {
            SelectAllRhinoObjectsCallCount++;
        }

        public IReadOnlyList<Guid> GetSelectedObjectIds()
        {
            return [];
        }

        public void Redraw()
        {
        }
    }
}
