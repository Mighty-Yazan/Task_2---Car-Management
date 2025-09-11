using System.ComponentModel.DataAnnotations;

namespace Task2.Models
{
    public class Car
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Production Year")]
        public int prodyear { get; set; }

        public string Color { get; set; }

        public double Price { get; set; }

        public DateTime DateAdded { get; set; }

        public string? Img { get; set; }
    }
}
