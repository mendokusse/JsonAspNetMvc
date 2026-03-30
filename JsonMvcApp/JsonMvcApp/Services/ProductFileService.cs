using JsonMvcApp.Models;
using System.Text.Json;

namespace JsonMvcApp.Services
{
    public class ProductFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment; // Окружение приложения
        private readonly string _filePath; // Путь к JSON-файлу

        public ProductFileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;

            var dataFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "Data");

            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            _filePath = Path.Combine(dataFolder, "products.json");

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }


    }
}
