using Microsoft.AspNetCore.Mvc;
using Mission_9.Models;
using Mission_9.Models.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_9.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        
        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookGenre, int pageNum = 1)
        {
            int pageSize = 5;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookGenre || bookGenre == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookGenre == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == bookGenre).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
