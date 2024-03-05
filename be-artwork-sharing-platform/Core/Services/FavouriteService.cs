using be_artwork_sharing_platform.Core.DbContext;
using be_artwork_sharing_platform.Core.Dtos.Category;
using be_artwork_sharing_platform.Core.Dtos.Favourite;
using be_artwork_sharing_platform.Core.Dtos.General;
using be_artwork_sharing_platform.Core.Entities;
using be_artwork_sharing_platform.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace be_artwork_sharing_platform.Core.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly ApplicationDbContext _context;
        public async Task AddToFavourite(FavouriteDto favouriteDto, string userId, long artworkId)
        {
            var favourite = new Favourite
            {
                Artwork_Id = artworkId,
                User_Id = userId,
                CreatedAt = favouriteDto.CreatedAt,
                UpdatedAt = favouriteDto.UpdatedAt,
                IsActive = favouriteDto.IsActive,
                IsDeleted = favouriteDto.IsDeleted
            };
            await _context.Favorites.AddAsync(favourite);
            await _context.SaveChangesAsync();
        }
    }
}
