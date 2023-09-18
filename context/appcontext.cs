using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wasly.net.Models;

namespace Wasly.context
{
    //class appuser : idenityuser{}
    public class appcontext : IdentityDbContext//<appuser>
    {
        public appcontext()
        {

        }
        public appcontext(DbContextOptions<appcontext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=wasalydb;Integrated Security=true;TrustServerCertificate=true");
        }
        public DbSet<Order>Orders { get; set; } 

    }
}
