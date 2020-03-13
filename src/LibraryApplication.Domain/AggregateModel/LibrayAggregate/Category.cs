using LibraryApplication.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.LibrayAggregate
{
    public class Category: Entity
    {
        public string CategoryName { set; get; }
    }
}
