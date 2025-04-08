using Dapper.Contrib.Extensions;

namespace TEST_EH_MVC.Model
{
    [Table("Categorias")]
    public class Categorias
    {
        [Key]
        public int CatID { get; set; } = new();
        public string? CatNombre { get; set; } = string.Empty;
        public string? CatDescripcion { get; set; } = string.Empty;
    }
}
