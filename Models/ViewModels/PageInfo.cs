using System;
namespace Mission_09_alley725.Models.ViewModels
{
	public class PageInfo
	{
		public int NumBooks { get; set; }
		public int PageSize { get; set; }
		public int CurrentPage { get; set; }
		public int NextPage => CurrentPage + 1;

		public int TotalPages => (int)Math.Ceiling(((double)NumBooks) / PageSize);
	}
}

