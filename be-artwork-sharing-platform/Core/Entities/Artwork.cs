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
    }
}
