using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CatalotecaWeb.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            // Para utilização de outro banco, apenas trocar a connections string, passando as informações do Banco que você irá utilizar
            var connectionString = "Server=localhost;Port=3306;Database=dbCatalotecaWeb;Uid=root;Pwd=$senhaescondida";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql (connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}