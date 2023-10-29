using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseImplement
{
    public class AutocenterDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql(@"
                    Host=localhost;
                    Port=5432;
                    Database=Autocenter;
                    Username=postgres;
                    Password=root;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Person> Persons { set; get; }
        public virtual DbSet<Transport> Transports { set; get; }
    }
}
