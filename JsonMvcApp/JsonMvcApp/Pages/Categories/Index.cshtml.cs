using JsonMvcApp.Data;
using JsonMvcApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JsonMvcApp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public List<Category> Categories { get; set; } = new();

        public IndexModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task OnGet()
        {
            Categories = await _dbContext.Categories.ToListAsync();
        }
    }
}
