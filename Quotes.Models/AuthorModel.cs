using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Quotes.Models
{
	public class AuthorModel :BaseModel
	{
		

		[Required(ErrorMessage ="Author Name Required.")]
		[MaxLength(50, ErrorMessage = "Author Name maximum length is 50.")]
        public String Name { get; set; }

	


    }
}

