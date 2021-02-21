using System.Data.Entity;

namespace EmployeeManagementCL
{
    public class CompanyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CompanyTask> CompanyTasks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTarget> Targets { get; set; }
    }
}
