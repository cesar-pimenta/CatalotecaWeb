using CatalotecaWeb.Data.Context;
using CatalotecaWeb.Data.Repository;
using CatalotecaWeb.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CatalotecaWeb.CrossCutting.DependecyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository (IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddDbContext<MyContext> (
                options => options.UseMySql ("Server=localhost;Port=3306;Database=dbCatalotecaWeb;Uid=root;Pwd=Chile@2019")
            );
        }
    }
}