using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEmployee.Web.Pages
{
    public class CustomInputSelect<Tvalue> : InputSelect<Tvalue>
    {
        protected override bool TryParseValueFromString(string value, out Tvalue result, out string validationErrorMessage)
        {

            if (typeof(Tvalue) == typeof(int))
            {
                if (int.TryParse(value, out var resultInt))
                {
                    result = (Tvalue)(object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = $"The selected value {value} is not a valid number.";
                    return false;
                }
            }
            else
            {
                return base.TryParseValueFromString(value, out result, out validationErrorMessage);
            }


        }
    }
}
