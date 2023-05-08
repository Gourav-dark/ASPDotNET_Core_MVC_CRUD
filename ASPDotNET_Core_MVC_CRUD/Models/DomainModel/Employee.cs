using System.ComponentModel.DataAnnotations;

namespace ASPDotNET_Core_MVC_CRUD.Models.DomainModel
{
    public class Employee
    {
        [Key]
        public Guid EmpId { get; set; }
        public string Fname { get; set; }=String.Empty;
        public string Lname { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public long Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; } = String.Empty;
    }
}
