using EmployeeBlazor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployee.Web.Services
{
    public interface IDepartmentServices
    {
        Task<List<Department>> GetDepartments();

        Task<Department> GetDepartmentById(int EmployeeId);
    }
}
