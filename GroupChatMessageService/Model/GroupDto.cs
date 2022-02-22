using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChatMessageService.Model
{
    public class GroupDto
    {
        public int Id { get; set; }

        public string GroupName { get; set; }

        public DateTime Created { get; set; }
    }
}
