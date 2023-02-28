using System;
using System.Linq;

namespace Mission_09_alley725.Models.ViewModels
{
	public class BookViewModel
	{
		public IQueryable<Book> Books { get; set; }

		public PageInfo PageInfo { get; set; }
	}
}

