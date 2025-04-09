using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TEST_EH_MVC.DTOs;

public class ProductosDTO
{
    public int ProID { get; set; } = new();
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [StringLength(25, ErrorMessage = "El nombre no puede tener más de 25 caracteres.")]
    public string? ProNombre { get; set; } = string.Empty;
    public string? CatNombre { get; set; } = string.Empty;
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string? ProDecripcion { get; set; } = string.Empty;
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Este campo debe ser mayor a 0.")]
    public decimal ProCosto { get; set; } = new();

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Este campo debe ser mayor a 0.")]
    public decimal ProPrecio { get; set; } = new();

    [Required(ErrorMessage = "Este campo es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Este campo debe ser mayor a 0.")]
    public int ProEstado { get; set; } = new();

    public int CatID { get; set; } = new();
    public DateTime StartDate { get; set; } = new();
    public DateTime EndDate { get; set; } = new();
    public List<ProductosDTO> Productos { get; set; } = new();
    public List<CategoriasDTO> Categorias { get; set; } = new ();
    public List<SelectListItem> CurrentCategory { get; set; } = new ();
    [Required(ErrorMessage = "Debes seleccionar al menos una categoria")]
    public List<int> CatIDs { get; set; } = new();
}
