using System.ComponentModel.DataAnnotations;


namespace CurrentJasonWebsite.Models
{
    public class Church
    {
        [Key]
        public int Id { get; set; }

        public string? ChurchName { get; set; }
        public string? Description { get; set; }

        public string? Location { get; set; }

        public byte[]? ImageData { get; set; }
    }
}
