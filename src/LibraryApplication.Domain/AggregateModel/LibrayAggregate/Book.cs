using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.LibrayAggregate
{
    public class Book : LibraryItem
    {
        [Required]
        public string Author { set; get; }
        [Required]
        public int Pages { set; get; }
        public Book()
        {
            Type = nameof(Book);
            IsBorrowable = true;
        }
    }
}
