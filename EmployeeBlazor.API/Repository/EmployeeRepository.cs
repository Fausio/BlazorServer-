using EmployeeBlazor.API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBlazor.Model;
using EmployeeBlazor.API.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmployeeBlazor.API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext db;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            this.db = applicationDbContext;
        }
        public async Task<Employee> AddModel(Employee employee)
        {
            EntityEntry<Employee> result = await db.Employee.AddAsync(employee);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteModel(int employeeId)
        { 
            var  result = await GetAllModelById(employeeId);

            if (result != null)
            {
                db.Remove(result);
                db.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<List<Employee>> GetAllModel()
        {
            return await db.Employee.ToListAsync();
        }

        public async  Task<Employee> GetAllModelByEmail(string EmployeeEmail)
        {
            Task<Employee> result = db.Employee.FirstOrDefaultAsync(x => x.Email == EmployeeEmail);
            if (result != null)
            {
                return await result;
            }
            else
            {
                return null;
            }
        }

        public async Task<Employee> GetAllModelById(int employeeId)
        {
            Task<Employee> result = db.Employee.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            if (result != null)
            {
                return await result;
            }
            else
            {
                return null;
            }
        }

        public async Task<Employee> UpdateModel(Employee employee)
        {
            Employee result =await GetAllModelById(employee.EmployeeId);

            if (result != null)
            {
                result.EmployeeId = employee.EmployeeId;
                result.DateOfBrith = employee.DateOfBrith;
                result.DepartmentId = employee.DepartmentId;
                result.Email = employee.Email;
                result.FirstName = employee.FirstName;
                result.Gender = employee.Gender;
                result.LastName = employee.LastName;
                result.PhotoPath = employee.PhotoPath;

                await db.SaveChangesAsync();
                return result;
            }
            else
            {
                return null;
            }


        }
    }
}
