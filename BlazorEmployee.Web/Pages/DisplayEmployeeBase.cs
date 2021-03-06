﻿using EmployeeBlazor.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployee.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {

        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        protected async Task Checkchange(ChangeEventArgs args)
        {
            await OnEmployeeSelection.InvokeAsync((bool)args.Value);
        }
    }
}
