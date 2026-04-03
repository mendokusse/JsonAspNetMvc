using JsonMvcApp.Models;
using JsonMvcApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace JsonMvcApp.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ProductFileService _fileService;

        [BindProperty]
        public Product Product { get; set; } = new();


    }
}
