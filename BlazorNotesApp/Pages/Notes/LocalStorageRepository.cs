using System;
using System.Collections.Generic;
using System.Linq;
using Blazored.LocalStorage;

namespace BlazorNotesApp.Pages.Notes
{
    public class LocalStorageRepository : INoteRepository
    {
        private const string Key = "notes";
        private readonly ISyncLocalStorageService _localStorageService;

        public LocalStorageRepository(ISyncLocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public void Delete(NoteModel noteModel)
        {
            var allNotes = GetAll().ToList();
            allNotes.Remove(allNotes.First(n => n.Id == noteModel.Id));

            _localStorageService.SetItem(Key, allNotes);
        }

        public IEnumerable<NoteModel> GetAll()
        {
            return _localStorageService.GetItem<IEnumerable<NoteModel>>(Key)
                ?? Enumerable.Empty<NoteModel>();
        }

        public void Save(NoteModel noteModel)
        {
            if (Guid.Empty == noteModel.Id)
            {
                AddNote(noteModel);
            }
            else
            {
                UpdateNote(noteModel);
            }
        }

        private void AddNote(NoteModel noteModel)
        {
            noteModel.Id = Guid.NewGuid();
            noteModel.Created = DateTime.Now;

            var allNotes = GetAll().ToList();
            allNotes.Add(noteModel);

            _localStorageService.SetItem(Key, allNotes);
        }

        private void UpdateNote(NoteModel noteModel)
        {
            var allNotes = GetAll().ToList();
            var noteToBeUpdated = allNotes.First(n => n.Id == noteModel.Id);

            var indexOfNoteToBeUpdated = allNotes.IndexOf(noteToBeUpdated);
            allNotes[indexOfNoteToBeUpdated] = noteModel;

            _localStorageService.SetItem(Key, allNotes);
        }        
    }
}
