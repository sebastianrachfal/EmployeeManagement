using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCL
{
    public class Employee : IDbElement
    {
        public int ID { get; set; }
        public EmployeeType Type { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        public CompanyTask Task { get; set; }
        public Employee() { }
        public Employee(string firstName, string lastName, string city, EmployeeType type, CompanyTask task = null)
        {
            Checks.CheckLength(firstName, "First Name", 0, 30);
            Checks.CheckLength(lastName, "Last Name", 0, 30);
            Checks.CheckLength(city, "City", 0, 30);
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Type = type;
            Task = task;
        }
    }
}
