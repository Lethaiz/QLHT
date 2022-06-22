using Microsoft.EntityFrameworkCore;

namespace WebHocTap

{
    public static class Connect
    {
        public static IServiceCollection ServicesCollection(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<DbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Context"),
               x => x.MigrationsAssembly(typeof(DbContext).Assembly.FullName)), ServiceLifetime.Transient);

            return service;
        }
    }
}