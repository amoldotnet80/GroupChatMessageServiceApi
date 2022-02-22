using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChatMessageService.Model
{
    public class Likes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MessageID { get; set; }
        public GroupMessage GroupMessage { get; set; }

        [Required]
        public int UserID { get; set; }
        public User User { get; set; }

        public DateTime Created { get; set; }
    }
}
