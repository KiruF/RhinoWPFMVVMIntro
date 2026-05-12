using Eto.Forms;
using RhinoWPFMVVVMIntro.Services;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace RhinoWPFMVVVMIntro.ViewModels
{
    public class LayerAssignmentVM
    {
        private readonly RelayCommand _assignLayersCommand;
        private readonly IRhinoDocService _rhinoDocService;
        private readonly ILayerAssignemntService _layerAssignemntService;

        public LayerAssignmentVM(ILayerAssignemntService layerAssignemntService, IRhinoDocService rhinoDocService)
        {
            _rhinoDocService = rhinoDocService
                ?? throw new ArgumentNullException(nameof(rhinoDocService));

            _layerAssignemntService = layerAssignemntService
                ?? throw new ArgumentNullException(nameof(layerAssignemntService));

            _assignLayersCommand = new RelayCommand(AssignLayers);
        }

        public ICommand AssignLayersCommand
            => _assignLayersCommand;

        private void AssignLayers()
        {
            IReadOnlyList<Guid> objIds = _rhinoDocService.GetSelectedObjectIds();
            _layerAssignemntService.AssignLayers(objIds);
        }
        
    }
}
