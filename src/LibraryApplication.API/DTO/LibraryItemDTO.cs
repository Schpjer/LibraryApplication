using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.DTO
{
    public class LibraryItemDTO
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string CategoryName { set; get; }
        public string Type { set; get; }

        public LibraryItemDTO(int id, string title, string categoryName, string type)
        {
            Id = id;
            Title = title;
            CategoryName = categoryName;
            Type = type;
        }
    }
}
