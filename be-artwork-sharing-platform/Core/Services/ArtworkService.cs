using be_artwork_sharing_platform.Core.Entities;
using be_artwork_sharing_platform.Core.Interfaces;

namespace be_artwork_sharing_platform.Core.Services
{
    public class ArtworkService : IArtworkService
    {
        public Task<IEnumerable<Artwork>> GetAllArtworkAsync()
        {
            throw new NotImplementedException();
        }
    }
}
