using System;
using System.Collections.Generic;
using System.Linq;

namespace Mission_09_alley725.Models
{
	public class Cart
	{
		public List<LineItem> Books { get; set; } = new List<LineItem>();

		public double getSubtotal()
		{
			double total = 0;

			foreach (LineItem b in this.Books)
			{
				total += b.book.Price * b.quantity;
			}

			return total;
		}

		public int getNumItems()
		{
			int total = 0;

			foreach (LineItem b in this.Books)
			{
				total += b.quantity;
			}

			return total;
		}

		public void addBook(LineItem b)
		{
			this.Books.Add(b);
		}

	}

	public class LineItem
	{
		public int quantity { get; set; }
		public Book book { get; set; }
	}

		
	
}

