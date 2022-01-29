using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdServiceCore.Models
{
    public class Ad
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(200, ErrorMessage = "Cannot be more than 200 characters.")]
        public string Title { get; set; }

        [MaxLength(1000, ErrorMessage = "Cannot be more than 1000 characters.")]
        public string Description { get; set; }
        public float Price { get; set; }
        public List<Link> LinksForPhotos { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
