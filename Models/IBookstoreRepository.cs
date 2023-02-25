using System;
using System.Linq;

namespace Mission_09_alley725.Models
{
	public interface IBookstoreRepository
	{
		IQueryable<Book> Books { get; }
	}
}

