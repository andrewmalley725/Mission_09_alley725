using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission_09_alley725.Infrastructure;

namespace Mission_09_alley725.Models
{
	public class SessionCart : Cart
	{

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();

            cart.Session = session;

            return cart;
        }

		[JsonIgnore]
		public ISession Session { get; set; }

        public override void addBook(LineItem b)
        {
            base.addBook(b);
            Session.SetJson("Cart", this);
        }

        public override void removeBook(LineItem b)
        {
            base.removeBook(b);
            Session.SetJson("Cart", this);
        }

        public override void emptyCart()
        {
            base.emptyCart();
            Session.Remove("Cart");
        }
    }
}

