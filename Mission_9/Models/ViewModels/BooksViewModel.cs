using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_9.Models.View_Models
{
    public class BooksViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
