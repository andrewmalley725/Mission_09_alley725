using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Mission_09_alley725.Models
{
	public class Checkout
	{
		[Key]
		[BindNever]
		public int CheckoutId { get; set; }

		[BindNever]
		public ICollection<LineItem> Lines { get; set; }

		[Required( ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter an email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a state.")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a city.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter an address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a zipcode.")]
        public string Zip { get; set; }
    }
}

