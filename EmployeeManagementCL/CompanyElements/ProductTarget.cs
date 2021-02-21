using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCL
{
    public class ProductTarget : IDbElement
    {
        /// <summary>
        /// ID of a target
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Name of a target
        /// </summary>
        [MaxLength(30)]
        public string Name { get; set; }
        /// <summary>
        /// Constructs an empty target
        /// </summary>
        public ProductTarget() { }
        /// <summary>
        /// Constructs a new ProductTarget
        /// </summary>
        /// <param name="name">Name of the target</param>
        public ProductTarget(string name)
        {
            Checks.CheckLength(name, "Name", 0, 30);
            Name = name;
        }
    }
}
