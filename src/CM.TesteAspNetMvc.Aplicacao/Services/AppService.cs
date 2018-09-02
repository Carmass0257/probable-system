using CM.TesteAspNetMvc.Infra.Dados.Interfaces;

namespace CM.TesteAspNetMvc.Aplicacao.Services
{
    public abstract class AppService
    {
        private readonly IUnitOfWork _unitOfWork;

        protected AppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}