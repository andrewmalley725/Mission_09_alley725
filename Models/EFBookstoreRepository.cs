using System;
using System.Linq;

namespace Mission_09_alley725.Models
{
	public class EFBookstoreRepository : IBookstoreRepository
	{
        private BookstoreContext _db { get; set; }

		public EFBookstoreRepository(BookstoreContext db)
		{
			_db = db;
		}

		public IQueryable<Book> Books => _db.Books;
	}	
}

