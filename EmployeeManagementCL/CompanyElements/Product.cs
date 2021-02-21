using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCL
{
    public class Product : IDbElement
    {
        public int ID { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public int? TargetID { get; set; }
        public Product() { }
        public Product(string name, string description, int? target = null)
        {
            Checks.CheckLength(name, "Name", 0, 30);
            Checks.CheckLength(description, "Description", 0, 100);
            Name = name;
            Description = description;
            TargetID = target;
        }
    }
}
