using NoteBook.Models;
using System.Text.Json;

namespace NoteBook.Controlers
{
    public sealed class UsersControler : IDisposable
    {
        private Dictionary<string, string> _users;
        public string Path { get; set; } = "users.json";
        private static readonly Lazy<UsersControler> _instance = new Lazy<UsersControler>(() => new UsersControler());
        private UsersControler()
        {
            _users = new Dictionary<string, string>();
            if (File.Exists(Path))
            {
                string usersJSON = File.ReadAllText(Path);
                _users = JsonSerializer.Deserialize<Dictionary<string, string>>(usersJSON);
            }
            //else _users = new Dictionary<string, string>();
        }

        public static UsersControler Instance { get { return _instance.Value; } }



        //вход в программу для существующих пользователей
        internal bool LogIn(Users user)
        {
            if (_users.Any(x => x.Key == user.Login))
            {
                string item = _users.First(x => x.Key == user.Login).Value;
                if (item == CryptControler.GetSHA256(user.Password))
                {
                    return true;
                }
            }
            return false;
        }
        //добаление нового пользователя и вход в систему
        internal bool SingUp(Users user)
        {
            if(_users.TryAdd(user.Login, CryptControler.GetSHA256(user.Password)))
            {
                LogIn(user);
                return true;
            }
            else return false;
        }

        public void Dispose()
        {
            if (_users != null)
            {
                string usersJson = JsonSerializer.Serialize<Dictionary<string, string>>(_users);
                File.WriteAllText(Path, usersJson);
            }
        }
    }
}
