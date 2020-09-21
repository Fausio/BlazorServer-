﻿using EmployeeBlazor.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorEmployee.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeServices EmployeeServices { get; set; }
        public List<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            
        }  
    }
}
