using RhinoWPFMVVVMIntro.Base;
using RhinoWPFMVVVMIntro.ViewModels.Utility;
using System.Windows.Input;

namespace RhinoWPFMVVVMIntro.ViewModels
{
    /// <summary>
    /// View model for the host panel.
    /// </summary>
    public sealed class HostVM : PropertyChangedNotifier
    {
        readonly RelayCommand _selectAllRhObjs;

        /// <summary>
        /// Initializes host view commands.
        /// </summary>
        public HostVM()
        {
            _selectAllRhObjs = new RelayCommand(_ => SelectAllRhinoObjects());
        }

        /// <summary>
        /// Gets the command that selects all Rhino objects in the active document.
        /// </summary>
        public ICommand SelectAllRhObjs
            => _selectAllRhObjs;

        void SelectAllRhinoObjects()
        {
            RhinoWPFMVVVMIntroPlugin.Instance
                .RhinoDocService
                .SelectAllRhinoObjects();
        }
    }
}
