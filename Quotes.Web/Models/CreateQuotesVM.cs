using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Quotes.Models.ViewModel
{
	public class CreateQuotesVM
	{
        [Required(ErrorMessage = "Quote Text is required")]
        [DisplayName("Quote Text")]
        [MaxLength(500, ErrorMessage = "Quote Text Quote Text should be less than 500 charcters")]
        [MinLength(10, ErrorMessage = "Quote Text should be greater than 50 charcters")]
        public String Text { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [DisplayName("Author")]
        public long AuthorId { get; set; }

        [ValidateNever]
        public List<SelectListItem> Authors { get; set; }
    }


    public class UpdateQuotesVM
    {
        [Required(ErrorMessage = "Quote Text is required")]
        [DisplayName("Quote Text")]
        [MaxLength(500, ErrorMessage = "Quote Text Quote Text should be less than 500 charcters")]
        [MinLength(10, ErrorMessage = "Quote Text should be greater than 50 charcters")]
        public String Text { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [DisplayName("Author")]
        public long AuthorId { get; set; }

        [ValidateNever]
        public List<SelectListItem> Authors { get; set; }

        public TimeSpan CreatedTime { get; set; }

        public long Id { get; set; }

    }
}

