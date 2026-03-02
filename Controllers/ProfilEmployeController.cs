using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Data; // ton DbContext

namespace WebApplication1.Controllers
{
    public class ProfilEmployeController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: ProfilEmploye
        public ActionResult Index()
        {
            var profils = _context.ProfilsEmployes.ToList();
            return View(profils);
        }

        // GET: ProfilEmploye/Details/5
        public ActionResult Details(int id)
        {
            var profil = _context.ProfilsEmployes.Find(id);
            if (profil == null) return HttpNotFound();
            return View(profil);
        }

        // GET: ProfilEmploye/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfilEmploye/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfilEmploye model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.ProfilsEmployes.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ProfilEmploye/Edit/5
        public ActionResult Edit(int id)
        {
            var profil = _context.ProfilsEmployes.Find(id);
            if (profil == null) return HttpNotFound();
            return View(profil);
        }

        // POST: ProfilEmploye/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfilEmploye model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: ProfilEmploye/Delete/5
        public ActionResult Delete(int id)
        {
            var profil = _context.ProfilsEmployes.Find(id);
            if (profil == null) return HttpNotFound();
            return View(profil);
        }

        // POST: ProfilEmploye/DeleteConfirmed/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var profil = _context.ProfilsEmployes.Find(id);
            if (profil != null)
            {
                _context.ProfilsEmployes.Remove(profil);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _context.Dispose();
            base.Dispose(disposing);
        }
    }
}
