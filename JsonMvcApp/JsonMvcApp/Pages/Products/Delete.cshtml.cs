using JsonMvcApp.Data;
using JsonMvcApp.Models;
using JsonMvcApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace JsonMvcApp.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        [BindProperty]
        public Product Product { get; set; } = new();

        public DeleteModel(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);

            if (product == null) return NotFound();

            Product = product;

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var product = await _dbContext.Products.FindAsync(Product.Id);

            if (product == null) return NotFound();

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/Products/Index");
        }
    }
}
