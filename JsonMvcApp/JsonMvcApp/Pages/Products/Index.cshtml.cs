using JsonMvcApp.Data;
using JsonMvcApp.Models;
using JsonMvcApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JsonMvcApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        //private readonly ProductFileService productFileService;

        private readonly AppDbContext _dbContext;

        public List<Product> Products { get; set; } = new();

        public IndexModel(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task OnGet()
        {
            Products = await _dbContext.Products.ToListAsync();
        }
    }
}
