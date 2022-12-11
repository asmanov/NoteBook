using System.Text;
using XSystem.Security.Cryptography;

namespace NoteBook.Controlers
{
    internal static class CryptControler
    {
        public static string GetSHA256(string data)
        {
            SHA256Managed crypt = new SHA256Managed();
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] bytesHash = crypt.ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            foreach (var item in bytesHash)
            {
                builder.Append(item.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
