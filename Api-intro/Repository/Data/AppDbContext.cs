using Domain.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FullName = "Chinara Ibadova",
                    Address = "Lokbatan",
                    Age = 22
                },
                new Employee
                {
                    Id = 2,
                    FullName = "Konul Ibrahimova",
                    Address = "Bayil",
                    Age = 27
                },
                new Employee
                {
                    Id = 3,
                    FullName = "Roya Meherremova",
                    Address = "Sumqayit",
                    Age = 27
                });
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id =1,
                    Name = "Azerbaijan"
                },
                new Country
                {
                    Id = 2,
                    Name = "Turkiye"
                },
                new Country
                {
                    Id = 3,
                    Name = "England"
                });

            /*new EmployeeConfiguration().Configure(modelBuilder.Entity<Employee>());*/
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
