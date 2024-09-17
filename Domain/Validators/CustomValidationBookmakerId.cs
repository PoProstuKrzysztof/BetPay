﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Validators;

public class CustomValidationsBookmakerId : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)

    {
        if (value != null)

        {
            int bookmakerId = (int)value;

            if (bookmakerId > 0)

            {
                return ValidationResult.Success;
            }
        }

        return new ValidationResult("Choose bookmaker");
    }
}