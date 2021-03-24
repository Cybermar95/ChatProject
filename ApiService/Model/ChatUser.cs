using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiService.Model
{
    [Table("ChatUser")]
    public class ChatUser
    {
        [Key]
        [Required]
        public int UserID { get; set; }
        
        [Required]
        [StringLength(16)]
        public string UserName { get; set; }

        public Guid UserToken { get; set; }
    }
}
