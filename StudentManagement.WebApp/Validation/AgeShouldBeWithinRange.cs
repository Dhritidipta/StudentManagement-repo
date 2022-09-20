using StudentManagement.WebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.WebApp.Validation
{
    public class AgeShouldBeWithinRange : ValidationAttribute
    {
        public AgeShouldBeWithinRange(int lower, int upper)
        {
            Lower = lower;
            Upper = upper;
        }

        public int Lower { get; private set; }
        public int Upper { get; private set; }

        public string GetErrorMessage() =>
            $"Age must be between {Lower} and {Upper}";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (StudentCreate)validationContext.ObjectInstance;
            
            if(student.Age < Lower && student.Age > Upper)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
