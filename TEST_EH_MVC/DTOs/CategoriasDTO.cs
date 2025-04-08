namespace TEST_EH_MVC.DTOs
{
    public class CategoriasDTO
    {
        public int CatID { get; set; } = new();
        public int ProID { get; set; } = new();
        public string? CatNombre { get; set; } = string.Empty;
        public string? CatDescripcion { get; set; } = string.Empty;
        public List<CategoriasDTO> Categorias = new();

    }
}
