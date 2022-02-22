using GroupChatMessageService.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace GroupChatMessageService.Data
{
  
        public class ApplicationDbContext : DbContext
    {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }

        public DbSet<User> User { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<GroupMessage> GroupMessage { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }

        public DbSet<Likes> Likes { get; set; }
    }
    }

