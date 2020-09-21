using EmployeeBlazor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployee.Web.Services
{
    public interface IEmployeeServices
    {
        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployeeById(int EmployeeId);
    }
}
