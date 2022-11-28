using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LoanAPI.Models
{
    public class ThingDTOViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Descripciones")]
        [MaxLength(30, ErrorMessage = "Solo puede tener hasta 30 caracteres")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Categorias")]
        public int CategoryId { get; set; }
    }
}
