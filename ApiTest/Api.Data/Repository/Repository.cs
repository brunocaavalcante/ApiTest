using Api.Business.Interfaces;
using Api.Business.Models;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MyDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(MyDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        public Task Adicionar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public Task<TEntity> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
    }
}
