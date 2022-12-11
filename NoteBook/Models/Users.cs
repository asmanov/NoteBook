namespace NoteBook.Models
{
    internal class Users
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public Users(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
