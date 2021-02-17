using System;
using System.Collections.Generic;
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
            CurrentContext.Targets.Add(new ProductTarget() { Name = "Poland" });
            CurrentContext.SaveChanges();
            Console.WriteLine("added");
        }
    }
}
