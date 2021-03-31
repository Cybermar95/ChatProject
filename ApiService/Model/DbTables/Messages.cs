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

        [Required]
        public int UserID { get; set; }

        [Required]
        public string UserName{ get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
