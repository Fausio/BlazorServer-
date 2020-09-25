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

        [Parameter]
        public Employee Employee { get; set; } = new Employee();

        public int Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await employeeServices.GetEmployeeById(Id);
        }


    }
}
