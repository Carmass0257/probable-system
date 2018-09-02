using System;
using CM.TesteAspNetMvc.Dominio.Entidades;
using CM.TesteAspNetMvc.Dominio.Interfaces.Repositorio;
using CM.TesteAspNetMvc.Dominio.Interfaces.Serviço;

namespace CM.TesteAspNetMvc.Dominio.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        public void Dispose()
        {
            _usuarioRepositorio.Dispose();
        }

        public Usuario Adicionar(Usuario usuario)
        {
            if (!usuario.EstaValido()) return usuario;

            return _usuarioRepositorio.Adicionar(usuario);
        }

        public Usuario Editar(Usuario usuario)
        {
            if (!usuario.EstaValido()) return usuario;

            return _usuarioRepositorio.Editar(usuario);
        }

        public void Remover(Guid id)
        {
            _usuarioRepositorio.Remover(id);
        }
    }
}