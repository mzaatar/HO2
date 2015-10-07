using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HO2.Domain.Models
{
    public class Place : IModel
    {
        [Required]
        [MaxLength(100)]
        public string PlaceName { get; set; }
        
        public string Latitude { get; set; }

        public string  Longitude { get; set; }
    }
}