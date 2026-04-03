using JsonMvcApp.Models;
using JsonMvcApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace JsonMvcApp.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ProductFileService _fileService;

        [BindProperty]
        public Product Product { get; set; } = new();

        public EditModel(ProductFileService fileService)
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
            if (string.IsNullOrEmpty(Product.Name))
            {
                ModelState.AddModelError("Product.Name", "Название обязательно");
            }

            if (Product.Price <= 0)
            {
                ModelState.AddModelError("Product.Price", "Цена должна быть больше 0");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var isUpdated = _fileService.Update(Product);

            if (!isUpdated) return NotFound();

            return RedirectToPage("/Products/Index");
        }
    }
}
