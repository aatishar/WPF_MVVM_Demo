using System.Windows;
using System.Windows.Controls;
using MVVMTools.Dialog;

namespace MVVMTools
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((this.DialogViewContainer.Content as UserControl)!.DataContext is DialogBase dialog)
            {
                dialog.Close();
            }
        }
    }
}
