using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using EmployeeManagementCL;

namespace EmployeeManagementWPF
{
    /// <summary>
    /// TaskWindow.xaml logic
    /// </summary>
    public partial class TaskWindow : Window
    {
        internal CompanyTask Data;
        private IList<Product> ProductList;
        public TaskWindow(IList<Product> pl, CompanyTask ct = null)
        {
            InitializeComponent();
            ProductList = pl;
            ProductInput.ItemsSource = pl.Select(x => x.Name);
            CreatedAtInput.SelectedDate = ct?.CreatedAt ?? DateTime.Now;
            if (ct != null)
            {
                Data = ct;
                NameInput.Text = ct.Name;
                DescriptionInput.Text = ct.Description;
                DeadlineInput.SelectedDate = ct.Deadline;
                FinishedInput.IsChecked = ct.Finished;
                if(ct.ProductID != null)
                    ProductInput.SelectedIndex = pl.Select(x=>x.ID).ToList().IndexOf((int)ct.ProductID);
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
                int? index = null;
                if (ProductInput.SelectedIndex != -1)
                    index = ProductList.ElementAt(ProductInput.SelectedIndex).ID;
                if(DeadlineInput.SelectedDate == null) throw new ArgumentException("You must specify a deadline.");
                Data = new CompanyTask(NameInput.Text.Trim(), DescriptionInput.Text.Trim(), (DateTime)DeadlineInput.SelectedDate, index, (bool)FinishedInput.IsChecked);
                DialogResult = true;
                Close();
            } catch (Exception ex)
            {
                WarningBox.Show(ex.Message);
            }
            
        }

        private void ClearProductButton_Click(object sender, RoutedEventArgs e) => ProductInput.SelectedIndex = -1;
    }
}
