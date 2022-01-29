using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdServiceCore.Dtos
{
    public class AdCreateInfo
    {
        [MaxLength(200, ErrorMessage = "Cannot be more than 200 characters.")]
        public string Title { get; set; }
        [MaxLength(1000, ErrorMessage = "Cannot be more than 1000 characters.")]
        public string Description { get; set; }
        public float Price { get; set; }
        public List<string> LinksForPhotos { get; set; }
    }
}
