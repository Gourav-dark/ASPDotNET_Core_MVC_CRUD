namespace ASPDotNET_Core_MVC_CRUD.Models
{
    public class UpdateEmployeeViewModel
    {
        public Guid EmpId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public long Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
    }
}
