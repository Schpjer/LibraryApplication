using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.LibrayAggregate
{
    public class Dvd : LibraryItem 
    {
        public Dvd()
        {
            Type = nameof(Dvd);
            IsBorrowable = true;
        }
    }
}
