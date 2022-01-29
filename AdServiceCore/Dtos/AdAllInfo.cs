using System.Collections.Generic;

namespace AdServiceCore.Dtos
{
    public class AdAllInfo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public List<string> LinksForPhotos { get; set; }
    }
}
