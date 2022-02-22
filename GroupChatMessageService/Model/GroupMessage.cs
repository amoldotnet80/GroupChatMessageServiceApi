using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChatMessageService.Model
{
    public class GroupMessage
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int GroupID { get; set; }
        public Group Group { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime Created { get; set; }
    }
}
