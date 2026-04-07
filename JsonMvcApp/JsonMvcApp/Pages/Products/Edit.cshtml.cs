using JsonMvcApp.Models;
using JsonMvcApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using JsonMvcApp.Data;
using System.Threading.Tasks;

namespace JsonMvcApp.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        [BindProperty]
        public Product Product { get; set; } = new();

        public EditModel(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            Product = product;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var product = await _dbContext.Products.FindAsync(Product.Id);

            if (product == null) return NotFound();

            product.Name = Product.Name;
            product.Description = Product.Description;
            product.Price = Product.Price;

            await _dbContext.SaveChangesAsync();

            return RedirectToPage("/Products/Index");
        }
    }
}
