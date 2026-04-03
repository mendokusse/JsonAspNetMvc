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

        public List<Product> GetAll()
        {
            var json = File.ReadAllText(_filePath);

            if (string.IsNullOrEmpty(json))
            {
                return new List<Product>();
            }

            var products = JsonSerializer.Deserialize<List<Product>>(json);

            return products ?? new List<Product>();
        }

        public void Add(Product product)
        {
            var products = GetAll();

            product.Id = products.Count == 0 ? 1 : products.Max(p => p.Id) + 1;

            products.Add(product);

            SaveAll(products);
        }

        private void SaveAll(List<Product> products)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize(products, options);

            File.WriteAllText(_filePath, json);
        }

        public Product? GetById(int id)
        {
            var products = GetAll();

            return products.FirstOrDefault(p => p.Id == id);
        }

        public bool Delete(int id)
        {
            var products = GetAll();

            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null) return false;

            products.Remove(product);
            SaveAll(products);
            return true;
        }

        public bool Update(Product updatedProduct)
        {
            var products = GetAll();

            var index = products.FindIndex(p=> p.Id == updatedProduct.Id);

            if (index == -1) return false;

            products[index] = updatedProduct;

            SaveAll(products);
            return true;
        }
    }
}
