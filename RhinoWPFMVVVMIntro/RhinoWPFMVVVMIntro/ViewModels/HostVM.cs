using RhinoWPFMVVVMIntro.Base;
using RhinoWPFMVVVMIntro.Services;
using RhinoWPFMVVVMIntro.ViewModels.Utility;
using System;
using System.Windows.Input;

namespace RhinoWPFMVVVMIntro.ViewModels
{
    /// <summary>
    /// View model for the host panel.
    /// </summary>
    public sealed class HostVM : PropertyChangedNotifier
    {
        readonly RelayCommand _selectAllRhObjs;
        readonly RelayCommand _crazyRotate;
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
            _crazyRotate = new RelayCommand(CRAZYROTATE);
        }

        /// <summary>
        /// Gets the command that selects all Rhino objects in the active document.
        /// </summary>
        public ICommand SelectAllRhObjs
            => _selectAllRhObjs;

        public ICommand CrazyRotate
          => _crazyRotate;

        public int Counter 
        { 
            get=> _counter; 
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

        void CRAZYROTATE(object? obj)
        {
            _rhinoDocService.CrazyRotate();
        }
    }
}
