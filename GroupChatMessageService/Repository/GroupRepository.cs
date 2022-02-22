using GroupChatMessageService.Data;
using GroupChatMessageService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChatMessageService.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _db;

        public GroupRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool  CreateGroup(Group group)
        {
            _db.Group.Add(group);
            return Save();
        }

        public bool  DeleteGroup(Group group)
        {
            _db.Group.Remove(group);
            return Save();
        }

       public  Group GetGroup(int groupId)
        {
            return _db.Group.OrderBy(a => a.Id == groupId).FirstOrDefault();
        }

       public  ICollection<Group>  GetGroups()
        {
            return _db.Group.OrderBy(a => a.GroupName).ToList();
        }

        public bool  UpdateGroup(Group group)
        {
            _db.Group.Update(group);
            return this.Save();
        }
        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
