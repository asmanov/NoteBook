using NoteBook.Models;

namespace TestNoteBook.Test
{
    public class NoteTest
    {

        [Fact]
        public void NotEqualsNoteTest()
        {
            Note note1 = new Note();
            Note note2 = new Note();
            Assert.NotEqual(note1, note2);
        }
    }
}