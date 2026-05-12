using Rhino.Geometry;
using RhinoWPFMVVVMIntro.Base;
using RhinoWPFMVVVMIntro.Services;
using RhinoWPFMVVVMIntro.ViewModels.Utility;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace RhinoWPFMVVVMIntro.ViewModels
{
    /// <summary>
    /// View model for the host panel.
    /// </summary>
    public sealed class HostVM : PropertyChangedNotifier
    {
        readonly RelayCommand _selectAllRhObjs;
        readonly RelayCommand _moveAwaySelectedRhObjs;
        readonly RelayCommand _scaleAllRhObjs;
        readonly IRhinoDocService _rhinoDocService;

        int _counter = 0;

        /// <summary>
        /// Initializes host view commands.
        /// </summary>
        public HostVM(IRhinoDocService rhinoDocService)
        {
            _rhinoDocService = rhinoDocService
                ?? throw new ArgumentNullException(nameof(rhinoDocService));

            _selectAllRhObjs = new RelayCommand(SelectAllRhObjsMethod);
            _moveAwaySelectedRhObjs = new RelayCommand(MoveAwaySelectedRhObjsMetod);
            _scaleAllRhObjs = new RelayCommand(ScaleSelectedRhObjsMethod);
        }

        /// <summary>
        /// Gets the command that selects all Rhino objects in the active document.
        /// </summary>
        public ICommand SelectAllRhObjs
            => _selectAllRhObjs;
        public ICommand MoveAwaySelectedRhObjs
            => _moveAwaySelectedRhObjs;

        public ICommand ScaleSelectedRhObjs
            => _scaleAllRhObjs;

        public int Counter
        {
            get => _counter;
            set
            {
                if (_counter == value)
                    return;

                _counter = value;
                OnPropertyChanged();
            }
        }

        void SelectAllRhObjsMethod(object? obj)
        {
            _rhinoDocService.SelectAllRhinoObjects();
            Counter++;
        }
        void MoveAwaySelectedRhObjsMetod(object? obj)
        {
            _rhinoDocService.MoveAwaySelectedRhinoObjects();
            Counter++;
        }

        void ScaleSelectedRhObjsMethod(object? obj)
        {
            IReadOnlyList<Guid> selectedObjectsIds = _rhinoDocService.GetSelectedObjectIds();
            List<GeometryBase> geometries = _rhinoDocService.GetGeometryFromIds(selectedObjectsIds);

            ScaleService scaleService = new ScaleService();

            for (int i = 0; i < geometries.Count; i++)
            {
                GeometryBase scaledGeometry = scaleService.Scale(geometries[i], 2.0);
                _rhinoDocService.Replace(selectedObjectsIds[i], scaledGeometry);
            }
        }
    }
}