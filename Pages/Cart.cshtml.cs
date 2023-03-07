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

        [BindProperty]
        public int Quantity { get; set; }

        public void OnGet()
        {
            MyCart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookid)
        {
            Book book = _repo.Books.FirstOrDefault(x => x.BookId == bookid);

            MyCart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            var item = new LineItem { book = book, quantity = Quantity };

            if (MyCart.getBooks().Contains(item.book.Title))
            {
                MyCart.findBook(item.book.Title).quantity += item.quantity;
            }

            else
            {
                MyCart.addBook(item);
            }

            HttpContext.Session.SetJson("cart", MyCart);

            return RedirectToPage(MyCart);
        }
    }
}

