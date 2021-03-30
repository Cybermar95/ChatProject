using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiService.Model
{
    [Table("AcessTokens")]
    public class AcessTokens
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
