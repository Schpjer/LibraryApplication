using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.LibrayAggregate
{
    public class Dvd : LibraryItem 
    {
        [Required]
        public int RunTimeMinutes { set; get; }
        public Dvd()
        {
            Type = nameof(Dvd);
            IsBorrowable = true;
        }
    }
}
