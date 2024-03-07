using be_artwork_sharing_platform.Core.Dtos.Artwork;
using be_artwork_sharing_platform.Core.Dtos.Auth;
using be_artwork_sharing_platform.Core.Dtos.General;
using be_artwork_sharing_platform.Core.Entities;
using System.Security.Claims;

namespace be_artwork_sharing_platform.Core.Interfaces
{
    public interface IAuthService
    {
        Task<GeneralServiceResponseDto> SeedRoleAsync();
        Task<GeneralServiceResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<LoginServiceResponceDto?> LoginAsync(LoginDto loginDto);
        Task<GeneralServiceResponseDto> UpdateRoleAsync(ClaimsPrincipal User, UpdateRoleDto updateRoleDto);
        Task<LoginServiceResponceDto> MeAsync(MeDto meDto);
        Task<IEnumerable<UserInfoResult>> GetUserListAsync();
        Task<UserInfoResult?> GetUserDetailsByUserNameAsyncs(string userName);
        Task<string> GetCurrentUserId(string username);
        Task<string> GetCurrentUserName(string username);
        Task<string> GetPasswordCurrentUserName(string username);
        Task<IEnumerable<string>> GetUsernameListAsync();
        Task UpdateUser(UpdateUser updateUser, string userId);
        void ChangePassword(ChangePassword changePassword, string userID);
    }
}
