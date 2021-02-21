using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EmployeeManagementCL;

namespace EmployeeManagementWPF
{
    /// <summary>
    /// Logika interakcji dla klasy TargetWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public Product Data;
        public ProductWindow(Product p = null)
        {
            InitializeComponent();
            if(p != null)
            {
                Data = p;
                NameInput.Text = p.Name;
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
                //Data = new Product(NameInput.Text);
                DialogResult = true;
                Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
