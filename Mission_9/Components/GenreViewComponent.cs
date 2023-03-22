using Microsoft.AspNetCore.Mvc;
using Mission_9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_9.Components
{
    public class GenreViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public GenreViewComponent (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["bookGenre"];

            var genres = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(genres);
        }
    }
}
