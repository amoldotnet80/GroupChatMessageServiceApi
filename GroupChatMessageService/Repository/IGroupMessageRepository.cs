using GroupChatMessageService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChatMessageService.Repository
{
    public interface IGroupMessageRepository
    {
        bool CreateMessage(GroupMessage group);
      //  bool UpdateGroup(GroupMessage group);
        bool DeleteGroup(GroupMessage group);
    }
}
