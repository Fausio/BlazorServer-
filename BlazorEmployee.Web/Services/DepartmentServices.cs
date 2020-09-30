using EmployeeBlazor.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorEmployee.Web.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly HttpClient httpClient;
        public DepartmentServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Department> GetDepartmentById(int EmployeeId)
        {
            return await httpClient.GetJsonAsync<Department>($"api/Department/{EmployeeId}");
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await httpClient.GetJsonAsync<List<Department>>("api/Department");
        }
    }
}
