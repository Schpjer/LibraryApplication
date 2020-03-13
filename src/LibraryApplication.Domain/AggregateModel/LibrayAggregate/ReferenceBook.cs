using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.LibrayAggregate
{
    public class ReferenceBook : LibraryItem
    {
        public ReferenceBook()
        {
            Type = nameof(AudioBook);
            IsBorrowable = false;
        }
    }
}
