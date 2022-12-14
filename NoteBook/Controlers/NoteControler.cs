using NoteBook.Models;

namespace NoteBook.Controlers
{
    internal static class NoteControler
    {
        public static void Note(string n, Note_Book usernotebook)
        {
            if (n == "1")//добавление заметки
            {
                Console.WriteLine("Enter note's title");
                string title = Console.ReadLine();
                Console.WriteLine("Enter note");
                string note = Console.ReadLine();
                Console.WriteLine("Priority. Enter hight or low");
                string priority = Console.ReadLine();
                bool pr=false;
                if (priority == "hight") pr = true;
                if (priority == "low") pr = false;
                usernotebook.AddNote(title, note, pr);
            }
            if(n == "2")//удаление заметки
            {
                Console.WriteLine("Enter note's title");
                string title = Console.ReadLine();
                usernotebook.DelNote(title);
            }
            if(n == "3")//поиск заметки
            {
                Console.WriteLine("Enter note's title");
                string title = Console.ReadLine();
                usernotebook.Display(usernotebook.FindNote(title));
            }
            //if(n==4)
            //{

            //}
        }

        
    }
}
