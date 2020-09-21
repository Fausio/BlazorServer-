using EmployeeBlazor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Components;

namespace BlazorEmployee.Web.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly HttpClient httpClient;
        public EmployeeServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Employee>> GetEmployee()
        {
            return await httpClient.GetJsonAsync<List<Employee>>("api/Employee");
        }
    }
}
