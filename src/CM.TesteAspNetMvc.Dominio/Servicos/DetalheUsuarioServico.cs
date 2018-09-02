using System;
using CM.TesteAspNetMvc.Dominio.Entidades;
using CM.TesteAspNetMvc.Dominio.Interfaces.Repositorio;
using CM.TesteAspNetMvc.Dominio.Interfaces.Serviço;

namespace CM.TesteAspNetMvc.Dominio.Servicos
{
    public class DetalheUsuarioServico:IDetalheServico
    {
        private readonly IDetalheRepositorio _detalheRepositorio;

        public DetalheUsuarioServico(IDetalheRepositorio detalheRepositorio)
        {
            _detalheRepositorio = detalheRepositorio;
        }

        public void Dispose()
        {
            _detalheRepositorio.Dispose();
        }

        public DetalheUsuario Adicionar(DetalheUsuario detalhe)
        {
            if (!detalhe.EstaValido()) return detalhe;

            return _detalheRepositorio.Adicionar(detalhe);
        }

        public DetalheUsuario Editar(DetalheUsuario detalhe)
        {
            if (!detalhe.EstaValido()) return detalhe;

            return _detalheRepositorio.Editar(detalhe);
        }

        public void Remover(Guid id)
        {
            _detalheRepositorio.Remover(id);
        }
    }
}