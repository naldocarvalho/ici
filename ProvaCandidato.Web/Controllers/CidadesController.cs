using ProvaCandidato.Data;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Data.Validations;
using ProvaCandidato.Helper;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProvaCandidato.Controllers
{
    public class CidadesController : GenericController<Cidade>
    {
        private ContextoPrincipal db = new ContextoPrincipal();

        // GET: Cidades
        public ActionResult Index()
        {
            return View(db.Cidades.ToList());
        }

        // GET: Cidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cidades/Create
        [HttpPost]
        public ActionResult Create(Cidade cidade)
        {
            var erros = CidadeValidation.Validate(cidade);

            if (erros.Count == 0)
            {
                db.Cidades.Add(cidade);
                db.SaveChanges();

                MessageHelper.DisplaySuccessMessage(this, "Cidade cadastrada com sucesso");
                return RedirectToAction("Index");
            }

            ViewBag.erros = erros;
            MessageHelper.AddMensagemToView("Revise os campos destacados", MensagemValidation.EnumTipoMensagem.info);
            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cidade cidade = db.Cidades.Find(id);

            if (cidade == null)
            {
                return HttpNotFound();
            }

            return View(cidade);
        }

        [HttpPost]
        public ActionResult Edit(Cidade cidade)
        {
            var erros = CidadeValidation.Validate(cidade);

            if (erros.Count == 0)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();

                MessageHelper.DisplaySuccessMessage(this, "Cidade editada com sucesso");
                return RedirectToAction("Index");
            }

            ViewBag.erros = erros;
            MessageHelper.AddMensagemToView("Revise os campos destacados", MensagemValidation.EnumTipoMensagem.info);
            return View(cidade);
        }
    }
}