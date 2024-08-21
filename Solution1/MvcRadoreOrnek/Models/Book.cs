using System.ComponentModel.DataAnnotations;

namespace MvcRadoreOrnek.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int NumberOfPages { get; set; }
    }
}