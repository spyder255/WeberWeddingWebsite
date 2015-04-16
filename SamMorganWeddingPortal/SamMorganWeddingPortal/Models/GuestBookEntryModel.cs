using System;
using System.ComponentModel.DataAnnotations;

namespace SamMorganWeddingPortal.Models
{
    public class GuestBookEntryModel
    {
        [MaxLength(50)]
        [Required]
        public string Author { get; set; }

        [MaxLength(2000)]
        [Required]
        public string Message { get; set; }
        public DateTime DatePosted { get; set; }

        public GuestBookEntryModel()
        {
            this.Author = String.Empty;
            this.Message = String.Empty;
        }
    }
}