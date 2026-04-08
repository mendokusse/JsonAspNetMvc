using JsonMvcApp.Data;
using JsonMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JsonMvcApp.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        [BindProperty]
        public Product product { get; set; } = new();

        public SelectList CategoryOptions { get; set; } = default!;

        public CreateModel(AppDbContext context)
        {
            _dbContext = context;
        }

        private async Task LoadCategoriesAsync()
        {
            var categories = await _dbContext.Categories.ToListAsync();

            CategoryOptions = new SelectList(categories, "Id", "Name");
        }

        public async Task OnGet()
        {
            await LoadCategoriesAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                await LoadCategoriesAsync();
                return Page();
            }

            _dbContext.Products.Add(product);

            await _dbContext.SaveChangesAsync();
            
            return RedirectToPage("/Products/Index");
        }

    }
}
