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
    public interface IDbElement
    {
        [Key]
        [Index(IsUnique = true)]
        int ID { get; set; }
    }
    public class CompanyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CompanyTask> CompanyTasks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTarget> Targets { get; set; }
    }
    public class Employee : IDbElement
    {
        public int ID { get; set; }
        public EmployeeType Type { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        public List<CompanyTask> Tasks { get; set; }
    }

    public class CompanyTask : IDbElement
    {
        public int ID { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set; }
        public bool Finished { get; set; }
        public int ProductID { get; set; }
    }

    public class Product : IDbElement
    {
        public int ID { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public int TargetID { get; set; }
    }
    
    public class ProductTarget : IDbElement
    {
        public int ID { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
