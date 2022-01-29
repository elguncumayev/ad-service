using System.ComponentModel.DataAnnotations;

namespace AdServiceCore.Models
{
    public class Link
    {
        [Key]
        public int ID { get; set; }

        public string Url { get; set; }
    }
}
