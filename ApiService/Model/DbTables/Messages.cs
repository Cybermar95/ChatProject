using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiService.Model
{
    [Table("Messages")]
    public class Messages
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public int RoomID { get; set; }

        [StringLength(16)]
        public string UserID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Text { get; set; }
    }
}
