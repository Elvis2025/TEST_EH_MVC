using TEST_EH_MVC.Repositories;

namespace TEST_EH_MVC
{
    public static class ServicesExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDBConnection, DBConnection>()
            .AddTransient<ICategoriasRepository, CategoriasRepository>()
            .AddTransient<IProductosRepository, ProductosRepository>();
            return services;
        }
    }
}
