using BlazorEmployee.Web.Services;
using EmployeeBlazor.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployee.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        protected IEmployeeServices employeeServices { get; set; }

        [Inject]
        protected IDepartmentServices departmentServices { get; set; }

        [Parameter]
        public Employee Employee { get; set; } = new Employee();

        [Parameter]
        public int Id { get; set; }


        public List<Department> Departments { get; set; } = new List<Department>();
          
        protected async override Task OnInitializedAsync()
        {
            Departments = await departmentServices.GetDepartments();          
            Employee = await employeeServices.GetEmployeeById(Id); 
        }


    }
}
