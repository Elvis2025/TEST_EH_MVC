using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using TEST_EH_MVC.Model;

namespace TEST_EH_MVC.DTOs
{
    public class ProductosDTO
    {
        public int ProID { get; set; } = new();
        public string? ProNombre { get; set; } = string.Empty;
        public string? CatNombre { get; set; } = string.Empty;
        public string? ProDecripcion { get; set; } = string.Empty;
        public decimal ProCosto { get; set; } = new();
        public decimal ProPrecio { get; set; } = new();
        public int ProEstado { get; set; } = new();
        public int CatID { get; set; } = new();
        public DateTime StartDate { get; set; } = new();
        public DateTime EndDate { get; set; } = new();
        public List<ProductosDTO> Productos { get; set; } = new();
        public List<CategoriasDTO> Categorias { get; set; } = new ();
        public List<SelectListItem> CurrentCategory { get; set; } = new ();
        public List<int> CatIDs { get; set; } = new();
    }
}
