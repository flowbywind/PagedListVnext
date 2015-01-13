using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using WebPagedList.Models;
using PagedList.Mvc;
using PagedList;

namespace WebPagedList.Controllers
{
    public class PersonController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Person
        public IActionResult Index(string sortOrder,string searchString,string currentFilter,int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(db.Person.ToList().ToPagedList(pageNumber, pageSize));
            //return View(db.Person.ToList());
        }

        // GET: Person/Details/5
        public IActionResult Details(System.Int32? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Person person = db.Person.Single(m => m.ID == id);
            if (person == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(person);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                db.Person.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Edit/5
        public IActionResult Edit(System.Int32? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Person person = db.Person.Single(m => m.ID == id);
            if (person == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                db.ChangeTracker.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(System.Int32? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Person person = db.Person.Single(m => m.ID == id);
            if (person == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(System.Int32 id)
        {
            Person person = db.Person.Single(m => m.ID == id);
            db.Person.Remove(person);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
