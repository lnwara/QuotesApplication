using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quotes.Models;

namespace Quotes.Web.Views.Quote
{
	public class IndexModel : PageModel
    {
        public List<SelectListItem> Authors { get; set; }
        public IEnumerable<QuotesModel> Quotes { get; set; }
        public long AuthorId { get; set; }

        public void OnGet()
        {
        }

        
    }
}
