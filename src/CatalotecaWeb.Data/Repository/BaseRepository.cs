using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalotecaWeb.Data.Context;
using CatalotecaWeb.Domain.Entities;
using CatalotecaWeb.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalotecaWeb.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {   
        // Disponibiliza o metodo para fora da class
        protected readonly MyContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public async Task<T> InsertAsync (T item){
            try
            {
                // Analisa se o ID está vazio, se tiver vazio ele atribui um novo Guid. 
                if (item.Id == Guid.Empty){
                    item.Id = Guid.NewGuid();
                } 
                // Recebe a data atual. 
                item.CreateAt = DateTime.UtcNow;
                _dataset.Add(item);

                //Salva no banco
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }
        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                // Seleciona no banco o ID do item e guarda nessa variavel.
                var result = await _dataset.SingleOrDefaultAsync( p => p.Id.Equals(item.Id));
                // Garantir que qualquer dado que não seja do banco de dados, altere alguma coisa do banco de dados.
                if (result == null)
                    return null;
                // Grava a Alteração
                item.UpdateAt = DateTime.UtcNow;
                // Mantem data de Criação
                item.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();                
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return item;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync( p => p.Id.Equals(id));
                if (result == null)
                    return false;                

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public async Task<bool> ExistAsync (Guid id){
            return await _dataset.AnyAsync ( p => p.Id.Equals (id));
        }
        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync (p => p.Id.Equals (id));
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                // Retorno de lista, mas pesquisar a melhor forma de fazer com WHERE. 
                return await _dataset.ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        
    }
}
