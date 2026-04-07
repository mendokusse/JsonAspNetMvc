using JsonMvcApp.Data;
using JsonMvcApp.Models;
using JsonMvcApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JsonMvcApp.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        [BindProperty]
        public Product product { get; set; } = new();

        public CreateModel(AppDbContext context)
        {
            _dbContext = context;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Products.Add(product);

            await _dbContext.SaveChangesAsync();
            
            return RedirectToPage("/Products/Index");
        }

    }
}
