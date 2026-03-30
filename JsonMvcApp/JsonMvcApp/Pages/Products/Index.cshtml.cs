using JsonMvcApp.Models;
using JsonMvcApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JsonMvcApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ProductFileService productFileService;

        public List<Product> Products { get; set; } = new();

        public IndexModel(ProductFileService productFileService)
        {
            this.productFileService = productFileService;
        }

        public void OnGet()
        {
            Products = productFileService.GetAll();
        }
    }
}
