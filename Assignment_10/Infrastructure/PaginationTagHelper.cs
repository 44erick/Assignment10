using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_10.Models.ViewModels;

namespace Assignment_10.Infrastructure
{
	[HtmlTargetElement("div", Attributes = "page-model")]
	//inherit from taghelper class
	public class PaginationTagHelper : TagHelper
	{
		private IUrlHelperFactory urlHelperFactory;

		public PaginationTagHelper(IUrlHelperFactory hp)
		{
			urlHelperFactory = hp;
		}

		//isntances
		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext ViewContext { get; set; }
		public PagingInfo PageModel { get; set; }
		public string PageAction { get; set; }

		//our own dictionary (key value pairs) that we are creating
		[HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
		public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

		// As long as this is set to "true" in the index page or wherever the tag helpers are use...
		// it will automatically apply Css and stuff to the nav bar
		public bool PageClassesEnabled { get; set; }
		public string PageClass { get; set; }
		public string PageClassNormal { get; set; }
		public string PageClassSelected { get; set; }

		// Overriding process method
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

			TagBuilder result = new TagBuilder("div");

			for (int i = 1; i <= PageModel.TotalPages; i++)
			{
				
				TagBuilder tag = new TagBuilder("a");

				PageUrlValues["pageNum"] = i;
				tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

				if (PageClassesEnabled)
				{
					tag.AddCssClass(PageClass);
					tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
				}
				tag.InnerHtml.Append(i.ToString());

				//append tag to html
				result.InnerHtml.AppendHtml(tag);
			}

			output.Content.AppendHtml(result.InnerHtml);
		}
	}
}