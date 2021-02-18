using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EmployeeManagementCL;
namespace EmployeeManagementWPF
{
    internal struct CurrentSelection
    {
        DataGrid Grid { get; }
        int Selected { get; }
        internal CurrentSelection(DataGrid dg, int item)
        {
            Grid = dg;
            Selected = item;
        }

    }
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeManager Manager;
        private CurrentSelection Selection;
        private int LastIndex;
        public MainWindow()
        {
            InitializeComponent();
            Manager = new EmployeeManager();
            InitializeDataGrids();
        }
        private void InitializeDataGrids()
        {
            EmployeeDataGrid.ItemsSource = Manager.EmployeesDbSet.Local;
            TaskDataGrid.ItemsSource = Manager.TasksDbSet.Local;
            ProductDataGrid.ItemsSource = Manager.ProductsDbSet.Local;
            TargetDataGrid.ItemsSource = Manager.TargetsDbSet.Local;
        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null)
            {
                var index = ((TabControl)sender).SelectedIndex;
                if(index != LastIndex)
                {
                    switch (index)
                    {
                        case 0:
                            AddButton.Content = "Add Employee";
                            break;
                        case 1:
                            AddButton.Content = "Add Task";
                            break;
                        case 2:
                            AddButton.Content = "Add Product";
                            break;
                        case 3:
                            AddButton.Content = "Add Target";
                            break;
                    }
                    EditButton.IsEnabled = false;
                }
                LastIndex = index;
            }
        }
        private void HandleDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null)
            {
                var dg = (DataGrid)sender;
                Selection = new CurrentSelection(dg, dg.SelectedIndex);
                EditButton.IsEnabled = true;
            }
        }
    }
}
