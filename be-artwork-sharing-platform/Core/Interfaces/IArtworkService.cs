using be_artwork_sharing_platform.Core.Dtos.Artwork;
using be_artwork_sharing_platform.Core.Dtos.General;
using be_artwork_sharing_platform.Core.Entities;
using System.Security.Claims;

namespace be_artwork_sharing_platform.Core.Interfaces
{
    public interface IArtworkService
    {
        IEnumerable<Artwork> GetAll();
        Artwork GetById(long id);
        Task CreateArtwork(CreateArtwork artworkDto, string user_Id);
        int Delete(long id);
        
    }
}
