using System;
using System.Collections.Generic;

namespace BlazorNotesApp.Pages.Notes
{
    public partial class NoteList
    {
        public IList<NoteModel> Notes { get; set; }

        protected override void OnInitialized()
        {
            Notes = new List<NoteModel>()
    {
            new NoteModel{Title = "First note", Content = "First content"},
            new NoteModel{Title = "Second note", Content = "Second content"},
            new NoteModel{Title = "Third note", Content = "Third content"},
            new NoteModel{Title = "Fourth note", Content = "Fourth content"}
        };
        }
    }
}
