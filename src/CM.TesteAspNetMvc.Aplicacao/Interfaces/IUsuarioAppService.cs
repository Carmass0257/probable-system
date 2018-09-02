using System;
using System.Collections.Generic;
using CM.TesteAspNetMvc.Aplicacao.ViewModels;

namespace CM.TesteAspNetMvc.Aplicacao.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        UsuarioDetalhesUsuarioViewModel Adicionar(UsuarioDetalhesUsuarioViewModel usuario);
        UsuarioViewModel ObterPorId(Guid id);
        IEnumerable<UsuarioViewModel> ObterTodos();
        UsuarioViewModel Editar(UsuarioViewModel usuario);
        void Remover(Guid id);
    }
}