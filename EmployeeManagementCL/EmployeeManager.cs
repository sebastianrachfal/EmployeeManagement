using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Dynamic;
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
        public void AddItem(DbType type, IDbElement element)
        {
            switch (type)
            {
                case DbType.Employee:
                    //EmployeesDbSet.Remove(EmployeesDbSet.Find(index));
                    break;
                case DbType.Task:
                    //TasksDbSet.Remove(TasksDbSet.Find(index));
                    break;
                case DbType.Product:
                    //ProductsDbSet.Remove(ProductsDbSet.Find(index));
                    break;
                case DbType.Target:
                    TargetsDbSet.Add((ProductTarget)element);
                    break;
            }
            CurrentContext.SaveChanges();
        }
        public void EditItem(DbType type, int index, IDbElement element)
        {
            switch (type)
            {
                case DbType.Employee:
                    //EmployeesDbSet.Remove(EmployeesDbSet.Find(index));
                    break;
                case DbType.Task:
                    //TasksDbSet.Remove(TasksDbSet.Find(index));
                    break;
                case DbType.Product:
                    //ProductsDbSet.Remove(ProductsDbSet.Find(index));
                    break;
                case DbType.Target:
                    var result = TargetsDbSet.SingleOrDefault(x => x.ID == index);
                    if(result != null)
                        result.Name = ((ProductTarget)element).Name;
                    CurrentContext.Entry(TargetsDbSet.Find(index)).State = EntityState.Modified;
                    break;
            }
            CurrentContext.SaveChanges();
        }
    }
}
