using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace be_artwork_sharing_platform.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        public IList<string> Roles { get; set; }

        //Relationship
        public List<Comment> Comments { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Favourite> Favourites { get; set; }
        public List<Artwork> Artworks { get; set; }

    }
}
