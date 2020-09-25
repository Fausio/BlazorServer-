using EmployeeBlazor.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorEmployee.Web.Services;

namespace BlazorEmployee.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeServices EmployeeServices { get; set; }
        public List<Employee> Employees { get; set; }

        public bool Showfooter { get; set; }

        protected int SelectedEmployees { get; set; }

        protected void EmployeeSelected(bool IsSelected)
        {
            if (IsSelected)
            {
                SelectedEmployees++;
            }
            else
            {
                SelectedEmployees--;
            }
        }
        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeServices.GetEmployees()).ToList();
        }  
    }
}
