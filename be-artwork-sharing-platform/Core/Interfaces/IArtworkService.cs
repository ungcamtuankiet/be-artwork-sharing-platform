using be_artwork_sharing_platform.Core.Dtos.Artwork;
using be_artwork_sharing_platform.Core.Dtos.General;
using be_artwork_sharing_platform.Core.Entities;
using System.Security.Claims;

namespace be_artwork_sharing_platform.Core.Interfaces
{
    public interface IArtworkService
    {
        IEnumerable<Artwork> GetAll();
        IEnumerable<Artwork> SearchArtwork(string? search, string? searchBy, double? from, double? to, string? sortBy);
        Artwork GetById(long id);
        IEnumerable<Artwork> GetArtworkByUserId(string user_Id);
        Task CreateArtwork(CreateArtwork artworkDto, string user_Id, string user_Name);
        int Delete(long id);
        Task UpdateArtwork(long id, UpdateArtwork updateArtwork);
    }
}
