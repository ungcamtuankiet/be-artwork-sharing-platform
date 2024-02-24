using AutoMapper;
using be_artwork_sharing_platform.Core.Constancs;
using be_artwork_sharing_platform.Core.Dtos.Category;
using be_artwork_sharing_platform.Core.Dtos.General;
using be_artwork_sharing_platform.Core.Entities;
using be_artwork_sharing_platform.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace be_artwork_sharing_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly ILogService _logService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoryController(IMapper mapper, ICategoryService categoryService, ILogService logService, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _logService = logService;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("get-all-category")]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();
            
            return Ok(_mapper.Map<List<CategoryDto>>(categories));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                var category = _categoryService.GetById(id);
                if (category is null) return NotFound("Category not found");
                return Ok(_mapper.Map<CategoryDto>(category));
            }
            catch
            {
                return BadRequest("Something wrong");
            }
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = StaticUserRole.ADMIN)]
        public IActionResult CreateCategory([FromBody] CreateCategory category)
        {
            try
            {
                var result = _categoryService.CreateCategory(new Category
                {
                    Name = category.Name,
                });

                if(result > 0)
                {
                    return Ok(new GeneralServiceResponseDto
                    {
                        IsSucceed = true,
                        StatusCode = 204,
                        Message = "Create successfully"
                    });
                }
                else
                {
                    return BadRequest(new GeneralServiceResponseDto
                    {
                        IsSucceed= false,
                        StatusCode = 400,
                        Message = "Create failed"
                    });
                }
            }
            catch
            {
                return BadRequest("Error creating category");
            }
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = StaticUserRole.ADMIN)]
        public IActionResult DeleteCategory(long id)
        {
            try
            {
                var result = _categoryService.Delete(id);
                if(result > 0)
                {
                    return Ok(new GeneralServiceResponseDto
                    {
                        IsSucceed = true,
                        StatusCode = 200,
                        Message = "Delete Successfully"
                    });
                }
                else
                {
                    return BadRequest(new GeneralServiceResponseDto
                    {
                        IsSucceed = false,
                        StatusCode = 400,
                        Message = "Delete Failed"
                    });
                }
            }
            catch
            {
                return BadRequest("Error delete category");
            }
        }
    }
}
