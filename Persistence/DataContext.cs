using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataContext : DbContext
    {

        public DataContext()
        {

        }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Person>()
                .HasData(
                    new Person() { Id = 1, Name = "Evripidis", LastName = "Katsianos", Email = "ekatsianos@gmail.com" },
                    new Person() { Id = 2, Name = "Giannis", LastName = "papadopoulos", Email = "gpapadopoulos.com" },
                    new Person() { Id = 3, Name = "Ilias", LastName = "Papas", Email = "ipapas@gmail.com" }
                );

            builder.Entity<Person>()
                .Property(x => x.Name)
                .HasMaxLength(100).IsRequired();

            builder.Entity<Person>()
                .Property(x => x.LastName)
                .HasMaxLength(100).IsRequired();

            builder.Entity<Person>()
                .Property(x => x.Email)
                .HasMaxLength(200).IsRequired();
        }

        public DbSet<Person> persons { get; set; }
    }
}
