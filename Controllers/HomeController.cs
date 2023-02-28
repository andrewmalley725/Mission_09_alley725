using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission_09_alley725.Models;
using Mission_09_alley725.Models.ViewModels;

namespace Mission_09_alley725.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookstoreRepository _repo { get; set; }

        public HomeController(ILogger<HomeController> logger, IBookstoreRepository repo)
        {
            _logger = logger;

            _repo = repo;
        }

        public IActionResult Index(int pageNum = 1)
        {

            int pageSize = 10;

            var data = new BookViewModel
            {
                Books = _repo.Books
                            .OrderBy(x => x.Title)
                            .Skip((pageNum - 1) * pageSize)
                            .Take(pageSize),

                PageInfo = new PageInfo
                {
                    NumBooks = _repo.Books.Count(),
                    CurrentPage = pageNum,
                    PageSize = pageSize
                }
            };

            ViewBag.Previous = data.PageInfo.CurrentPage - 1;

            ViewBag.Headers = new List<string> { "Title", "Author", "Publisher", "ISBN", "Classification", "Category", "Page Count", "Price"};

            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

