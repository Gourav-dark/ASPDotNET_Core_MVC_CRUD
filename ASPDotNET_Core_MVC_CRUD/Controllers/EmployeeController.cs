using ASPDotNET_Core_MVC_CRUD.DataContext;
using ASPDotNET_Core_MVC_CRUD.Models;
using ASPDotNET_Core_MVC_CRUD.Models.DomainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPDotNET_Core_MVC_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MvcDbContext DbContext;
        public EmployeeController(MvcDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        //Data Display Function
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employeelist = await DbContext.Employees.ToListAsync();
            return View(employeelist);
        }
        //Data Store Function
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                EmpId = Guid.NewGuid(),
                Fname = addEmployeeRequest.Fname,
                Lname = addEmployeeRequest.Lname,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                Department = addEmployeeRequest.Department,
            };
            await this.DbContext.Employees.AddAsync(employee);
            await this.DbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }
    }
}
