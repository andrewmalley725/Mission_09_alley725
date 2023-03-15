using System;
using System.Linq;

namespace Mission_09_alley725.Models
{
	public interface ICheckoutRepository
	{
		IQueryable<Checkout> Checkout { get; }

		void SaveInfo(Checkout c);
	}
}

