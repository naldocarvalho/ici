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
    public class ClientesController : GenericController<Cliente>
    {
        private ContextoPrincipal db = new ContextoPrincipal();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Cidade).Where(x => x.Ativo);
            return View(clientes.ToList());
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.CidadeId = new SelectList(db.Cidades, "Codigo", "Nome");
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            var erros = ClienteValidation.Validate(cliente);

            if (erros.Count == 0)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();

                MessageHelper.DisplaySuccessMessage(this, "Registro cadastrado com sucesso");
                return RedirectToAction("Index");
            }

            ViewBag.CidadeId = new SelectList(db.Cidades, "Codigo", "Nome", cliente.CidadeId);
            ViewBag.erros = erros;
            MessageHelper.AddMensagemToView("Revise os campos destacados", MensagemValidation.EnumTipoMensagem.info);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliente = db.Clientes.Find(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            ViewBag.CidadeId = new SelectList(db.Cidades, "Codigo", "Nome", cliente.CidadeId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            var erros = ClienteValidation.Validate(cliente);

            if (erros.Count == 0)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();

                MessageHelper.DisplaySuccessMessage(this, "Cliente editado com sucesso");
                return RedirectToAction("Index");
            }

            ViewBag.CidadeId = new SelectList(db.Cidades, "Codigo", "Nome", cliente.CidadeId);
            ViewBag.erros = erros;
            MessageHelper.AddMensagemToView("Revise os campos destacados", MensagemValidation.EnumTipoMensagem.info);
            return View(cliente);
        }
    }
}