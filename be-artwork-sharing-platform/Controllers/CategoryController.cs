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
        private readonly ICategoryService _categoryService;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, ILogService logService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _categoryService = categoryService;
            _logService = logService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var category = _categoryService.GetById(id);
                if(category == null)
                {
                    return NotFound("Category not found");
                }
                else
                {
                    return Ok(_mapper.Map<CategoryDto>(category));
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Something wrong");
            }
        }

        [HttpPost]
        [Route("create-category")]
        [Authorize(Roles = StaticUserRole.ADMIN)]
        public IActionResult Create([FromBody] CreateCategory createCategory)
        {
            try
            {
                var result = _categoryService.CreateCategory(new Category
                {
                    Name = createCategory.Name, 
                });

                if(result > 0)
                {
                    return Ok(new GeneralServiceResponseDto
                    {
                        IsSucceed = true,
                        StatusCode = 200,
                        Message = "Create successfully"
                    });
                }
                else
                {
                    return BadRequest("Create failed");
                }
            }
            catch
            {
                return BadRequest("Error creating category");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = StaticUserRole.ADMIN)]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            try
            {
                var result = (_categoryService.DeleteCategory(id));
                if(result > 0)
                {
                    return Ok(new GeneralServiceResponseDto()
                    {
                        IsSucceed= true,
                        StatusCode = 200,
                        Message = "Delete Successfully"
                    });
                }
                else
                {
                    return BadRequest("Delete failed");
                }
            }
            catch
            {
                return BadRequest("Error delete category");
            }
        }
    }
}
