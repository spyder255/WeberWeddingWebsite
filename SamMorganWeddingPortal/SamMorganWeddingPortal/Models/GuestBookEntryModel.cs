using System;
using System.ComponentModel.DataAnnotations;

namespace SamMorganWeddingPortal.Models
{
    public class GuestBookEntryModel
    {
        [MaxLength(50)]
        public string Author { get; set; }

        [MaxLength(2000)]
        public string Message { get; set; }
        public DateTime DatePosted { get; set; }

        public GuestBookEntryModel()
        {
            this.Author = String.Empty;
            this.Message = String.Empty;
        }
    }
}