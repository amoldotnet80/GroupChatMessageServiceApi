using GroupChatMessageService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChatMessageService.Repository
{
    public interface IGroupRepository
    {
        ICollection<Group> GetGroups();
        Group GetGroup(int groupId);
        bool CreateGroup(Group group);
        bool UpdateGroup(Group group);
        bool DeleteGroup(Group group);

    }
}
