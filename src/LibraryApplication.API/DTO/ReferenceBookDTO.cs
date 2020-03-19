using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.DTO
{
    public class ReferenceBookDTO
    {
        public string Title { set; get; }
        public string Author { set; get; }
        public int Pages { set; get; }
        public string CategoryName { set; get; }

        public ReferenceBookDTO(string title, string author, int pages, string categoryName)
        {
            Title = title;
            Author = author;
            Pages = pages;
            CategoryName = categoryName;
        }
    }
}
