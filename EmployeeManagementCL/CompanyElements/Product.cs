using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCL
{
    public class Product : IDbElement
    {
        /// <summary>
        /// ID of a product
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Name of a product
        /// </summary>
        [MaxLength(30)]
        public string Name { get; set; }
        /// <summary>
        /// Description of a product
        /// </summary>
        [MaxLength(100)]
        public string Description { get; set; }
        /// <summary>
        /// ProductTarget's ID of a product
        /// </summary>
        public int? TargetID { get; set; }
        /// <summary>
        /// Constructs an empty product
        /// </summary>
        public Product() { }
        /// <summary>
        /// Construct a product
        /// </summary>
        /// <param name="name">Name of a product</param>
        /// <param name="description">Description of a product</param>
        /// <param name="target">ProductTarget's ID</param>
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
