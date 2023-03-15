﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

		public virtual void addBook(LineItem b)
		{
			this.Books.Add(b);
		}

		public virtual void removeBook(LineItem b)
		{
			this.Books.RemoveAll(x => x.book.BookId == b.book.BookId);
		}

		public virtual void emptyCart()
		{
			this.Books.Clear();
		}



		public List<string> getBooks()
		{
			List<string> books = new List<string>();

			foreach (LineItem li in this.Books)
			{
				books.Add(li.book.Title);
			}

			return books;
		}

		public LineItem findBook(string book)
		{
			foreach (LineItem li in this.Books)
			{
				if (li.book.Title == book)
				{
					return li;
				}
			}
            return this.Books[0];
        }

	}

	public class LineItem
	{
		[Key]
		public int LineItemID { get; set; }
		public int quantity { get; set; }
		public Book book { get; set; }
	}

}

