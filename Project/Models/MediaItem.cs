using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class MediaItem
    {

        [Key]
        public int Id{ get; set; }
        [Required]
        public string Name { get; set; }
        public string Duration { get; set; }
        public string FileLocation { get; set; }
        public string Description { get; set; }
        public byte[] bytes { get; set; }
        public int ByteWeight { get; set; }

    }
}
