using Eto.Forms;
using RhinoWPFMVVVMIntro.Services;
using System;
using System.Windows.Input;

namespace RhinoWPFMVVVMIntro.ViewModels
{
    public class LayerAssignmentVM
    {
        private readonly RelayCommand _assignLayersCommand;
        private readonly ILayerAssignemntService _layerAssignemntService;

        public LayerAssignmentVM(ILayerAssignemntService layerAssignemntService)
        { 
            _layerAssignemntService = layerAssignemntService
                ?? throw new ArgumentNullException(nameof(layerAssignemntService));

            _assignLayersCommand = new RelayCommand(AssignLayers);
        }

        public ICommand AssignLayersCommand 
            => _assignLayersCommand;

        private void AssignLayers()
            => _layerAssignemntService.AssignLayers();
        
    }
}
