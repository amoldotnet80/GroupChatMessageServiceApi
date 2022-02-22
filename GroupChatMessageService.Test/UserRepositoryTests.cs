using GroupChatMessageService.Data;
using GroupChatMessageService.Model;
using GroupChatMessageService.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace GroupChatMessageService.Test
{
    [TestClass]
    public class UserRepositoryTests
    {
        private User user_One;
        private User user_Two;
        private DbContextOptions<ApplicationDbContext> options;
        public UserRepositoryTests()
        {
            this.SetupDB();
            user_One = new User()
            {
                Id =1,
                UserName = "user1",
                Password = "user1"

            };

            user_Two = new User()
            {
                Id=2,
                UserName = "user2",
                Password = "user2"

            };

    }

        public void SetupDB()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "temp_GroupChatMessageDB").Options;
        }

        [TestMethod]
        public void Authenticate_WhenRightCredential_ShouldReturnUserandTokenNotNull()
        {
            //Arrange
            var mock = new Mock<IOptions<AppSettings>>();
            
            User result;
            mock.Setup(x => x.Value).Returns(new AppSettings() { Secret = "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING" });
            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new UserRepository(context, mock.Object);
                var userCreated = repository.CreateUser(user_One);
                result = repository.Authenticate(user_One);
            }

            //Assert
            using (var context = new ApplicationDbContext(options))
            {
                Assert.NotNull(result);
                Assert.NotNull(result.Token);
            }
        }

        [TestMethod]
        public void Authenticate_WhenWrongCredential_ShouldReturnUserandTokenNull()
        {
            //Arrange
            var mock = new Mock<IOptions<AppSettings>>();
            User user = new User() { UserName="user1", Password="dsad"};
            User result;
      
            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new UserRepository(context, mock.Object);
                var userCreated = repository.CreateUser(user_Two);
                result = repository.Authenticate(user);
            }

            //Assert
            using (var context = new ApplicationDbContext(options))
            {
                Assert.Null(result);
                Assert.Null(result?.Token);
            }
        }
    }
}

