using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.LibrayAggregate
{
    public class ReferenceBook : LibraryItem
    {
        [Required(ErrorMessage = "Author is Required")]
        public string Author { set; get; }
        [Required(ErrorMessage = "Pages is Required")]
        public int Pages { set; get; }
        public ReferenceBook()
        {
            Type = nameof(ReferenceBook);
            IsBorrowable = false;
        }
    }
}
