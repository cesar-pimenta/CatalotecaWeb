using CatalotecaWeb.Data.Mapping;
using CatalotecaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalotecaWeb.Data.Context
{
    public class MyContext: DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        //Configuração padrão da Documentação para passar contexto na base 
        public MyContext(DbContextOptions<MyContext>options) : base (options) { }

        //Mapeamento do metodo - reescrevendo do modelbuild para o modelcreate
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<UserEntity> (new UserMap().Configure);
        }
    }
}