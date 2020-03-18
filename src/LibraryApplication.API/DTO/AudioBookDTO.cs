using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API.DTO
{
    public class AudioBookDTO
    {
        public string Title { get; set; }
        public int RunTimeMinutes { set; get; }
        public string CategoryName { set; get; }

        public AudioBookDTO(string title, int runTimeMinutes, string categoryName)
        {
            Title = title;
            RunTimeMinutes = runTimeMinutes;
            CategoryName = categoryName;
        }
    }
}
