using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Catalogs.Controllers
{
    public class Product
    {
        [ReadOnly(true)]
        public Guid Id { get; internal set; }
        [Required]
        public string Name { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Cost { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
