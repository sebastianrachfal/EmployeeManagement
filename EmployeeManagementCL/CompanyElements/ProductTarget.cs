using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCL
{
    public class ProductTarget : IDbElement
    {
        public int ID { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public ProductTarget() { }
        public ProductTarget(string name)
        {
            Checks.CheckLength(name, "Name", 0, 30);
            Name = name;
        }
    }
}
