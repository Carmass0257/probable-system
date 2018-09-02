using System;
using CM.TesteAspNetMvc.Dominio.Entidades;

namespace CM.TesteAspNetMvc.Dominio.Interfaces.Serviço
{
    public interface IDetalheServico : IDisposable
    {
        DetalheUsuario Adicionar(DetalheUsuario detalhe);
        DetalheUsuario Editar(DetalheUsuario detalhe);
        void Remover(Guid id);
    }
}