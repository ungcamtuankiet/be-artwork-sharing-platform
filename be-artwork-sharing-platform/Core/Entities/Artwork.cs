using System.ComponentModel.DataAnnotations.Schema;

namespace be_artwork_sharing_platform.Core.Entities
{
    [Table("artworks")]
    public class Artwork : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url_Image { get; set; }
        public double Price { get; set; }

        //Relationship
        public string User_Id { get; set; }
        public ApplicationUser User { get; set; }
        public long Category_Id { get; set; }
        public Category Category { get; set; }
        public List<Favourite> Favourite { get; set; }
        public ICollection<Comment> Comments { get; set; } 
    }
    
}
