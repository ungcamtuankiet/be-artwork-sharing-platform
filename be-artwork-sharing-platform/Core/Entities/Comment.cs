using System.ComponentModel.DataAnnotations.Schema;

namespace be_artwork_sharing_platform.Core.Entities
{
    [Table("comments")]
    public class Comment : BaseEntity<long>
    {
        public string Comment_Test { get; set; }

        //Relationship
    }
}
