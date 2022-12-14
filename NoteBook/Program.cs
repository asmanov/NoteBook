using NoteBook.Controlers;
using NoteBook.Models;

bool enter = false;
Users user = new Users();
while(!enter)
{
    Console.WriteLine("LogIn: 1 or SingUp: 2");
    string logOrSing = Console.ReadLine();
    Console.WriteLine("Enter Login");
    string login = Console.ReadLine();
    Console.WriteLine("Enter Password");
    string password = Console.ReadLine();
    user.Login = login;
    user.Password = password;
    if (login != null && password != null)
    {
        using (UsersControler users = UsersControler.Instance)
        {
            if (logOrSing == "1") enter = users.LogIn(user);
            if (logOrSing == "2") enter = users.SingUp(user);
            Console.Clear();
        }
    }
}

using (Note_Book mynotebook = new Note_Book(user.Path))
{

}


//using (Note_Book mynotebook = new Note_Book("mynotebook.json"))
//{
//    //mynotebook.AddNote("One", "First note");
//    //mynotebook.AddNote("Two", "Second note", true);
//    //mynotebook.AddNote("Three", "Thid note");
//    //mynotebook.AddNote();
//    //mynotebook.EditTitle(mynotebook.notes[3], "Fore");
//    //mynotebook.EditBody(mynotebook.notes[3], "New note");
//    mynotebook.Display(mynotebook.notes[2]);
//    //mynotebook.DelNote("One");

//}