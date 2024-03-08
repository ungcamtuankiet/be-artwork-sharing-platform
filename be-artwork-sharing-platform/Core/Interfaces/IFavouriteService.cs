using be_artwork_sharing_platform.Core.Dtos.Category;
using be_artwork_sharing_platform.Core.Dtos.Favourite;
using be_artwork_sharing_platform.Core.Dtos.General;

namespace be_artwork_sharing_platform.Core.Interfaces
{
    public interface IFavouriteService
    {
        Task AddToFavourite(string userId, long artworkId);
        int RemoveArtwork(long artwork_Id, string user_Id);

    }
}
