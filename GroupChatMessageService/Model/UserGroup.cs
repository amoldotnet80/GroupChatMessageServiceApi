using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChatMessageService.Model
{
    public class UserGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int UserId;
        public User User { get; set; }

        public ICollection<User> Users;

        public DateTime Created { get; set; }
    }
}
