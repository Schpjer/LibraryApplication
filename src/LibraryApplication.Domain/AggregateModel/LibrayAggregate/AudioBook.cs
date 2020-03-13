using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.LibrayAggregate
{
    public class AudioBook : LibraryItem
    {
        public AudioBook()
        {
            Type = nameof(AudioBook);
            IsBorrowable = true;
        }
    }
}
