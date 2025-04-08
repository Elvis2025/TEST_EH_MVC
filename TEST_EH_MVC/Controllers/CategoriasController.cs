using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TEST_EH_MVC.DTOs;
using TEST_EH_MVC.Model;

namespace TEST_EH_MVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriasRepository repository;
        private readonly IMapper mapper;

        public CategoriasController(ICategoriasRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var categorias = await repository.GetCategorias();
            var categoriaDTO = new CategoriasDTO()
            {
                Categorias = mapper.Map<List<CategoriasDTO>>(categorias),
            };
            return View(categoriaDTO);
        }

        public async Task<IActionResult> AddCategoria(CategoriasDTO currentProduct)
        {
            try
            {
                await repository.AddCategoria(mapper.Map<Categorias>(currentProduct));
                return RedirectToAction("Index");
            }
            catch (Exception  e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
