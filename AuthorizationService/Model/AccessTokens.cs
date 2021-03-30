using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorizationService.Model
{
    [Table("AccessTokens")]
    public class AccessTokens
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public Guid Token { get; set; }
    }
}
