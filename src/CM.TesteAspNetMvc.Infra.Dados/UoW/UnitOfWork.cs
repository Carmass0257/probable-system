using CM.TesteAspNetMvc.Infra.Dados.Contexto;
using CM.TesteAspNetMvc.Infra.Dados.Interfaces;

namespace CM.TesteAspNetMvc.Infra.Dados.UoW
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly TesteAspNetMvcContexto _contexto;

        public UnitOfWork(TesteAspNetMvcContexto contexto)
        {
            _contexto = contexto;
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }
    }
}