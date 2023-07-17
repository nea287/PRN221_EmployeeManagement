using System.Windows;
using System.Windows.Input;

namespace EmployeeManagement_GUI
{
    /// <summary>
    /// Interaction logic for AdditionalInformation.xaml
    /// </summary>
    public partial class AdditionalInformation : Window
    {
        public AdditionalInformation()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
