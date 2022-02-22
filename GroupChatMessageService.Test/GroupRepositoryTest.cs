using AutoMapper;
using GroupChatMessageService.Data;
using GroupChatMessageService.Model;
using GroupChatMessageService.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace GroupChatMessageService.Test
{
    [TestClass]
    public class GroupRepositoryTest
    {
        private Group group_One;
        private DbContextOptions<ApplicationDbContext> options;
        public GroupRepositoryTest()
        {
            this.SetupDB();
            group_One = new Group()
            {
                Id = 1,
                GroupName = "user1",
            };

        }

        public void SetupDB()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "temp_GroupChatMessageDB").Options;
        }
        [TestMethod]
        public void CreateUser_WhenValidPAramters_ShouldAddRecord()
        {
            //Arrange
            var mock = new Mock<IMapper>();
            var user = new Group() { Id =1, GroupName= "group1"};
            bool result;

            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new GroupRepository(context);
                 result = repository.CreateGroup(group_One);
            }

            //Assert
            using (var context = new ApplicationDbContext(options))
            {
                NUnit.Framework.Assert.IsTrue(result);
                var groupFromDB = context.Group.FirstOrDefaultAsync(x=>x.GroupName == group_One.GroupName);
                Assert.IsNotNull(groupFromDB);

            }
        }
    }
}
