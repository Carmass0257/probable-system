using System;
using System.Collections.Generic;
using CM.TesteAspNetMvc.Aplicacao.ViewModels;

namespace CM.TesteAspNetMvc.Aplicacao.Interfaces
{
    public interface IDetalheUsuarioAppService : IDisposable
    {
        UsuarioDetalhesUsuarioViewModel Adicionar(UsuarioDetalhesUsuarioViewModel usuario);
        DetalheUsuarioViewModel ObterPorId(Guid id);
        IEnumerable<DetalheUsuarioViewModel> ObterTodos();
        UsuarioDetalhesUsuarioViewModel Atualizar(UsuarioDetalhesUsuarioViewModel detalhe);
        void Remover(Guid id);
    }
}