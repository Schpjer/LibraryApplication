using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.LibrayAggregate
{
    public class AudioBook : LibraryItem
    {
        [AudioBookRequirement]
        public int RunTimeMinutes { set; get; }
        public AudioBook()
        {
            Type = nameof(AudioBook);
            IsBorrowable = true;
        }
    }
    // A way to validate that runtimeminutes is above 0 when you update or create a audiobook
    public class AudioBookRequirementAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var audioBook = (AudioBook)validationContext.ObjectInstance;
            if (audioBook.RunTimeMinutes > 0)
            {
                return ValidationResult.Success;
            }
            var runTimeMinutesString = value as String;
            return string.IsNullOrEmpty(runTimeMinutesString) ? new ValidationResult("Value is required.") : ValidationResult.Success;
        }
    }
   
}
