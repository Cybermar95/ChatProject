using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorizationService.Model
{
    [Table("ChatUser")]
    public class ChatUser
    {
        [Key]
        [Required]
        public int UserID { get; set; }

        [Required]
        [StringLength(16)]
        public string Name { get; set; }

        [Required]
        [StringLength(16)]
        public string Password { get; set; }
        public Guid UserToken { get; set; }
    }
}
