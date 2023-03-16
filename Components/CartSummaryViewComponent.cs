using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mission_09_alley725.Models;

namespace Mission_09_alley725.Components
{
	public class CartSummaryViewComponent : ViewComponent
	{
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
