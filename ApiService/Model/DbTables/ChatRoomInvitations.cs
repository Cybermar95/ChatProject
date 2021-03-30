using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ApiService.Model
{
    [Table("ChatRoomInvitations")]
    public class ChatRoomInvitations
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public int RoomID { get; set; }

        [Required]
        public int UserID { get; set; }
    }
}
