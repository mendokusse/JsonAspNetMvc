using JsonMvcApp.Data;
using JsonMvcApp.Models;
using JsonMvcApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JsonMvcApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public List<Product> Products { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }

        public List<Category> Categories { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SortOrder { get; set; }

        public IndexModel(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task OnGet()
        {
            Categories = await _dbContext.Categories.ToListAsync();
            
            var query = _dbContext.Products.Include(p => p.Category).AsQueryable();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                query = query.Where(p => p.Name.Contains(SearchTerm));
            }

            if (CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == CategoryId.Value);
            }



            Products = await _dbContext.Products.ToListAsync();
        }
    }
}
