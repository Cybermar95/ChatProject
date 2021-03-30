using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiService.Model
{
    [Table("ChatUsers")]
    public class ChatUsers
    {
        [Key]
        [Required]
        public int ID { get; set; }
        
        [Required]
        [StringLength(16)]
        public string Name { get; set; }
    }
}
