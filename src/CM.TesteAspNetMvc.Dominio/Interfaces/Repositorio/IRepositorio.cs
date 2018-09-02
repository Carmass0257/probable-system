using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CM.TesteAspNetMvc.Dominio.Interfaces.Repositorio
{
    public interface IRepositorio<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity entity);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        TEntity Editar(TEntity entity);
        void Remover(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado);
        int SaveChanges();
    }
}