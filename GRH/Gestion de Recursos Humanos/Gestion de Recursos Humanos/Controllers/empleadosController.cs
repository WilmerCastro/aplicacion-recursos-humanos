using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestion_de_Recursos_Humanos.Models;

namespace Gestion_de_Recursos_Humanos.Controllers
{
    public class empleadosController : Controller
    {
        private Model1Container db = new Model1Container();
       
        [HttpGet]
        public ActionResult VerNomina(string fechaaño, string fechames)
        {

            var nomina = from s in db.nominasSet
                           select s;

            

            if ((!String.IsNullOrEmpty(fechaaño)))
            {
                DateTime newFecha = DateTime.Parse(fechaaño);

                nomina = nomina.Where(s => s.año.Equals(newFecha));
            }

            if ((!String.IsNullOrEmpty(fechames)))
            {
                DateTime newFecha = DateTime.Parse(fechames);

                nomina = nomina.Where(s => s.mes.Equals(newFecha));
            }

            return View(nomina.ToList());
        }

        [HttpGet]
        public ActionResult VerEmpleados(string nombree, string departamentto)
        {

            var empleaddo = from s in db.empleadosSet
                         select s;



            if ((!String.IsNullOrEmpty(nombree)))
            {

                empleaddo = empleaddo.Where(s => s.nombre.Contains(nombree));
            }

            if ((!String.IsNullOrEmpty(departamentto)))
            {

                empleaddo = empleaddo.Where(s => s.departamento.Contains(departamentto));
            }

            return View(empleaddo.ToList().Where(s=>s.estatus.Equals("Activo")));
        }

      
        public ActionResult VerSalidas()
        {

            return View(db.salidaSet.ToList());
        }

        public ActionResult VerEntradasMes()
        {

            return View(db.empleadosSet.ToList().Where(s => s.estatus.Equals("Activo")));
        }


        public ActionResult VerPermisos(string empleado1)
        {

            var permiso = from s in db.permisosSet
                            select s;



            if ((!String.IsNullOrEmpty(empleado1)))
            {

                permiso = permiso.Where(s => s.empleado.Contains(empleado1));
            }

            return View(permiso.ToList());
        }

        // GET: empleados
        public ActionResult Index()
        {
            return View(db.empleadosSet.ToList());
        }

        // GET: empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = db.empleadosSet.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
                
            }
            return View(empleados);
        }

        // GET: empleados/Create
        public ActionResult Create()
        {
            ViewBag.Lista = db.departamentosSet.ToList();
            ViewBag.Lista2 = db.cargosSet.ToList();
            return View();
        }

        // POST: empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,codigoempleado,nombre,apellido,telefono,departamento,cargo,fechaingreso,salario,estatus")] empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.empleadosSet.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleados);
        }

        // GET: empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = db.empleadosSet.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,codigoempleado,nombre,apellido,telefono,departamento,cargo,fechaingreso,salario,estatus")] empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleados);
        }

        // GET: empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleados empleados = db.empleadosSet.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            empleados empleados = db.empleadosSet.Find(id);
            db.empleadosSet.Remove(empleados);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public JsonResult IsProductNameExist(string codigoempleado, int? Id)
        {
            var validateName = db.empleadosSet.FirstOrDefault
                                (x => x.codigoempleado == codigoempleado && x.Id != Id);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult calculoNomina(nominas p)
        {
            p.año = DateTime.Today.Year;
            p.mes = DateTime.Today.Month;
            var nom = from m in db.empleadosSet where (m.estatus.Equals("Activo")) select m.salario;
            p.montototal = nom.Sum();

            return View(p);
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
