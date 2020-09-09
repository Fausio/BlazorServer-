using EmployeeBlazor.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace EmployeeBlazor.API.Model
{
    public class AppdbCtxt : DbContext
    {
        public AppdbCtxt(DbContextOptions<DbContext> options) : base(options)
        {

        }



        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> GetEmployee { get; set; }

     
    }
}
