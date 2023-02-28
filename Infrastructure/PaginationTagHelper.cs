using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission_09_alley725.Models.ViewModels;

namespace Mission_09_alley725.Infrastructure
{
	[HtmlTargetElement("div", Attributes = "page-info")]
	public class PaginationTagHelper : TagHelper
	{
		private IUrlHelperFactory _uhf { get; set; }

		public PaginationTagHelper(IUrlHelperFactory factory)
		{
			_uhf = factory;
		}

		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext vc { get; set; }

		public PageInfo PageInfo { get; set; }

		public string PageAction { get; set; }

		public override void Process(TagHelperContext thc, TagHelperOutput tho)
		{
			IUrlHelper url = _uhf.GetUrlHelper(vc);

			TagBuilder final = new TagBuilder("div");

			for (int i = 1; i <= PageInfo.TotalPages; i++)
			{
				TagBuilder tb = new TagBuilder("a");

				tb.Attributes["href"] = url.Action(PageAction, new { pageNum = i });
				tb.InnerHtml.Append(i.ToString());

				final.InnerHtml.AppendHtml(tb);
			}

			tho.Content.AppendHtml(final.InnerHtml);
		}
	}
}

