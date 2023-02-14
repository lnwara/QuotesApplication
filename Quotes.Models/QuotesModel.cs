using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quotes.Models
{
	public class QuotesModel:BaseModel
	{
	

        [Column("Text", TypeName = "ntext")]
        [Required]
        public String Text { get; set; }


        [Required]
        public long AuthorId { get; set; }

        [ForeignKey("AuthorId")]
		public AuthorModel Author { get; set; }

        

    }
}

