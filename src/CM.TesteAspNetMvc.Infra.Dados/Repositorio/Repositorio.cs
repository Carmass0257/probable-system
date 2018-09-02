using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CM.TesteAspNetMvc.Dominio.Interfaces.Repositorio;
using CM.TesteAspNetMvc.Infra.Dados.Contexto;

namespace CM.TesteAspNetMvc.Infra.Dados.Repositorio
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        protected TesteAspNetMvcContexto Db;
        protected DbSet<TEntity> DbSet;

        public Repositorio(TesteAspNetMvcContexto contexto)
        {
            Db = contexto;
            DbSet = Db.Set<TEntity>();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public TEntity Adicionar(TEntity entity)
        {
            var obj = DbSet.Add(entity);
            return obj;
        }

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public TEntity Editar(TEntity entity)
        {
            var entry = Db.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            return entity;
        }

        public void Remover(Guid id)
        {
            var obj = ObterPorId(id);
            DbSet.Remove(obj);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado)
        {
            return DbSet.Where(predicado);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}