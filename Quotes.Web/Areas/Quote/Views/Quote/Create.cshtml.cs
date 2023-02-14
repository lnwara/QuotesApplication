using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quotes.Models.ViewModel;

namespace Quotes.Web.Views.Quote
{
    public class CreateModel : PageModel
    {
        CreateQuotesVM Quote { get; set; }
        public void OnGet()
        {

        }
    }
}
