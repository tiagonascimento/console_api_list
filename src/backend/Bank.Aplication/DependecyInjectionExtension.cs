
using Microsoft.Extensions.DependencyInjection;


namespace Bank.Aplication
{
    public static class DependecyInjectionExtension
    {
        public static void AddAplication(this IServiceCollection service)
        {
            adAplication(service);
          
        }
        private static void adAplication(IServiceCollection service)
        {
            service.AddScoped<IItenAplication, ItenAplication>();
         
        }   
    }
}
