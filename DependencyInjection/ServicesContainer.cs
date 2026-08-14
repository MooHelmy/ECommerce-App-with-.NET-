using Microsoft.EntityFrameworkCore;

public static class ServicesContainer
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            SqlOption =>
             {
                 SqlOption.MigrationsAssembly(typeof(ServicesContainer).Assembly.FullName);
                 SqlOption.EnableRetryOnFailure();
             }
            ),
             ServiceLifetime.Scoped
             );

        // Repositories
        services.AddScoped<IGeneric<Product>, GenericRepo<Product>>();
        services.AddScoped<IGeneric<Category>, GenericRepo<Category>>();

        // Application Services
        services.AddScoped<IProductServices, ProductServices>();      // ✅ إضافة جديدة
        services.AddScoped<ICategoryServices, CategoryServices>();    // ✅ إضافة جديدة

        return services;
    }
}