using System.ComponentModel.DataAnnotations.Schema;

namespace be_artwork_sharing_platform.Core.Entities
{
    [Table("favourites")]
    public class Favourite : BaseEntity<long>
    {
    }
}
