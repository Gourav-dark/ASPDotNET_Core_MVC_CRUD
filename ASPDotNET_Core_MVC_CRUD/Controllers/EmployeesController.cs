using ASPDotNET_Core_MVC_CRUD.DataContext;
using ASPDotNET_Core_MVC_CRUD.Models;
using ASPDotNET_Core_MVC_CRUD.Models.DomainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPDotNET_Core_MVC_CRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MvcDbContext DbContext;
        public EmployeesController(MvcDbContext dbContext)
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
            await DbContext.Employees.AddAsync(employee);
            await DbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
            var employee = await DbContext.Employees.FirstOrDefaultAsync(x => x.EmpId == Id);
            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    EmpId = employee.EmpId,
                    Fname = employee.Fname,
                    Lname = employee.Lname,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    Department = employee.Department,
                    DateOfBirth = employee.DateOfBirth
                };
                return await Task.Run(()=> View("View",viewModel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            var employee = await DbContext.Employees.FindAsync(model.EmpId);
            if(employee != null)
            {
                employee.Fname = model.Fname;
                employee.Lname = model.Lname;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.Department = model.Department;
                employee.DateOfBirth = model.DateOfBirth;

                await DbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = await DbContext.Employees.FindAsync(model.EmpId);
            if(employee != null)
            {
                DbContext.Employees.Remove(employee);
                await DbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
