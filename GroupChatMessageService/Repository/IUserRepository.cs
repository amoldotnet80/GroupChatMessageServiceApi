using GroupChatMessageService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChatMessageService.Repository
{
    public interface IUserRepository
    {
        User Authenticate(User user);
        User CreateUser(User user);
        User DeleteUser(User user);
        User UpdateUser(User user);
    }
}
