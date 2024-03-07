using be_artwork_sharing_platform.Core.Dtos.Category;
using be_artwork_sharing_platform.Core.Dtos.Favourite;
using be_artwork_sharing_platform.Core.Dtos.General;

namespace be_artwork_sharing_platform.Core.Interfaces
{
    public interface IFavouriteService
    {
        void AddToFavourite(string userId, long artworkId);
    }
}
