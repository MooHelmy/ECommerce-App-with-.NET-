using Microsoft.EntityFrameworkCore;

public static class ServicesContainer
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            // بستخدم السطر ده على يحطلى ملفات الميجراشن فى نفس المكان اللى انا شغال فيه 
            // بستخدم بالتالي يحطل الملفات فى مجلد bin و المكان اللى انا شغال فيه
            SqlOption =>
             {
                 SqlOption.MigrationsAssembly(typeof(ServicesContainer).Assembly.FullName);
                 // تعيين الملفات التي تحتاج للمهمة فى الميجراشن
                 SqlOption.EnableRetryOnFailure(); // تمكين المحاولة عند فشل المهمة
             }
            ),
             // تعيين المهمة فى الميجراشن بالتالي من النوع الافتراضي للمهمة و تحتاج للمهمة فى الميجراشن
             ServiceLifetime.Scoped
             );
        services.AddScoped<IGeneric<Product>, GenericRepo<Product>>();
        services.AddScoped<IGeneric<Category>, GenericRepo<Category>>();
        return services;




        // services.AddScoped<IConfiguration>(configuration);
        // services.AddScoped<IUserService, UserService>();
        // services.AddScoped<IProductService, ProductService>();
        // services.AddScoped<ICategoryService, CategoryService>();
        // services.AddScoped<IProductCategoryService, ProductCategoryService>();

    }
}