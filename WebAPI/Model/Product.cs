using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class Product
    {

        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string productName { get; set; }
        [Required]
        public decimal price { get; set; }
    }
}
