using JsonMvcApp.Data;
using JsonMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JsonMvcApp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        [BindProperty]
        public Category Category { get; set; } = new();

        public CreateModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _dbContext.Categories.Add(Category);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/Categories/Index");
        }
    }
}
