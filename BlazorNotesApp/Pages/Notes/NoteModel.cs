using System;
namespace BlazorNotesApp.Pages.Notes
{
    public class NoteModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string  Content { get; set; }
        public DateTime Created { get; set; }
    }
}
