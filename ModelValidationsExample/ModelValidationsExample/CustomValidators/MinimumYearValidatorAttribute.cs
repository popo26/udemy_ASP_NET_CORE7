﻿using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        //property
        public int MinimumYear { get; set; } = 2000; //default value
        public string DefaultErrorMessage { get; set; } = "Year should not be less than {0}";

        //parameterless contstructor
        public MinimumYearValidatorAttribute()
        { 
        }

        //parameterize contstructor
        public MinimumYearValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= MinimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
                }
                else 
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
