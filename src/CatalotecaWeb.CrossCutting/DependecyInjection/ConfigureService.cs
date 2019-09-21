using CatalotecaWeb.Domain.Interfaces.Services.Product;
using CatalotecaWeb.Domain.Interfaces.Services.User;
using CatalotecaWeb.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CatalotecaWeb.CrossCutting.DependecyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            // Tansient, para cada injeção de dependencia ele cria uma instancia User, Singled > cria uma para todos , Scoped > cria após 10 chamadas iguais. 
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IProductService, ProductService>();
        }
    }
}
