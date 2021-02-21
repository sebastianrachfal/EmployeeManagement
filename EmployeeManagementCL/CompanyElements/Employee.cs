using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCL
{
    public class Employee : IDbElement
    {
        /// <summary>
        /// ID of an employee
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Type of an employee
        /// </summary>
        public EmployeeType Type { get; set; }
        /// <summary>
        /// First name of an employee
        /// </summary>
        [MaxLength(30)]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of an employee
        /// </summary>
        [MaxLength(30)]
        public string LastName { get; set; }
        /// <summary>
        /// City of an employee
        /// </summary>
        [MaxLength(30)]
        public string City { get; set; }
        /// <summary>
        /// CompanyTask's ID of an employee
        /// </summary>
        public int? TaskID { get; set; }
        /// <summary>
        /// Constructs an empty employee
        /// </summary>
        public Employee() { }
        /// <summary>
        /// Constructs an employee
        /// </summary>
        /// <param name="firstName">First name of an employee</param>
        /// <param name="lastName">Last name of an employee</param>
        /// <param name="city">City of an employee</param>
        /// <param name="type">EmployeeType of an employee</param>
        /// <param name="task">CompanyTask's ID of an employee</param>
        public Employee(string firstName, string lastName, string city, EmployeeType type, int? task = null)
        {
            Checks.CheckLength(firstName, "First Name", 0, 30);
            Checks.CheckLength(lastName, "Last Name", 0, 30);
            Checks.CheckLength(city, "City", 0, 30);
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Type = type;
            TaskID = task;
        }
    }
}
