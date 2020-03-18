using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.LibrayAggregate
{
    public class Dvd : LibraryItem 
    {
        [DvdRequirement]
        public int RunTimeMinutes { set; get; }
        public Dvd()
        {
            Type = nameof(Dvd);
            IsBorrowable = true;
        }
    }
    public class DvdRequirementAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var audioBook = (Dvd)validationContext.ObjectInstance;
            if (audioBook.RunTimeMinutes > 0)
            {
                return ValidationResult.Success;
            }
            var runTimeMinutesString = value as String;
            return string.IsNullOrEmpty(runTimeMinutesString) ? new ValidationResult("Value is required.") : ValidationResult.Success;
        }
    }
}
