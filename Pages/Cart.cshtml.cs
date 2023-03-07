using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission_09_alley725.Infrastructure;
using Mission_09_alley725.Models;

namespace Mission_09_alley725.Pages
{
    public class CartModel : PageModel
    {
        private IBookstoreRepository _repo;

        public CartModel(IBookstoreRepository temp)
        {
            _repo = temp;
        }

        public Cart MyCart { get; set; }

        public void OnGet()
        {
            MyCart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookid, int quantity = 1)
        {
            Book book = _repo.Books.FirstOrDefault(x => x.BookId == bookid);

            MyCart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            var item = new LineItem { book = book, quantity = quantity };

            MyCart.addBook(item);

            HttpContext.Session.SetJson("cart", MyCart);

            return RedirectToPage(MyCart);
        }
    }
}

