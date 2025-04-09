using System.ComponentModel.DataAnnotations;

namespace TEST_EH_MVC.DTOs
{
    public class CategoriasDTO
    {
        public int CatID { get; set; } = new();
        public int ProID { get; set; } = new();
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(25, ErrorMessage = "El nombre no puede tener más de 25 caracteres.")]
        public string? CatNombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string? CatDescripcion { get; set; } = string.Empty;
        public List<CategoriasDTO> Categorias { get; set; } = new();

    }
}
