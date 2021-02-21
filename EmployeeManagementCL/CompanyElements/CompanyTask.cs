using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCL
{
    public class CompanyTask : IDbElement
    {
        /// <summary>
        /// ID of a task
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Name of a task
        /// </summary>
        [MaxLength(30)]
        public string Name { get; set; }
        /// <summary>
        /// Description of a task
        /// </summary>
        [MaxLength(100)]
        public string Description { get; set; }
        /// <summary>
        /// Creation date of a task
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Deadline of a task
        /// </summary>
        public DateTime Deadline { get; set; }
        /// <summary>
        /// Status of a task
        /// </summary>
        public bool Finished { get; set; }
        /// <summary>
        /// Product's ID of a task
        /// </summary>
        public int? ProductID { get; set; }
        /// <summary>
        /// Constructs an empty task with creation date set to the moment of creation
        /// </summary>
        public CompanyTask() {
            CreatedAt = DateTime.Now;
        }
        /// <summary>
        /// Constructs a task with creation date set to the moment of creation
        /// </summary>
        /// <param name="name">Name of a task</param>
        /// <param name="desc">Description of a task</param>
        /// <param name="deadline">Deadline of a task</param>
        /// <param name="product">Product's ID of a task</param>
        /// <param name="finished">Status of a task</param>
        public CompanyTask(string name, string desc, DateTime deadline, int? product = null, bool finished = false) : this()
        {
            Checks.CheckLength(name, "Name", 0, 30);
            Checks.CheckLength(desc, "Description", 0, 100);
            if (deadline < CreatedAt) throw new ArgumentException("Deadline can't be lesser than creation date.");
            Name = name;
            Description = desc;
            Deadline = deadline;
            ProductID = product;
            Finished = finished;
        }
    }
}
