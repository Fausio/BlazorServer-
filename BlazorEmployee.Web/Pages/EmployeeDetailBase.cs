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

       public  IEmployeeServices EmployeeServices { get; set; }

        public Employee Employee { get; set; }





        protected override  async Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

    }    
}
