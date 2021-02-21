using System.Data.Entity;

namespace EmployeeManagementCL
{
    internal class CompanyContext : DbContext
    {
        internal DbSet<Employee> Employees { get; set; }
        internal DbSet<CompanyTask> CompanyTasks { get; set; }
        internal DbSet<Product> Products { get; set; }
        internal DbSet<ProductTarget> Targets { get; set; }
    }
}
