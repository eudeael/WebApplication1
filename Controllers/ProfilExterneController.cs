using System.Linq;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProfilExterneController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: ProfilExterne
        public ActionResult Index()
        {
            var candidats = _context.ProfilsExternes.ToList();
            return View(candidats);
        }

        // GET: ProfilExterne/Details/5
        public ActionResult Details(int id)
        {
            var candidat = _context.ProfilsExternes.Find(id);
            if (candidat == null) return HttpNotFound();
            return View(candidat);
        }

        // GET: ProfilExterne/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfilExterne/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfilExterne candidat)
        {
            if (ModelState.IsValid)
            {
                _context.ProfilsExternes.Add(candidat);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidat);
        }

        // GET: ProfilExterne/Edit/5
        public ActionResult Edit(int id)
        {
            var candidat = _context.ProfilsExternes.Find(id);
            if (candidat == null) return HttpNotFound();
            return View(candidat);
        }

        // POST: ProfilExterne/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfilExterne candidat)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(candidat).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidat);
        }

        // GET: ProfilExterne/Delete/5
        public ActionResult Delete(int id)
        {
            var candidat = _context.ProfilsExternes.Find(id);
            if (candidat == null) return HttpNotFound();
            return View(candidat);
        }

        // POST: ProfilExterne/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var candidat = _context.ProfilsExternes.Find(id);
            if (candidat != null)
            {
                _context.ProfilsExternes.Remove(candidat);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
