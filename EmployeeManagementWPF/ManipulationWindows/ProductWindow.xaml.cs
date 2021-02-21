using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using EmployeeManagementCL;

namespace EmployeeManagementWPF
{
    /// <summary>
    /// ProductWindow.xaml logic
    /// </summary>
    public partial class ProductWindow : Window
    {
        internal Product Data;
        private IList<ProductTarget> TargetList;
        internal ProductWindow(IList<ProductTarget> ptl, Product p = null)
        {
            InitializeComponent();
            TargetList = ptl;
            TargetInput.ItemsSource = ptl.Select(x => x.Name);
            if (p != null)
            {
                Data = p;
                NameInput.Text = p.Name;
                DescriptionInput.Text = p.Description;
                if(p.TargetID != null)
                    TargetInput.SelectedIndex = ptl.Select(x=>x.ID).ToList().IndexOf((int)p.TargetID);
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
                if (TargetInput.SelectedIndex != -1)
                    index = TargetList.ElementAt(TargetInput.SelectedIndex).ID;
                Data = new Product(NameInput.Text.Trim(), DescriptionInput.Text.Trim(), index);
                DialogResult = true;
                Close();
            } catch (Exception ex)
            {
                WarningBox.Show(ex.Message);
            }

        }

        private void ClearTargetButton_Click(object sender, RoutedEventArgs e) => TargetInput.SelectedIndex = -1;
    }
}
