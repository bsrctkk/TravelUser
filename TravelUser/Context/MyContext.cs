using Microsoft.EntityFrameworkCore;
using TravelUser.Models.ORM;

namespace TravelUser.Context
{
    public class MyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=TravelUserDb; Trusted_Connection=True");
        }
       public virtual DbSet<WebUser> WebUsers { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
