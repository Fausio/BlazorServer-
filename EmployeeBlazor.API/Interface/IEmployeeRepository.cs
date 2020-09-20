using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBlazor.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBlazor.API.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllModel();
        Task<Employee> GetAllModelById(int EmployeeId);
        Task<Employee> GetAllModelByEmail(string EmployeeEmail);
        Task<Employee> AddModel(Employee employee);
        Task<Employee> UpdateModel(Employee employee);
        void DeleteModel(int EmployeeId);
    }
}
