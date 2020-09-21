using BlazorEmployee.Web.Services;
using EmployeeBlazor.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployee.Web.Pages
{
    public class EmployeeDetailBase : ComponentBase
    {
        [Inject]
        public IEmployeeServices EmployeeServices { get; set; }

        public Employee Employee { get; set; } 

        [Parameter]
        public string id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = new Employee();
            Employee =  await EmployeeServices.GetEmployeeById(int.Parse(id)) ;             
        }

    }
}
