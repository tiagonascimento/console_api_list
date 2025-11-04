using Bank.Infra.repository.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;


namespace Bank.Infra.repository
{
    public static class DependecyInjectionExtension
    {
        public static void AddInfra(this IServiceCollection service, IConfiguration config)
        {
            addRepositorio(service);
            AddContex_Postgre(service, config);           
        }
        private static void addRepositorio(IServiceCollection service)
        {         
            service.AddScoped<IItenRepository, ItenRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        private static void AddContex_Postgre(IServiceCollection services, IConfiguration config)
        {
            var strConnection = config["ConnectionStrings:PostgresConnection"];         
         
            services.AddDbContext<BankDbContext>(opt =>
            {
                opt.UseNpgsql(strConnection);

            });
        }
    }
}
