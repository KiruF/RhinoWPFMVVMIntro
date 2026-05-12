using RhinoWPFMVVVMIntro.ViewModels;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using Plugin = RhinoWPFMVVVMIntro.RhinoWPFMVVVMIntroPlugin;

namespace RhinoWPFMVVVMIntro.Views
{
    /// <summary>
    /// Interaction logic for HostView.xaml.
    /// </summary>
    [Guid("F4688FB1-80C4-4B50-B903-58AF98978D38")]
    public partial class HostView : UserControl
    {
        public HostView()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            DataContext = new HostVM(Plugin.Instance.RhinoDocService);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
