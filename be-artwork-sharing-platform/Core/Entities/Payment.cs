using System.ComponentModel.DataAnnotations.Schema;

namespace be_artwork_sharing_platform.Core.Entities
{
    [Table("payments")]
    public class Payment : BaseEntity<int>
    {

        //Relationship
        public string User_Id { get; set; }
    }
}
