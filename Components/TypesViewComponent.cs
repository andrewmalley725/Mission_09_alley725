using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mission_09_alley725.Models;

namespace Mission_09_alley725.Components
{
	public class TypesViewComponent : ViewComponent
	{
		private IBookstoreRepository _repo { get; set; }

		public TypesViewComponent(IBookstoreRepository temp)
		{
			_repo = temp;
		}

		public IViewComponentResult Invoke()
		{

			var categories = _repo.Books
				.Select(x => x.Category)
				.Distinct()
				.OrderBy(x => x);

			return View(categories);
		}
	}
}

