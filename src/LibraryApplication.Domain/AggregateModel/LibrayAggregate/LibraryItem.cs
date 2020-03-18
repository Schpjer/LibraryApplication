using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using LibraryApplication.Domain.SeedWork;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryApplication.Domain
{
    public abstract class LibraryItem : Entity
    {
        public Category Category { set; get; }
        public int categoryId {set; get;}
        [Required(ErrorMessage = "Title is required")]
        public string Title { set; get; }
        public bool IsBorrowable { set; get; }
        public string Borrower { set; get; }
        public DateTime BorrowDate { set; get; }
        public string Type { set; get; }
    }
}
