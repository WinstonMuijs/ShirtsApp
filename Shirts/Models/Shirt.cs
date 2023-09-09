using System.ComponentModel.DataAnnotations;
using Shirts.Models.Validations;

namespace Shirts.Models
{
	public class Shirt
	{
		public int ShirtId { get; set; }

        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Shirt_CorrectSizing]
        public int? Size { get; set; }

        public double Price { get; set; }
    }
}

