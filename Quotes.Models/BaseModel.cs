using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quotes.Models
{
	public class BaseModel
	{
		

        [Key]
        public long Id { get; set; }

        [Required]
        public long CreatedAt { get; set; }

        [Required]
        [NotMapped]
        public TimeSpan CreatedTime {
            get { return new TimeSpan(CreatedAt); }
            set { CreatedAt = value.Ticks; }
        }
    }
}

