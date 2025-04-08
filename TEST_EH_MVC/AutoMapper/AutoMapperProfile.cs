using AutoMapper;
using TEST_EH_MVC.DTOs;
using TEST_EH_MVC.Model;

namespace TEST_EH_MVC.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Categorias,CategoriasDTO>().ReverseMap();
            CreateMap<Productos,ProductosDTO>().ReverseMap();
        }
    }
}
