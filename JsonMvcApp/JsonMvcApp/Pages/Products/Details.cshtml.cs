using JsonMvcApp.Services;
using JsonMvcApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace JsonMvcApp.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ProductFileService _fileService;

        public Product? Product { get; set; }

        public DetailsModel(ProductFileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult OnGet(int id)
        {
            Product = _fileService.GetById(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
