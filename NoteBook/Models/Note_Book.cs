using System.Text.Json;
//Создать свое приложение для хранения заметок и работы с ними
//Сама заметка представлена 
//- Заголовок
//- Текст
//- Дата создания
//- Приоритет (высокий / низкий)

//Приложение дает возможность
//- Добавлять заметки
//- Удалять заметки
//- Редактировать 
//- Искать по одному из фильтров
//- Искать дубликаты по однуму из фильтров

namespace NoteBook.Models
{
    internal class Note_Book : IDisposable
    {
        public string Path { get; set; }
        public List<Note> notes;

        public Note_Book(string path)
        {
            notes = new List<Note>();
            Path = path;
            if (File.Exists(Path))
            {
                string strJSON = File.ReadAllText(Path);
                notes = JsonSerializer.Deserialize<List<Note>>(strJSON);
            }
        }
        //добавление записи
        /// <summary>
        /// This method add note to notebook
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// Note's title
        /// A <see cref="string"/>
        /// type representing a value.
        /// <param name="body"></param>
        /// <param name="priority"></param>
        public void AddNote(string title = "None" , string body = "", bool priority = false)
        {
            Note note = new Note();
            note.Title = title;
            note.Body = body;
            note.Priority = priority;
            notes.Add(note);
        }
        //удаление записи
        public string DelNote(string str) 
        {
            Note note = FindNote(str);
            if (notes.Remove(note)) return "The note was deleted";
            else return "The note don`t find";
        }
        //нахождение записи по заголовку
        public Note FindNote(string title)
        {
            //return (Note)(from x in notes where x.Title == title select x );
            Note nt = notes.FirstOrDefault(x => x.Title == title);
            return nt;
        }
        //редактирование заголовка
        public void EditTitle(Note note, string str)
        {
            note.Title = str;
        }
        //редактирование заметки
        public void EditBody(Note note, string str)
        {
            note.Body = str;
        }
        //заметки по фильтру дата создания
        public List<Note>  NoteForDate(string date)
        {
            //List<Note> notesForDate = new List<Note>();
            DateOnly.TryParse(date, out DateOnly dateOnly);
            var notesForDate = notes.Where(x => DateOnly.FromDateTime(x.TimeCreation) == dateOnly).ToList();
            return notesForDate;
        }
        //заметки по фильтру приоритет
        public List<Note> NoteForPriority(bool priority)
        {
            var notesForDate = notes.Where(x => x.Priority == priority).ToList();
            return notesForDate;
        }
        //вывод заметки в консоли
        public void Display(Note note)
        {
            if (note == null) return;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"<=={note.Title}==>");
            if (!note.Priority) Console.WriteLine("Low priority");
            else Console.WriteLine("Hight priority");
            Console.WriteLine("==========================");
            Console.WriteLine($"{note.Body}");
            Console.WriteLine("==========================");
            Console.WriteLine(note.TimeCreation);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void Dispose()
        {
            string jsonString = JsonSerializer.Serialize(notes);
            File.WriteAllText(Path, jsonString);
        }
    }
}
