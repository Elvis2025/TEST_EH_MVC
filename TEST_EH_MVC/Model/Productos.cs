using Dapper.Contrib.Extensions;

namespace TEST_EH_MVC.Model
{
    [Table("Productos")]
    public class Productos
    {
        [Key]
        public int ProID { get; set; } = new();
        public string? ProNombre { get; set; } = string.Empty;
        public string? ProDecripcion { get; set; } = string.Empty;
        public decimal ProCosto { get; set; } = new();
        public decimal ProPrecio { get; set; } = new();
        public int ProEstado { get; set; } = new();
        public DateTime ProFechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
