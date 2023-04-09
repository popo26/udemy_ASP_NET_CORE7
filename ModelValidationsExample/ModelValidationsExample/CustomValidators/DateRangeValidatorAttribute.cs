using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Serialization;

namespace ModelValidationsExample.CustomValidators
{
    public class DateRangeValidatorAttribute: ValidationAttribute //suffix "Attribute" is not necessary but recommended
    {
        //property
        public string OtherPropertyName { get; set; }

        //constructor
        public DateRangeValidatorAttribute(string otherPropertyName)
        { 
            OtherPropertyName = otherPropertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                //get to_date
                DateTime to_date = Convert.ToDateTime(value);

                //get from_date
                //using 'Reflection concept' - when you want to access property values or invoke the methods indirectly
                //from the objects which you are getting dynamically.
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                if (otherProperty != null)
                {
                    DateTime from_date = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                    if (from_date > to_date)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName });
                    }
                    else 
                    {
                        return ValidationResult.Success;
                    }
                }
                return null;
            }
            return null;
        }
    }
}
