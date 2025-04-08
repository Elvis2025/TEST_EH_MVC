using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TEST_EH_MVC.DTOs;
using TEST_EH_MVC.Model;

namespace TEST_EH_MVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductosRepository productosRepository;
        private readonly ICategoriasRepository categoriasRepository;
        private readonly IMapper mapper;

        public ProductosController(IProductosRepository productosRepository,ICategoriasRepository categoriasRepository, IMapper mapper)
        {
            this.productosRepository = productosRepository;
            this.categoriasRepository = categoriasRepository;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var products = await productosRepository.GetProducts();
            var productsIds = products.Select(x => x.ProID);
            var categorias = await categoriasRepository.GetCategoriasByProIDs(productsIds.ToList());
            var ProductosDTO = new ProductosDTO
            {
                Productos = mapper.Map<List<ProductosDTO>>(products.ToList()),
                Categorias = categorias.ToList(),
                CurrentCategory = categorias.Select(c => new SelectListItem
                {
                    Value = c.CatID.ToString(),
                    Text = c.CatNombre
                }).ToList()
            };
            return View(ProductosDTO);
        }

        public async Task<IActionResult> CrearProducto()
        {
            var categorias = await categoriasRepository.GetCategorias();
            var ProductosDTO = new ProductosDTO
            {
                Categorias = mapper.Map<List<CategoriasDTO>>(categorias.ToList()),
                CurrentCategory = categorias.Select(c => new SelectListItem
                {
                    Value = c.CatID.ToString(),
                    Text = c.CatNombre
                }).ToList()
            };
            return View(ProductosDTO);
        }


        [HttpPost]
        public async Task<IActionResult> AddProducts(ProductosDTO currentProduct)
        {
            try
            {
                await productosRepository.AddProducts(currentProduct);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> EditarProducto(int proID)
        {
            try
            {
                await productosRepository.GetProductsByID(proID);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> EliminarProducto(int proID)
        {
            try
            {
                await productosRepository.DeleteProduct(proID);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
