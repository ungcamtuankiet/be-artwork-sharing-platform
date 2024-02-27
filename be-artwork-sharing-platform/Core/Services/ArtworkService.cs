using be_artwork_sharing_platform.Core.DbContext;
using be_artwork_sharing_platform.Core.Dtos.Artwork;
using be_artwork_sharing_platform.Core.Dtos.General;
using be_artwork_sharing_platform.Core.Entities;
using be_artwork_sharing_platform.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace be_artwork_sharing_platform.Core.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ArtworkService(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<Artwork> GetAll()
        {
            return _context.Artworks.ToList();
        }

        public IEnumerable<Artwork> SearchArtwork(string? search, double? from, double? to, string? sortBy)
        {
            var artworks = _context.Artworks.Include(a => a.Category).AsQueryable();

            #region Filter
            if (!string.IsNullOrEmpty(search))
            {
                artworks = artworks.Where(a => a.Name.Contains(search));
            }
            if (from.HasValue)
            {
                artworks = artworks.Where(a => a.Price >= from);
            }
            if (to.HasValue)
            {
                artworks = artworks.Where(a => a.Price <= to);
            }
            #endregion

            #region Sorting
            //Default sort by Name (TenHh)
            artworks = artworks.OrderBy(hh => hh.Name);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "price_asc":
                        artworks = artworks.OrderBy(a => a.Price);
                        break;
                    case "price_desc":
                        artworks = artworks.OrderByDescending(a => a.Price);
                        break;
                }
            }
            #endregion
            return artworks.ToList();
        }

        public IEnumerable<Artwork> GetArtworkByUserId(string user_Id)
        {
            var artworks = _context.Artworks.Where(a => a.User_Id == user_Id);
            if (artworks is null)
                return null;
            return artworks.ToList();
        }

        public Artwork GetById(long id)
        {
            return _context.Artworks.Find(id) ?? throw new Exception("Artwork not found");
        }

        public async Task CreateArtwork(CreateArtwork artworkDto, string user_Id)
        {
            var artwork = new Artwork
            {
                User_Id = user_Id,
                Category_Name = artworkDto.Category_Name,
                Name = artworkDto.Name,
                Description = artworkDto.Description,
                Price = artworkDto.Price,
            };
            if (artworkDto.ImageFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Images", artworkDto.ImageFile.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await artworkDto.ImageFile.CopyToAsync(stream);
                }
                artwork.Url_Image = "/Images/" + artworkDto.ImageFile.FileName;
            }
            else
            {
                artwork.Url_Image = "";
            }
            await _context.Artworks.AddAsync(artwork);
            await _context.SaveChangesAsync();
        }

        public int Delete(long id)
        {
            var artwork = _context.Artworks.Find(id) ?? throw new Exception("Artwork not found");
            _context.Remove(artwork);
            return _context.SaveChanges();
        }
    }
}
