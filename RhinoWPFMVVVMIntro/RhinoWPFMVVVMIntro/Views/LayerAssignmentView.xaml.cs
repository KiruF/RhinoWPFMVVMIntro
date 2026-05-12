using RhinoWPFMVVVMIntro.ViewModels;
using System.ComponentModel;
using System.Windows.Controls;
using Plugin = RhinoWPFMVVVMIntro.RhinoWPFMVVVMIntroPlugin;


namespace RhinoWPFMVVVMIntro.Views
{
    /// <summary>
    /// Interaction logic for LayerAssignmentView.xaml
    /// </summary>
    /// 
    public partial class LayerAssignmentView : UserControl
    {
        public LayerAssignmentView()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            DataContext = new LayerAssignmentVM(Plugin.Instance.LayerAssignmentService, Plugin.Instance.RhinoDocService);
        }
    }
}
