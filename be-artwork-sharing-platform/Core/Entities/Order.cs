using System.ComponentModel.DataAnnotations.Schema;

namespace be_artwork_sharing_platform.Core.Entities
{
    [Table("orders")]
    public class Order : BaseEntity<long>
    {
        public int Quantity { get; set; }
        public double Price { get; set; }

        //Relationship
        public string User_id { get; set; }
    }
}
