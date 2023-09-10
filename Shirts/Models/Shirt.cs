using System.ComponentModel.DataAnnotations;
using Shirts.Models.Validations;

namespace Shirts.Models
{
	public class Shirt
	{
		public int ShirtId { get; set; }

        [Required] //AnnotationValidation by .NET
        public string? Brand { get; set; }
        [Required] //AnnotationValidation
        public string? Color { get; set; }
        [Required] // Annotation
        public string? Gender { get; set; }
        [Shirt_CorrectSizing] //Validation written in Validations folder
        public int? Size { get; set; }

        public double Price { get; set; }
    }
}

