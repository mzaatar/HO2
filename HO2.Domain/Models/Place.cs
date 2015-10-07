using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HO2.Domain.Models
{
    public class Place
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlaceId { get; set; }
        [Required]
        [MaxLength(100)]
        public string PlaceName { get; set; }
        
        public string Latitude { get; set; }

        public string  Longitude { get; set; }
    }
}