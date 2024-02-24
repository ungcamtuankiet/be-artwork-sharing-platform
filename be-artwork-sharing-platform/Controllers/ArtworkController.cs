using AutoMapper;
using be_artwork_sharing_platform.Core.Constancs;
using be_artwork_sharing_platform.Core.Dtos.Artwork;
using be_artwork_sharing_platform.Core.Dtos.General;
using be_artwork_sharing_platform.Core.Entities;
using be_artwork_sharing_platform.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace be_artwork_sharing_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtworkController : ControllerBase
    {
        private readonly IArtworkService _artworkService;
        private readonly IAuthService _authService;

        public ArtworkController(IArtworkService artworkService, IAuthService authService)
        {
            _artworkService = artworkService;
            _authService = authService;
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = StaticUserRole.CREATOR)]
        public async Task<IActionResult> Create([FromBody] CreateArtwork artworkDto)
        {
            try
            {
                string userName = HttpContext.User.Identity.Name;
                string userId = await _authService.GetCurrentUserId(userName);
                await _artworkService.CreateArtwork(artworkDto, userId);
                return Ok(new GeneralServiceResponseDto()
                {
                    IsSucceed = true,
                    StatusCode = 204,
                    Message = "Create new Artwork Successfully"
                });
            }
            catch
            {
                return BadRequest("Create new Artworl Failed");
            }
        }
    }
}
