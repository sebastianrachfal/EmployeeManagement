using System.Windows;
using System.Windows.Controls;
using EmployeeManagementCL;

namespace EmployeeManagementWPF
{
    internal struct CurrentSelection
    {
        internal DataGrid Grid { get; }
        internal int Selected { get; }
        internal CurrentSelection(DataGrid dg, int item = -1)
        {
            Grid = dg;
            Selected = item;
        }

    }
    /// <summary>
    /// MainWindow.xaml logic
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeManager Manager;
        private CurrentSelection? Selection;
        private int LastIndex;
        internal MainWindow()
        {
            InitializeComponent();
            Manager = new EmployeeManager();
            ClearSelectionAll();
            InitializeDataGrids();

            Selection = new CurrentSelection(EmployeeDataGrid);
            LastIndex = 0;
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
                    ClearSelectionAll();
                    Selection = new CurrentSelection(GetDataGridFromTabIndex(index));
                }
                LastIndex = index;
            }
        }
        private void HandleDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null)
            {
                var grid = (DataGrid)sender;
                if(grid.SelectedIndex != -1)
                {
                    Selection = new CurrentSelection(grid, grid.SelectedIndex);
                    EditButton.IsEnabled = RemoveButton.IsEnabled = true;
                }
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (Selection != null)
            {
                var selection = ((CurrentSelection)Selection);
                Manager.RemoveItem(GetDbTypeFromName(selection.Grid.Name), ((IDbElement)selection.Grid.Items.GetItemAt(selection.Selected)).ID);
                ClearSelectionAll();
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Selection != null)
            {
                dynamic curWindow = null;
                var selection = ((CurrentSelection)Selection);
                DbType curDT = GetDbTypeFromName(selection.Grid.Name);
                switch (curDT)
                {
                    case DbType.Target:
                        curWindow = new TargetWindow();
                        break;
                    case DbType.Product:
                        curWindow = new ProductWindow(Manager.GetAllItemsListOf<ProductTarget>());
                        break;
                    case DbType.Task:
                        curWindow = new TaskWindow(Manager.GetAllItemsListOf<Product>());
                        break;
                    case DbType.Employee:
                        curWindow = new EmployeeWindow(Manager.GetAllItemsListOf<CompanyTask>());
                        break;
                }
                if(curWindow != null)
                {
                    if (curWindow.ShowDialog() == true && curWindow.Data != null)
                        Manager.AddItem(curDT, curWindow.Data);
                }
                ClearSelectionAll();
            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (Selection != null)
            {
                var selection = ((CurrentSelection)Selection);
                var editedItem = (IDbElement)selection.Grid.Items.GetItemAt(selection.Selected);
                DataGrid curDG = null;
                DbType curDT = GetDbTypeFromName(selection.Grid.Name);
                dynamic curWindow = null;
                switch (curDT)
                {
                    case DbType.Target:
                        curWindow = new TargetWindow((ProductTarget)editedItem);
                        curDG = TargetDataGrid;
                        break;
                    case DbType.Product:
                        curWindow = new ProductWindow(Manager.GetAllItemsListOf<ProductTarget>(), (Product)editedItem);
                        curDG = ProductDataGrid;
                        break;
                    case DbType.Task:
                        curWindow = new TaskWindow(Manager.GetAllItemsListOf<Product>(), (CompanyTask)editedItem);
                        curDG = TaskDataGrid;
                        break;
                    case DbType.Employee:
                        curWindow = new EmployeeWindow(Manager.GetAllItemsListOf<CompanyTask>(), (Employee)editedItem);
                        curDG = EmployeeDataGrid;
                        break;
                }
                if (curWindow != null) {
                    if (curWindow.ShowDialog() == true && curWindow.Data != null && ((curWindow.Data.ID = editedItem.ID) == editedItem.ID))
                    {
                        Manager.EditItem((DbType)curDT, curWindow.Data);
                        curDG.ItemsSource = null; // I don't like this, but for some reason it doesn't work without it
                        ClearSelectionAll();
                        InitializeDataGrids(); // Reset DataGrids
                    }
                }
            }
        }
        private DataGrid GetDataGridFromTabIndex(int index)
        {
            switch (index)
            {
                case 1: return TaskDataGrid;
                case 2: return ProductDataGrid;
                case 3: return TargetDataGrid;
                default: return EmployeeDataGrid;
            }
        }
        private DbType GetDbTypeFromName(string name)
        {
            switch (name)
            {
                case "TaskDataGrid": return DbType.Task;
                case "ProductDataGrid": return DbType.Product;
                case "TargetDataGrid": return DbType.Target;
                default: return DbType.Employee;
            }
        }
        private void ClearSelectionAll()
        {
            if(Selection != null)
            {
                var s = (CurrentSelection)Selection;
                s.Grid.UnselectAll();
                if(s.Selected != -1)
                    Selection = null;
            }
            EditButton.IsEnabled = RemoveButton.IsEnabled = false;
        }
    }
}
