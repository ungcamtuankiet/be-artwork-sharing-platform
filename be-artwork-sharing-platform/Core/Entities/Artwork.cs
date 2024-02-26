﻿using System.ComponentModel.DataAnnotations.Schema;

namespace be_artwork_sharing_platform.Core.Entities
{
    [Table("artworks")]
    public class Artwork : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Category_Name { get; set; }
        public string Description { get; set; }
        public string Url_Image { get; set; }
        public double Price { get; set; }
        public long? Category_Id { get; set; }

        //Relationship
        public string User_Id { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("Category_Id")]
        public Category Category { get; set; }
    }
    
}
