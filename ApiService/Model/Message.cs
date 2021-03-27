using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiService.Model
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public int RoomID { get; set; }

        public DateTime Date { get; set; }

        [StringLength(16)]
        public string UserName { get; set; }

        public string Text { get; set; }
    }
}
