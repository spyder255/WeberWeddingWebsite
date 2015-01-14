using System.Collections.Generic;

namespace SamMorganWeddingPortal.Models
{
    public class GuestBookModel
    {
        public GuestBookEntryModel NewEntry { get; set; }
        public List<GuestBookEntryModel> GuestBookEntries { get; set; }

        public GuestBookModel()
        {
            this.NewEntry = new GuestBookEntryModel();
            this.GuestBookEntries = new List<GuestBookEntryModel>();
        }
    }
}