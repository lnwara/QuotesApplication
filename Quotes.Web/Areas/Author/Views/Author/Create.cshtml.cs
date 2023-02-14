using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quotes.Models;

namespace Quotes.Web.Views.Author
{
    public class CreateModel : PageModel
    {
        public AuthorModel Author { get; set; }
        public void OnGet()
        {

        }
    }
}
