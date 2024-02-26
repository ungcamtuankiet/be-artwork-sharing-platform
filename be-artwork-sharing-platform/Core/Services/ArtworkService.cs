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

        public Artwork GetById(long id)
        {
            return _context.Artworks.Find(id) ?? throw new Exception("Artwork not found");
        }

        public async Task CreateArtwork(CreateArtwork artworkDto, string user_Id)
        {
            artworkDto.Url_Image = await SaveImage(artworkDto.ImageFile);
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

        public int Delete(long id)
        {
            var artwork =  _context.Artworks.Find(id) ?? throw new Exception("Artwork not found");
            _context.Remove(artwork);
            return _context.SaveChanges();
        }

        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}
