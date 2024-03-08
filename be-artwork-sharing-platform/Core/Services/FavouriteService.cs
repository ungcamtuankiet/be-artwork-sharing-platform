﻿using be_artwork_sharing_platform.Core.DbContext;
using be_artwork_sharing_platform.Core.Dtos.Category;
using be_artwork_sharing_platform.Core.Dtos.Favourite;
using be_artwork_sharing_platform.Core.Dtos.General;
using be_artwork_sharing_platform.Core.Entities;
using be_artwork_sharing_platform.Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace be_artwork_sharing_platform.Core.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly ApplicationDbContext _context;
        private readonly IArtworkService _artworkService;

        public FavouriteService(ApplicationDbContext context, IArtworkService artworkService)
        {
            _context = context;
            _artworkService = artworkService;
        }

        public IEnumerable<GetFavourite> GetFavouritesByUserId(string user_Id)
        {
            var artwork_Id = GetFavouriteIdByUserId(user_Id);
            var checkFavourite = _context.Favorites.FirstOrDefault(f => f.User_Id == user_Id && f.Artwork_Id == artwork_Id);
            if(checkFavourite != null)
            {
                var favourites = _context.Favorites.Where(f => f.User_Id == user_Id)
                    .Select(f => new GetFavourite
                    {
                        Category_Name = f.Artworks.Category_Name,
                        User_Name = f.Artworks.User_Name,
                        Name = f.Artworks.Name,
                        Description = f.Artworks.Description,
                        Url_Image = f.Artworks.Url_Image,
                        Price = f.Artworks.Price,
                        CreatedAt = f.Artworks.CreatedAt,
                        UpdatedAt = f.Artworks.UpdatedAt,
                        IsActive = f.Artworks.IsActive,
                        IsDeleted = f.Artworks.IsDeleted,
                    }).ToList();
                return favourites;
            }
            return null;
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

        public int RemoveArtwork(long favourite_Id, string user_Id)
        {
            var favourite = _context.Favorites.FirstOrDefault(f => f.Id == favourite_Id && f.User_Id == user_Id);
            if (favourite == null) return 0;
            else
            {
                _context.Remove(favourite);
                return _context.SaveChanges();
            }
        }

        public long GetFavouriteIdByUserId(string user_Id)
        {
            var checkUser =  _context.Favorites.FirstOrDefault(f => f.User_Id == user_Id);
            if(checkUser != null)
            {
                return checkUser.Artwork_Id;
            }
            return 0;
        }
    }
}
