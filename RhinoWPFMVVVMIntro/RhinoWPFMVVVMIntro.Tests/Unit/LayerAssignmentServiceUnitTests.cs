using RhinoWPFMVVVMIntro.Services;
using RhinoWPFMVVVMIntro.ViewModels;

namespace RhinoWPFMVVVMIntro.Tests.Unit
{
    public sealed class LayerAssignmentServiceUnitTests
    {
        [Test]
        public void AssignLayers_ExecutesLayerAssignment()
        {
            RhinoDocService docService = new();
            TestLayerAssignmentService layerService = new();
            LayerAssignmentVM viewModel = new(layerService, docService);

            viewModel.AssignLayersCommand.Execute(null);

            Assert.That(layerService.AssignedLayersWorked, Is.True);
        }

        sealed class TestLayerAssignmentService : ILayerAssignemntService
        {
            public bool AssignedLayersWorked { get; set; } = false;

            public void AssignLayers(IReadOnlyList<Guid> objIds)
                => AssignedLayersWorked = true;
        }
    }
}
