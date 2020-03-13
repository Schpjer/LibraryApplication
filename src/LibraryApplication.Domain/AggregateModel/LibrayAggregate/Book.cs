using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.LibrayAggregate
{
    public class Book : LibraryItem
    {
        public Book()
        {
            Type = nameof(Book);
            IsBorrowable = true;
        }
    }
}
