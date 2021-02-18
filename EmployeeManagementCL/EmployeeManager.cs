using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementCL
{
    public class EmployeeManager
    {
        CompanyContext CurrentContext;
        public EmployeeManager()
        {
            CurrentContext = new CompanyContext();
            LoadDbs();
        }
        public DbSet<Employee> EmployeesDbSet => CurrentContext.Employees;
        public DbSet<CompanyTask> TasksDbSet => CurrentContext.CompanyTasks;
        public DbSet<Product> ProductsDbSet => CurrentContext.Products;
        public DbSet<ProductTarget> TargetsDbSet => CurrentContext.Targets;
        private void LoadDbs()
        {
            CurrentContext.Employees.Load();
            CurrentContext.Targets.Load();
            CurrentContext.Products.Load();
            CurrentContext.CompanyTasks.Load();
        }
    }
}
