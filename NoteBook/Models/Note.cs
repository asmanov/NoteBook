namespace NoteBook.Models
{
    internal class Note
    {
        public string Title { get; set; } = "Title";
        public string Body { get; set; } = string.Empty;
        public DateTime TimeCreation { get; }
        public bool Priority { get; set; } = false;
        public Note()
        {
            TimeCreation = DateTime.Now;
        }
    }
}
