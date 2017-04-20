using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TemplateDDD.Domain.Interfaces.Repository;
using TemplateDDD.Infra.Data.Context;

namespace TemplateDDD.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected TemplateDDDContext DB;
        protected DbSet<TEntity> DbSet;

        public Repository()
        {
            DB = new TemplateDDDContext();
            DbSet = DB.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var entity = DbSet.Add(obj);
            SaveChanges();
            return entity;
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            DB.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        //public IEnumerable<TEntity> ObterTodosPaginado(int page,int qtd)
        //{
        //    return DbSet.Take(qtd).Skip(page).ToList();
        //}


        public virtual void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
            SaveChanges();
        }

        public virtual int SaveChanges()
        {
            return DB.SaveChanges();
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry=DB.Entry(obj);
            DbSet.Attach(obj);
            entry.State=EntityState.Modified;
            SaveChanges();
            return obj;
        }
    }
}
