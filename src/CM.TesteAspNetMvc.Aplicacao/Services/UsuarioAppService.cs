using System;
using System.Collections.Generic;
using AutoMapper;
using CM.TesteAspNetMvc.Aplicacao.Interfaces;
using CM.TesteAspNetMvc.Aplicacao.ViewModels;
using CM.TesteAspNetMvc.Dominio.Interfaces.Repositorio;
using CM.TesteAspNetMvc.Dominio.Interfaces.Serviço;
using CM.TesteAspNetMvc.Infra.Dados.Interfaces;

namespace CM.TesteAspNetMvc.Aplicacao.Services
{
    public class UsuarioAppService:AppService,IUsuarioAppService
    {
        private readonly IUsuarioServico _usuarioServico;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioAppService(IUnitOfWork unitOfWork, IUsuarioServico usuarioServico, IUsuarioRepositorio usuarioRepositorio) : base(unitOfWork)
        {
            _usuarioServico = usuarioServico;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public void Dispose()
        {
            _usuarioRepositorio.Dispose();
        }

        public UsuarioDetalhesUsuarioViewModel Adicionar(UsuarioDetalhesUsuarioViewModel usuario)
        {
            throw new NotImplementedException();
        }

        public UsuarioViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<UsuarioViewModel>(_usuarioRepositorio.ObterPorId(id));
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioRepositorio.ObterTodos());
        }

        public UsuarioViewModel Editar(UsuarioViewModel usuario)
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            _usuarioServico.Remover(id);
        }
    }
}