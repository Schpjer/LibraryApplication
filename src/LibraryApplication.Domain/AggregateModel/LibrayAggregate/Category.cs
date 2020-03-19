using LibraryApplication.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryApplication.Domain.AggregateModel.LibrayAggregate
{
    public class Category: Entity
    {
        [Required(ErrorMessage = "Category is required")]
        public string CategoryName { set; get; }
    }
}
