using System;
using System.Windows;
using EmployeeManagementCL;

namespace EmployeeManagementWPF
{
    /// <summary>
    /// TargetWindow.xaml logic
    /// </summary>
    public partial class TargetWindow : Window
    {
        internal ProductTarget Data;
        internal TargetWindow(ProductTarget pt = null)
        {
            InitializeComponent();
            if(pt != null)
            {
                Data = pt;
                NameInput.Text = pt.Name;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Data = new ProductTarget(NameInput.Text.Trim());
                DialogResult = true;
                Close();
            } catch (Exception ex)
            {
                WarningBox.Show(ex.Message);
            }

        }
    }
}
