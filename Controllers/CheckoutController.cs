using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission_09_alley725.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission_09_alley725.Controllers
{
    public class CheckoutController : Controller
    {
        private ICheckoutRepository _db { get; set; }

        private Cart cart { get; set; }

        public CheckoutController(ICheckoutRepository temp, Cart c)
        {
            _db = temp;

            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Checkout());
        }

        [HttpPost]
        public IActionResult Checkout(Checkout c)
        {
            if (cart.Books.Count() == 0)
            {
                ModelState.AddModelError("", "Cart is empty");
            }

            if (ModelState.IsValid)
            {
                c.Lines = cart.Books.ToArray();

                _db.SaveInfo(c);

                cart.emptyCart();

                return RedirectToPage("/CheckoutComplete");
            }

            else
            {
                return View();
            }
        }
    }
}

