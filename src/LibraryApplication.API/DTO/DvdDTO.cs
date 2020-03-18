using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.DTO
{
    public class DvdDTO
    {
        public string Title { set; get; }
        public int RunTimeMinutes { set; get; }
        public string CategoryName { set; get; }

        public DvdDTO(string title, int runTimeMinutes, string categoryName)
        {
            Title = title;
            RunTimeMinutes = runTimeMinutes;
            CategoryName = categoryName;
        }
    }
}
