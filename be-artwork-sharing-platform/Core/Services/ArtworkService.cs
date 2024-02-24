using be_artwork_sharing_platform.Core.DbContext;
using be_artwork_sharing_platform.Core.Dtos.Artwork;
using be_artwork_sharing_platform.Core.Dtos.General;
using be_artwork_sharing_platform.Core.Entities;
using be_artwork_sharing_platform.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace be_artwork_sharing_platform.Core.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly ApplicationDbContext _context;

        public ArtworkService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateArtwork(CreateArtwork artworkDto, string user_Id)
        {
            var artwork = new Artwork
            {
                User_Id = user_Id,
                Category_Name = artworkDto.Category_Name,
                Name = artworkDto.Name,
                Description = artworkDto.Description,
                Url_Image = artworkDto.Url_Image,
                Price = artworkDto.Price,
            };
            await _context.Artworks.AddAsync(artwork);
            await _context.SaveChangesAsync();
        }

    }
}
