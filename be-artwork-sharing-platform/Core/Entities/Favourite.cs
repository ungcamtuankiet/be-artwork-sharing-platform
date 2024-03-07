using System.ComponentModel.DataAnnotations.Schema;

namespace be_artwork_sharing_platform.Core.Entities
{
    [Table("favourites")]
    public class Favourite : BaseEntity<long>
    {
        //Relation ship
        public string User_Id { get; set; }
        [ForeignKey("User_Id")]
        public ApplicationUser User { get; set; } 
        public long Artwork_Id { get; set; }
        [ForeignKey("Artwork_Id")]
        public Artwork Artworks { get; set; }
    }
}
