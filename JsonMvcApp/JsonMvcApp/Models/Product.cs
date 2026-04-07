using System.ComponentModel.DataAnnotations;

namespace JsonMvcApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название обязательно!")]
        [StringLength(100, ErrorMessage = "Название не должно быть длиннее 100 символов!")]
        public string Name { get; set; }

        [Range(0.01, 10000000, ErrorMessage = "Цена должна быть больше нуля")]
        public decimal Price { get; set; }

        [StringLength(500, ErrorMessage = "Описание не должно быть длиннее 500 символов!")]
        public string Description { get; set; }
    }
}
