using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.Models
{
    public class Person
    {
        [Required(ErrorMessage = "{0} can't be empty or null")]//0 indicate PersonName. Use [Display] when you want to have a different display name.
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength =3, ErrorMessage = "{0} should be between {2} and {1} characters long.")]
        [RegularExpression("^[A-Za-z .]", ErrorMessage ="{0} should contain only alphabets, space and dot(.).")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid {0} format.")]
        [Required(ErrorMessage = "{0} should not be blank.")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Invalid {0} format.")]
        [ValidateNever]//when you want to temporaily exclude from validation
        public string? Phone { get; set; }

        [Required(ErrorMessage ="{0} can't be blank.")]
        
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} can't be blank.")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match.")]
        [Display(Name = "Re-enter Password")]
        public string? ConfirmPassword { get; set; }

        [Range(0,999.99, ErrorMessage = "{0} should be between ${1} and ${2}.")]
        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Person object - Person name:" +
                $"{PersonName}, Email: {Email}, Phone: {Phone}," +
                $"Password: {Password}, Confirm Password: {ConfirmPassword}," +
                $"Price: {Price}";
        }

    }
}
