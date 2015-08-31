using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HO2Server.Models.Business
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