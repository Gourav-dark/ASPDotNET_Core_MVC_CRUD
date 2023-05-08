using ASPDotNET_Core_MVC_CRUD.Models.DomainModel;
using Microsoft.EntityFrameworkCore;
namespace ASPDotNET_Core_MVC_CRUD.DataContext
{
    public class MvcDbContext : DbContext
    {
        public MvcDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee>  Employees { get; set; }
    }
}
