namespace be_artwork_sharing_platform.Core.Entities
{
    public class Favourite : BaseEntity<long>
    {
        public string User_Id { get; set; }
        public long Artwork_Id { get; set; }


        //Relation ship
        public ApplicationUser User { get; set; }
        public List<Artwork> Artworks { get; set; }
    }
}
