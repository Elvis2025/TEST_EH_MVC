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

        public ProductosController(IProductosRepository productosRepository, ICategoriasRepository categoriasRepository, IMapper mapper)
        {
            this.productosRepository = productosRepository;
            this.categoriasRepository = categoriasRepository;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var products = await productosRepository.GetProducts();
                if (products is null || !products.Any()) return View(new ProductosDTO() { Productos = new List<ProductosDTO>() });
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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

        public async Task<IActionResult> EditarProducto(int proID)
        {
            try
            {
                var categorias = await categoriasRepository.GetCategorias();
                var producto = await productosRepository.GetProductsByID(proID);
                var editarProducto = mapper.Map<ProductosDTO>(producto);

                //CurrentProduct = mapper.Map<ProductosDTO>(producto),
                editarProducto.Categorias = mapper.Map<List<CategoriasDTO>>(categorias.ToList());
                editarProducto.CurrentCategory = categorias.Select(c => new SelectListItem
                {
                    Value = c.CatID.ToString(),
                    Text = c.CatNombre
                }).ToList();

                return View(editarProducto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveProductoEditado(ProductosDTO producto)
        {
            try
            {
                if(!ModelState.IsValid) return View(producto);
                await productosRepository.EditarProducto(producto);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

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
