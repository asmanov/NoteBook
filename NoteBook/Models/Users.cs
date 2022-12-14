using NoteBook.Controlers;

namespace NoteBook.Models
{
    internal class Users
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Path { get; set; }

        public Users(string login = "", string password = "")
        {
            Login = login;
            Password = CryptControler.GetSHA256(password);
            Path = $"{Login}.json";
        }
    }
}
