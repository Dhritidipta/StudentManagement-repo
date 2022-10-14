using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.WebApp.Validation
{
    public class CheckSelctedValue : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int number;
            //get the selected value and according to the condition to check whether the value is valid or not.
            //try to convert the selected value to int.
            bool success = int.TryParse(value.ToString(), out number);
            //if the number is 0, it means user select the first item.
            if (success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
