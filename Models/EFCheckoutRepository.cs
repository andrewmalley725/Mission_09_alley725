using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mission_09_alley725.Models
{
    public class EFCheckoutRepository : ICheckoutRepository
    {
        private BookstoreContext _db;

        public EFCheckoutRepository(BookstoreContext temp)
        {
            _db = temp;
        }

        public IQueryable<Checkout> Checkout => _db.CheckoutInfo.Include(x => x.Lines).ThenInclude(x => x.book);

        public void SaveInfo(Checkout c)
        {
            _db.AttachRange(c.Lines.Select(x => x.book));

            if (c.CheckoutId == 0)
            {
                _db.CheckoutInfo.Add(c);
            }

            _db.SaveChanges();
        }
    }
}

