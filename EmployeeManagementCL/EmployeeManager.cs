using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EmployeeManagementCL
{
    public class EmployeeManager
    {
        private CompanyContext CurrentContext;
        /// <summary>
        /// Method for initializing the database
        /// </summary>
        public EmployeeManager()
        {
            CurrentContext = new CompanyContext();
            LoadDbs();
        }
        /// <summary>
        /// Reference to the table `Employees`
        /// </summary>
        public DbSet<Employee> EmployeesDbSet => CurrentContext.Employees;
        /// <summary>
        /// Reference to the table `CompanyTasks`
        /// </summary>
        public DbSet<CompanyTask> TasksDbSet => CurrentContext.CompanyTasks;
        /// <summary>
        /// Reference to the table `Products`
        /// </summary>
        public DbSet<Product> ProductsDbSet => CurrentContext.Products;
        /// <summary>
        /// Reference to the table `Targets`
        /// </summary>
        public DbSet<ProductTarget> TargetsDbSet => CurrentContext.Targets;
        /// <summary>
        /// Method for getting items of IDbElement as list
        /// </summary>
        /// <typeparam name="T">IDbElement to fetch</typeparam>
        /// <returns>List<T> populated with data form table, or empty list on fail</returns>
        public IList<T> GetAllItemsListOf<T>() where T : IDbElement
        {
            switch(typeof(T).Name)
            {
                case "Employee": return (IList<T>)EmployeesDbSet.Select(x => x).ToList();
                case "CompanyTask": return (IList<T>)TasksDbSet.Select(x => x).ToList();
                case "Product": return (IList<T>)ProductsDbSet.Select(x => x).ToList();
                case "ProductTarget": return (IList<T>)TargetsDbSet.Select(x => x).ToList();
                default: return new List<T>();
            }
        }
        private void LoadDbs()
        {
            CurrentContext.Employees.Load();
            CurrentContext.Targets.Load();
            CurrentContext.Products.Load();
            CurrentContext.CompanyTasks.Load();
        }
        /// <summary>
        /// Method for removing item from a database
        /// </summary>
        /// <param name="type">DbType of a table</param>
        /// <param name="index">ID of an item to remove</param>
        public void RemoveItem(DbType type, int index)
        {
            switch(type)
            {
                case DbType.Employee:
                    EmployeesDbSet.Remove(EmployeesDbSet.Find(index));
                    break;
                case DbType.Task:
                    TasksDbSet.Remove(TasksDbSet.Find(index));
                    break;
                case DbType.Product:
                    ProductsDbSet.Remove(ProductsDbSet.Find(index));
                    break;
                case DbType.Target:
                    TargetsDbSet.Remove(TargetsDbSet.Find(index));
                    break;
            }
            CurrentContext.SaveChanges();
        }
        /// <summary>
        /// Method for adding new item to a database
        /// </summary>
        /// <param name="type">DbType of a table</param>
        /// <param name="element">element to add</param>
        public void AddItem(DbType type, IDbElement element)
        {
            switch (type)
            {
                case DbType.Employee:
                    EmployeesDbSet.Add((Employee)element);
                    break;
                case DbType.Task:
                    TasksDbSet.Add((CompanyTask)element);
                    break;
                case DbType.Product:
                    ProductsDbSet.Add((Product)element);
                    break;
                case DbType.Target:
                    TargetsDbSet.Add((ProductTarget)element);
                    break;
            }
            CurrentContext.SaveChanges();
        }
        /// <summary>
        /// Method for editing item in a database
        /// </summary>
        /// <param name="type">DbType of a table</param>
        /// <param name="element">element to edit</param>
        public void EditItem(DbType type, IDbElement element)
        {
            // Manually setting the properties; for some reason, batching them through CurrentValues doesn't seem to work
            switch (type)
            {
                case DbType.Employee:
                    var emp = EmployeesDbSet.Find(element.ID);
                    if (emp != null)
                    {
                        var e = (Employee)element;
                        emp.FirstName = e.FirstName;
                        emp.LastName = e.LastName;
                        emp.City = e.City;
                        emp.Type = e.Type;
                        emp.TaskID = e.TaskID;
                        CurrentContext.Entry(emp).State = EntityState.Modified;
                    }
                    break;
                case DbType.Task:
                    var task = TasksDbSet.Find(element.ID);
                    if (task != null)
                    {
                        var t = (CompanyTask)element;
                        task.Name = t.Name;
                        task.Description = t.Description;
                        task.Deadline = t.Deadline;
                        task.Finished = t.Finished;
                        task.ProductID = t.ProductID;
                        CurrentContext.Entry(task).State = EntityState.Modified;
                    }
                    break;
                case DbType.Product:
                    var product = ProductsDbSet.Find(element.ID);
                    if (product != null)
                    {
                        var p = (Product)element;
                        product.Name = p.Name;
                        product.Description = p.Description;
                        product.TargetID = p.TargetID;
                        CurrentContext.Entry(product).State = EntityState.Modified;
                    }
                    break;
                case DbType.Target:
                    var target = TargetsDbSet.Find(element.ID);
                    if(target != null)
                    {
                        target.Name = ((ProductTarget)element).Name;
                        CurrentContext.Entry(target).State = EntityState.Modified;
                    }
                    break;
            }
            CurrentContext.SaveChanges();
        }
    }
}
