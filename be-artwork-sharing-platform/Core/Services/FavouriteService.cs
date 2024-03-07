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

        public FavouriteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddToFavourite(string userId, long artworkId)
        {
            var favourite = new Favourite
            {
                Artwork_Id = artworkId,
                User_Id = userId,
            };
            _context.Favorites.Add(favourite);
            _context.SaveChanges();
        }

        public async Task RemoveArtwork(long favourite_Id, string user_Id)
        {
            var favourite = await _context.Favorites.FirstOrDefaultAsync(f => f.Id == favourite_Id && f.User_Id == user_Id);
            if (favourite != null)
            {
                _context.Favorites.Remove(favourite);
                await _context.SaveChangesAsync();
            }
        }


    }
}
