using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.LibrayAggregate
{
    public class AudioBook : LibraryItem
    {
        [Required]
        public int RunTimeMinutes { set; get; }
        public AudioBook()
        {
            Type = nameof(AudioBook);
            IsBorrowable = true;
        }
    }
}
