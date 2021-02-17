using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementCL
{
    public class CompanyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CompanyTask> CompanyTasks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTarget> Targets { get; set; }
    }

    public enum EmployeeType
    {
        Trainee,
        Staff,
        Management
    }
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public EmployeeType Type { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        public List<CompanyTask> Tasks { get; set; }
    }

    public class CompanyTask
    {
        [Key]
        public int TaskID { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set; }
        public bool Finished { get; set; }
        public int ProductID { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public int TargetID { get; set; }
    }
    
    public class ProductTarget
    {
        [Key]
        public int TargetID { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
