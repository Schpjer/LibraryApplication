using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.LibrayAggregate
{
    public class ReferenceBook : LibraryItem
    {
        [Required]
        public string Author { set; get; }
        [Required]
        public int Pages { set; get; }
        public ReferenceBook()
        {
            Type = nameof(AudioBook);
            IsBorrowable = false;
        }
    }
}
