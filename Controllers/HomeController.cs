using Books.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Books.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Информация о книгах";
            var books = MemoryDb.Books;
            return View(books);
        }

		[HttpGet]
		public IActionResult Create()
		{
			Book book = new Book();
			return View(book);
		}

		[HttpPost]
		public IActionResult Create(Book book)
		{
			Book book_to_add = null;
			foreach (Book b in MemoryDb.Books)
			{
				if (b.Year == book.Year && b.Title == book.Title)
				{
					book_to_add = b;
				}
			}
			if (book_to_add == null && ModelState.IsValid)
			{
				MemoryDb.Books.Add(book);
				return RedirectToAction("Index");
			}
			else
				return View();
		}

		public IActionResult Edit(Book book)
		{
			return View("Create", book);
		}


		public IActionResult Delete(Book book)
		{
			Book book_to_delete = new Book(); 
			foreach (Book b in MemoryDb.Books) { 
				if (b.Year == book.Year	&& b.Title == book.Title)
				{
					book_to_delete = b;
				}
			}
			MemoryDb.Books.Remove(book_to_delete);
			return RedirectToAction(nameof(Index));
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}