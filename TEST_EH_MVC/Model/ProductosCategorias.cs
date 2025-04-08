using Dapper.Contrib.Extensions;

namespace TEST_EH_MVC.Model;

[Table("ProductosCategorias")]
public class ProductosCategorias
{
    [Key]
    public int ProID { get; set; }
    [Key]
    public int CatID { get; set; }

}
