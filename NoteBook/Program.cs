
using NoteBook.Models;




using (Note_Book mynotebook = new Note_Book("mynotebook.json"))
{
    //mynotebook.AddNote("One", "First note");
    //mynotebook.AddNote("Two", "Second note", true);
    //mynotebook.AddNote("Three", "Thid note");
    //mynotebook.AddNote();
    //mynotebook.EditTitle(mynotebook.notes[3], "Fore");
    //mynotebook.EditBody(mynotebook.notes[3], "New note");
    mynotebook.Display(mynotebook.notes[2]);
    //mynotebook.DelNote("One");

}