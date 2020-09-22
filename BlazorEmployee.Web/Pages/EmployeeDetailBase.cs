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

        protected string BtnTxt = "Hide footer";

        protected string HidefooterClass = string.Empty;

        public Employee Employee { get; set; } 

        [Parameter]
        public string id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = new Employee();
            id = id ?? "1";
            Employee =  await EmployeeServices.GetEmployeeById(int.Parse(id)) ;             
        }

        protected void BtnTxt_click()
        {
            if (BtnTxt== "Show footer")
            {
                HidefooterClass = string.Empty;
                BtnTxt = "Hide footer";
            }
            else
            {
                HidefooterClass = "Hidefooter";
                BtnTxt = "Show footer";
            }
            
            
        }

    }
}
