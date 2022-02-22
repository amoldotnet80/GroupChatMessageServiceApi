using GroupChatMessageService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChatMessageService.Repository
{
    public interface IUserGroupRepository
    {
        bool AddUserToGroup(int userId, int groupId);
        bool RemoveUserFromGroup(int userId, int groupId);
    }
}
