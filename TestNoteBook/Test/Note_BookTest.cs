using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NoteBook.Models;

namespace TestNoteBook.Test
{
    public class Note_BookTest
    {
        private readonly Note_Book _booktest;

        public Note_BookTest()
        {
            _booktest = new Note_Book("test.txt");
            _booktest.AddNote("Title One", "Test note one");
            _booktest.AddNote("Title Two", "Test note two");
            _booktest.AddNote("Title Three", "Test note three");
            _booktest.AddNote("Title Four", "Test note four", true);
        }
        [Fact]
        public void FindNoteNoteNullTest()
        {
            var result = _booktest.FindNote("Title One");
            Assert.NotNull(result);
        }
        [Fact]
        public void FindNoteTypeTest()
        {
            var result = _booktest.FindNote("Title One");
            Assert.IsType<Note>(result);
        }
        [Fact]
        public void NoteForDateTypeTest()
        {
            var result = _booktest.NoteForDate("08.01.2023");
            Assert.True(result is List<Note>);
        }
        [Fact]
        public void NoteForPriorityTypeTest()
        {
            var result = _booktest.NoteForPriority(false);
            Assert.True(result is List<Note>);
        }
        [Fact]
        public void NoteForPriorityCountTest()
        {
            var result = _booktest.NoteForPriority(false);
            int count = result.Count();
            Assert.Equal(3, count);
        }
        [Fact]
        public void DelNoteFalseTest()
        {
            string response = _booktest.DelNote("Title Five");
            Assert.Equal("The note don`t find", response);
        }
        [Fact]
        public void DelNoteTrueTest()
        {
            string response = _booktest.DelNote("Title Three");
            Assert.Equal("The note was delete", response);
        }

    }
}
