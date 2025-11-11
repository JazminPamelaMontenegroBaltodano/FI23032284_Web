using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksApp.Models
{
    public class Title
    {
        [Key]
        public int TitleId { get; set; }

        [Required]
        public string TitleName { get; set; } = string.Empty;

        [Required]
        public int AuthorId { get; set; }

        public Author Author { get; set; } = null!;

        public ICollection<TitleTag> TitlesTags { get; set; } = new List<TitleTag>();
    }
}
