using System;
using System.Collections.Generic;
using AutoMapper;
using CM.TesteAspNetMvc.Aplicacao.Interfaces;
using CM.TesteAspNetMvc.Aplicacao.ViewModels;
using CM.TesteAspNetMvc.Dominio.Entidades;
using CM.TesteAspNetMvc.Dominio.Interfaces.Repositorio;
using CM.TesteAspNetMvc.Dominio.Interfaces.Serviço;
using CM.TesteAspNetMvc.Infra.Dados.Interfaces;

namespace CM.TesteAspNetMvc.Aplicacao.Services
{
    public class DetalheUsuarioAppService:AppService,IDetalheUsuarioAppService
    {
        private readonly IDetalheServico _servico;
        private readonly IDetalheRepositorio _repositorio;
        private readonly IUsuarioServico _usuarioServico;

        public DetalheUsuarioAppService(IUnitOfWork unitOfWork, IDetalheServico servico, IDetalheRepositorio repositorio, IUsuarioServico usuarioServico) : base(unitOfWork)
        {
            _servico = servico;
            _repositorio = repositorio;
            _usuarioServico = usuarioServico;
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public UsuarioDetalhesUsuarioViewModel Adicionar(UsuarioDetalhesUsuarioViewModel usuario)
        {
            var detalheDmn = Mapper.Map<DetalheUsuario>(usuario.DetalheUsuarioViewModel);
            var usuarioDmn = Mapper.Map<Usuario>(usuario.UsuarioViewModel);

            detalheDmn.Usuarios.Add(usuarioDmn);

            var detalheReturn = _servico.Adicionar(detalheDmn);
            if (detalheReturn.ValidationResult.IsValid)
            {
                Commit();
            }
            usuario.DetalheUsuarioViewModel = Mapper.Map<DetalheUsuarioViewModel>(detalheReturn);
            return usuario;
        }

        public DetalheUsuarioViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<DetalheUsuarioViewModel>(_repositorio.ObterPorId(id));
        }

        public IEnumerable<DetalheUsuarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<DetalheUsuarioViewModel>>(_repositorio.ObterTodos());
        }

        public UsuarioDetalhesUsuarioViewModel Atualizar(UsuarioDetalhesUsuarioViewModel detalhe)
        {
            var detalheDmn = Mapper.Map<DetalheUsuario>(detalhe.DetalheUsuarioViewModel);
            var usuarioDmn = Mapper.Map<Usuario>(detalhe.UsuarioViewModel);

          //  var detalheReturn = _servico.Editar(detalheDmn);
            //if (detalheReturn.ValidationResult.IsValid)
            //{ Commit(); }

            usuarioDmn.DetalheUsuarioId = detalheDmn.Id;
            var usuarioRet = _usuarioServico.Editar(usuarioDmn);

            if(usuarioRet.ValidationResult.IsValid )
            { Commit();}

            detalhe.DetalheUsuarioViewModel = Mapper.Map<DetalheUsuarioViewModel>(detalheDmn);
            detalhe.UsuarioViewModel = Mapper.Map<UsuarioViewModel>(usuarioRet);
            return detalhe;
        }

        public void Remover(Guid id)
        {
            _repositorio.Remover(id);
        }
    }
}