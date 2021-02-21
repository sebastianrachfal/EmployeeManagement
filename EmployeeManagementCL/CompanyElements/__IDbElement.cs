using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementCL
{
    /// <summary>
    /// Interface for types of elements in database
    /// </summary>
    public interface IDbElement
    {
        [Key]
        [Index(IsUnique = true)]
        int ID { get; set; }
    }
}
