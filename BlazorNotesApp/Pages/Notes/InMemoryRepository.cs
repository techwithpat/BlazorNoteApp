using System;
using System.Collections.Generic;

namespace BlazorNotesApp.Pages.Notes
{
    public class InMemoryRepository : INoteRepository
    {
        private IList<NoteModel> Notes;

        public InMemoryRepository()
        {
            Notes = new List<NoteModel>()
            {
                new NoteModel{Title = "First note", Content = "First content"},
                new NoteModel{Title = "Second note", Content = "Second content"},
                new NoteModel{Title = "Third note", Content = "Third content"},
                new NoteModel{Title = "Fourth note", Content = "Fourth content"}
            };
        }

        public void Delete(NoteModel noteModel)
        {
            Notes.Remove(noteModel);
        }

        public IEnumerable<NoteModel> GetAll()
        {
            return Notes;
        }

        public void Save(NoteModel noteModel)
        {
            if(noteModel.Id == Guid.Empty)
            {
                noteModel.Id = Guid.NewGuid();
                Notes.Insert(0, noteModel);
            }
        }
    }
}
