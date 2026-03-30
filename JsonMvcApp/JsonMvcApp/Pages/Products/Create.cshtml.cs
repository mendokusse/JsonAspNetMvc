using JsonMvcApp.Models;
using JsonMvcApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JsonMvcApp.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ProductFileService _fileService;

        [BindProperty]
        public Product product { get; set; } = new();

        public CreateModel(ProductFileService fileService)
        {
            _fileService = fileService;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                ModelState.AddModelError("product.Name", "Название обязательно");
            }

            if (product.Price <= 0)
            {
                ModelState.AddModelError("product.Price", "Цена должна быть выше нуля");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _fileService.Add(product);
            return RedirectToPage("/Products/Index");
        }

    }
}
