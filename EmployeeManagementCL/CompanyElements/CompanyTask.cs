using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCL
{
    public class CompanyTask : IDbElement
    {
        public int ID { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set; }
        public bool Finished { get; set; }
        public int? ProductID { get; set; }
        public CompanyTask() { }
        public CompanyTask(string desc, DateTime deadline, int? product = null, bool finished = false)
        {
            Checks.CheckLength(desc, "Description", 0, 100);
            Description = desc;
            CreatedAt = DateTime.Now;
            Deadline = deadline;
            ProductID = product;
            Finished = finished;
        }
    }
}
