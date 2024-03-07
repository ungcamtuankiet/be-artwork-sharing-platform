using be_artwork_sharing_platform.Core.Constancs;
using be_artwork_sharing_platform.Core.DbContext;
using be_artwork_sharing_platform.Core.Dtos.Favourite;
using be_artwork_sharing_platform.Core.Dtos.General;
using be_artwork_sharing_platform.Core.Entities;
using be_artwork_sharing_platform.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace be_artwork_sharing_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly IFavouriteService _favouriteService;
        private readonly IAuthService _authService;
        private readonly ILogService _logService;
        private readonly ApplicationDbContext _context;

        public FavouriteController(IFavouriteService favouriteService, IAuthService authService, ILogService logService, ApplicationDbContext context)
        {
            _favouriteService = favouriteService;
            _authService = authService;
            _logService = logService;
            _context = context;
        }

        [HttpPost]
        [Route("add-favourite")]
        [Authorize(Roles = StaticUserRole.CUSTOMER)]
        public async Task<IActionResult> AddFavourite(long artwork_Id)
        {
            try
            {
                string userName = HttpContext.User.Identity.Name;
                string userId = await _authService.GetCurrentUserId(userName);
                string userNameCurrent = await _authService.GetCurrentUserName(userName);
                FavouriteDto favouriteDto = new FavouriteDto();
                var checkArtwork = _context.Artworks.FirstOrDefault(a => a.Id == artwork_Id);
                if (checkArtwork == null)
                {
                    return BadRequest(new GeneralServiceResponseDto()
                    {
                        IsSucceed = false,
                        StatusCode = 404,
                        Message = "Artwork not found"
                    });
                }
                else
                {
                    var addArtworkToFavourite = _context.Favorites.FirstOrDefault(f => f.Artwork_Id == artwork_Id);
                    if (addArtworkToFavourite != null)
                    {
                        return NotFound(new GeneralServiceResponseDto()
                        {
                            IsSucceed = false,
                            StatusCode = 400,
                            Message = "Artwork already have in your Favourite"
                        });
                    }
                    else
                    {
                        _favouriteService.AddToFavourite(userId, artwork_Id);
                        _logService.SaveNewLog(userNameCurrent, "Add Artwork to Favourite");
                        return Ok(new GeneralServiceResponseDto()
                        {
                            IsSucceed = true,
                            StatusCode = 200,
                            Message = "Add Artwork to your favourite successfully"
                        });
                    }
                }
            }
            catch
            {
                return BadRequest("Something wrong");
            }
        }

        [HttpDelete]
        [Route("remove-artwork")]
        [Authorize(Roles = StaticUserRole.CUSTOMER)]
        public async Task<IActionResult> RemoveArtwork(long favourite_Id)
        {
            try
            {
                string userName = HttpContext.User.Identity.Name;
                string userId = await _authService.GetCurrentUserId(userName);
                _favouriteService.RemoveArtwork(favourite_Id, userId);
                return Ok("Removed the Artwork from your favorites successfully");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
