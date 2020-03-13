using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using LibraryApplication.Domain.SeedWork;
using System;

namespace LibraryApplication.Domain
{
    public abstract class LibraryItem : Entity
    {
        public Category Category { set; get; }
        public string Title { set; get; }
        public string Author { set; get; }
        public int Pages { set; get; }
        public int RunTimeMinutes { set; get; }
        public bool IsBorrowable { set; get; }
        public string Borrower { set; get; }
        public DateTime BorrowDate { set; get; }
        public string Type { set; get; }
    }
}
