using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.DTO
{
    public class BookDTO
    {
        public string Title { set; get; }
        public int Pages { set; get; }
        public string Auhtor { set; get; }
        public string CategoryName { set; get; }

        public BookDTO(string title, int pages, string auhtor, string categoryName)
        {
            Title = title;
            Pages = pages;
            Auhtor = auhtor;
            CategoryName = categoryName;
        }
    }
}
