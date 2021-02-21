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
}
