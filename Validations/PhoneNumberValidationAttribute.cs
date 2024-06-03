using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class PhoneNumberValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Phone number is required.");
        }

        string phoneNumber = value as string;

        if (phoneNumber == null)
        {
            return new ValidationResult("Invalid phone number format.");
        }

        // Regex to match 10 digits starting with 05, 056, or 059
        string pattern = @"^(05|056|059)\d{7}$";
        if (!Regex.IsMatch(phoneNumber, pattern))
        {
            return new ValidationResult("Phone number must be 10 digits long and start with 05, 056, or 059.");
        }

        return ValidationResult.Success;
    }
}
