using JsonMvcApp.Models;
using JsonMvcApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JsonMvcApp.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly ProductFileService _fileService;

        [BindProperty]
        public Product Product { get; set; } = new();

        public DeleteModel(ProductFileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult OnGet(int id)
        {
            var product = _fileService.GetById(id);

            if (product == null) return NotFound();

            Product = product;

            return Page();
        }

        public IActionResult OnPost()
        {
            var isDeleted = _fileService.Delete(Product.Id);

            if (!isDeleted) return NotFound();

            return RedirectToPage("/Products/Index");
        }
    }
}
