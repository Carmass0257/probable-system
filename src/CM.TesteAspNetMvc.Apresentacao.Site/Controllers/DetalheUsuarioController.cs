using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CM.TesteAspNetMvc.Aplicacao.Interfaces;
using CM.TesteAspNetMvc.Aplicacao.ViewModels;

namespace CM.TesteAspNetMvc.Apresentacao.Site.Controllers
{
    public class DetalheUsuarioController : Controller
    {
        private readonly IDetalheUsuarioAppService _detalheUsuarioAppService;
        private readonly IUsuarioAppService _usuarioAppService;

        public DetalheUsuarioController(IDetalheUsuarioAppService detalheUsuarioAppService, IUsuarioAppService usuarioAppService)
        {
            _detalheUsuarioAppService = detalheUsuarioAppService;
            _usuarioAppService = usuarioAppService;
        }

        // GET: DetalheUsuario
        public ActionResult Index()
        {
            return View(_detalheUsuarioAppService.ObterTodos());
        }

        // GET: DetalheUsuario/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var detalheUsuarioViewModel = _detalheUsuarioAppService.ObterPorId(id.Value);
            if (detalheUsuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(detalheUsuarioViewModel);
        }

        // GET: DetalheUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalheUsuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioDetalhesUsuarioViewModel usuarioDetalhesUsuarioViewModel)
        {
            if (!ModelState.IsValid) return View(usuarioDetalhesUsuarioViewModel);

            usuarioDetalhesUsuarioViewModel = _detalheUsuarioAppService.Adicionar(usuarioDetalhesUsuarioViewModel);

            if (usuarioDetalhesUsuarioViewModel.DetalheUsuarioViewModel.ValidationResult.IsValid)
                return RedirectToAction("Index");

            foreach (var erro in usuarioDetalhesUsuarioViewModel.DetalheUsuarioViewModel.ValidationResult.Erros)
            {
                ModelState.AddModelError(string.Empty, erro.Message);
            }


            return View(usuarioDetalhesUsuarioViewModel);
        }

        // GET: DetalheUsuario/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var detalheUsuarioViewModel = _detalheUsuarioAppService.ObterPorId(id.Value);
            var usuariodetalhe = new UsuarioDetalhesUsuarioViewModel();
            usuariodetalhe.DetalheUsuarioViewModel = detalheUsuarioViewModel;
            usuariodetalhe.UsuarioViewModel =
                _usuarioAppService
                    .ObterTodos()
                    .FirstOrDefault(c => c.DetalheUsuarioId == detalheUsuarioViewModel.Id);
            if (detalheUsuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuariodetalhe);
        }

        // POST: DetalheUsuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioDetalhesUsuarioViewModel usuarioDetalhesUsuarioViewModel)
        {
            if (!ModelState.IsValid) return View(usuarioDetalhesUsuarioViewModel);

            usuarioDetalhesUsuarioViewModel = _detalheUsuarioAppService.Atualizar(usuarioDetalhesUsuarioViewModel);

            if (usuarioDetalhesUsuarioViewModel.DetalheUsuarioViewModel.ValidationResult.IsValid)
                return RedirectToAction("Index");

            foreach (var erro in usuarioDetalhesUsuarioViewModel.DetalheUsuarioViewModel.ValidationResult.Erros)
            {
                ModelState.AddModelError(string.Empty, erro.Message);
            }


            return View(usuarioDetalhesUsuarioViewModel);
        }

        // GET: DetalheUsuario/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var detalheUsuarioViewModel = _detalheUsuarioAppService.ObterPorId(id.Value);
            if (detalheUsuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(detalheUsuarioViewModel);
        }

        // POST: DetalheUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _detalheUsuarioAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _detalheUsuarioAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}