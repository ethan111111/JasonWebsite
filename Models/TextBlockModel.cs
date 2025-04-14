using System.ComponentModel.DataAnnotations;

namespace CurrentJasonWebsite.Models
{
    public class TextBlockModel
    {
        [Key] // Marks this as the primary key (for databases)
        public int Id { get; set; }

        [Required]
        
        public string TextContent { get; set; }
    }
}
