using System;
using CM.TesteAspNetMvc.Dominio.Entidades;

namespace CM.TesteAspNetMvc.Dominio.Interfaces.Serviço
{
    public interface IUsuarioServico : IDisposable
    {
        Usuario Adicionar(Usuario usuario);
        Usuario Editar(Usuario usuario);
        void Remover(Guid id);
    }
}