using be_artwork_sharing_platform.Core.DbContext;
using be_artwork_sharing_platform.Core.Dtos.Category;
using be_artwork_sharing_platform.Core.Dtos.General;
using be_artwork_sharing_platform.Core.Entities;
using be_artwork_sharing_platform.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace be_artwork_sharing_platform.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogService _logService;

        public CategoryService(ApplicationDbContext context, ILogService logService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logService = logService;
            _userManager = userManager;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Find(id) ?? throw new Exception("Category not found");
        }

        public int CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            return _context.SaveChanges();
        }

        public int DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id) ?? throw new Exception("Category not found");
            _context.Remove(category);
            return _context.SaveChanges();
        }
    }
}
