using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using EmployeeManagementCL;

namespace EmployeeManagementWPF
{
    /// <summary>
    /// EmployeeWindow.xaml logic
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        internal Employee Data;
        private IList<CompanyTask> TaskList;
        public EmployeeWindow(IList<CompanyTask> pl, Employee e = null)
        {
            InitializeComponent();
            TaskList = pl;
            TaskInput.ItemsSource = pl.Select(x => x.Name);
            TypeInput.ItemsSource = Enum.GetValues(typeof(EmployeeType)).Cast<EmployeeType>();
            if (e != null)
            {
                Data = e;
                FNameInput.Text = e.FirstName;
                LNameInput.Text = e.LastName;
                CityInput.Text = e.City;
                TypeInput.SelectedItem = e.Type;
                if(e.TaskID != null)
                    TaskInput.SelectedIndex = pl.Select(x=>x.ID).ToList().IndexOf((int)e.TaskID);
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
                if (TaskInput.SelectedIndex != -1)
                    index = TaskList.ElementAt(TaskInput.SelectedIndex).ID;
                if (TypeInput.SelectedIndex == -1) throw new ArgumentException("You must select employee type.");
                Data = new Employee(FNameInput.Text.Trim(), LNameInput.Text.Trim(), CityInput.Text.Trim(), (EmployeeType)TypeInput.SelectedItem, index);
                DialogResult = true;
                Close();
            } catch (Exception ex)
            {
                WarningBox.Show(ex.Message);
            }

        }

        private void ClearTaskButton_Click(object sender, RoutedEventArgs e) => TaskInput.SelectedIndex = -1;
    }
}
