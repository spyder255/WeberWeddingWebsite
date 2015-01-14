namespace SamMorganWeddingPortal.Models
{
    public class BridalPartyBioModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Relationship { get; set; }
        public string ImagePath { get; set; }

        public BridalPartyBioModel()
        {
            
        }

        public BridalPartyBioModel(string name, string title, string relationship, string imagePath)
        {
            this.Name = name;
            this.Title = title;
            this.Relationship = relationship;
            this.ImagePath = imagePath;
        }
    }
}