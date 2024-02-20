using System.ComponentModel.DataAnnotations.Schema;

namespace be_artwork_sharing_platform.Core.Entities
{
    [Table("categories")]
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
