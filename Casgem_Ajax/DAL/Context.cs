using Microsoft.EntityFrameworkCore;

namespace Casgem_Ajax.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          optionsBuilder.UseSqlServer("server=BURAK\\SQLEXPRESS;database= DbAjax;integrated security = true");
        }
        public DbSet<Customer> Customers { get; set; }   

    }
}
