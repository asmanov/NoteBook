using NoteBook.Models;

namespace TestNoteBook.Test
{
    public class UsersTest : NoteTest
    {
        [Fact]
        public void NotNullUserTest()
        {
            Users user = new Users("Admin", "Admin");
            Assert.NotEqual(null, user);
        }

        [Fact]
        public void EqualsUserTest()
        {
            Users user = new Users("Admin", "Admin");
            Users user2 = user;
            Assert.True(user.Equals(user2));
        }
    }
}