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

        public Cart MyCart { get; set; }

        public CartModel(IBookstoreRepository temp, Cart c)
        {
            _repo = temp;
            MyCart = c;
        }

        [BindProperty]
        public int Quantity { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnURL)
        {
            ReturnUrl = returnURL ?? "/";
        }

        public IActionResult OnPost(int bookid, string returnURL)
        {
            Book book = _repo.Books.FirstOrDefault(x => x.BookId == bookid);

            

            var item = new LineItem { book = book, quantity = Quantity };

            if (MyCart.getBooks().Contains(item.book.Title))
            {
                MyCart.findBook(item.book.Title).quantity += item.quantity;
            }

            else
            {
                MyCart.addBook(item);
            }

            

            return RedirectToPage(new { ReturnUrl = returnURL });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            MyCart.removeBook(MyCart.Books.First(x => x.book.BookId == bookId));

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}

