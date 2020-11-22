using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorNotesApp.Pages.Notes
{
    public class NoteModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(20, ErrorMessage = "The title is too long")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string  Content { get; set; }
        public DateTime Created { get; set; }
        public bool ReadOnly { get; set; } = true;
    }
}
