using System.ComponentModel.DataAnnotations.Schema;

namespace be_artwork_sharing_platform.Core.Entities
{
    [Table("comments")]
    public class Comment : BaseEntity<long>
    {
        public string Comment_Test { get; set; }

        //Relationship
        public string User_Id { get; set; }
        public ApplicationUser User { get; set; }
        public long Artwork_Id { get; set; }
        public Artwork Artwork { get; set; }
    }
}
