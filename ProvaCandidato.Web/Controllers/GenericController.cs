using ProvaCandidato.Data;
using ProvaCandidato.Helper;
using System.Net;
using System.Web.Mvc;

namespace ProvaCandidato.Controllers
{
    public abstract class GenericController<T> : Controller where T : class
    {
        protected ContextoPrincipal _dataSource;

        public GenericController()
        {
            _dataSource = new ContextoPrincipal();
        }

        // GET: Generic/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _dataSource.Set<T>().Find(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // GET: Generic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _dataSource.Set<T>().Find(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // POST: Generic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = _dataSource.Set<T>().Find(id);
            _dataSource.Set<T>().Remove(model);
            _dataSource.SaveChanges();

            MessageHelper.DisplaySuccessMessage(this, "Cidade excluida com sucesso");
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataSource.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}