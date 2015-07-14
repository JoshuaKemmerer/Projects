using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Twocents.Models
{
    [Authorize]
    public class AccessTypesController : Controller
    {
        private BasetwoDataContext db = new BasetwoDataContext();

        // GET: AccessTypes
        public ActionResult Index()
        {
            return View(db.AccessTypes.ToList());
        }

        // GET: AccessTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessType accessType = db.AccessTypes.Find(id);
            if (accessType == null)
            {
                return HttpNotFound();
            }
            return View(accessType);
        }

        // GET: AccessTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccessTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessTypeId,Name,Description")] AccessType accessType)
        {
            if (ModelState.IsValid)
            {
                db.AccessTypes.Add(accessType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessType);
        }

        // GET: AccessTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessType accessType = db.AccessTypes.Find(id);
            if (accessType == null)
            {
                return HttpNotFound();
            }
            return View(accessType);
        }

        // POST: AccessTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessTypeId,Name,Description")] AccessType accessType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessType);
        }

        // GET: AccessTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessType accessType = db.AccessTypes.Find(id);
            if (accessType == null)
            {
                return HttpNotFound();
            }
            return View(accessType);
        }

        // POST: AccessTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccessType accessType = db.AccessTypes.Find(id);
            db.AccessTypes.Remove(accessType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
