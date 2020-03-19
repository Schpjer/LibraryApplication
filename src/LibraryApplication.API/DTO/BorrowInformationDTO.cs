using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.DTO
{
    public class BorrowInformationDTO
    {
        public string Title { set; get; }
        public DateTime BorrowDate { set; get; }
        public string Borrower { set; get; }
        public string BorrowMessage { set; get; }

        public BorrowInformationDTO(string title, DateTime borrowDate, string borrower)
        {
            Title = title;
            BorrowDate = borrowDate;
            Borrower = borrower;
        }
    }
}
