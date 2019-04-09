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
        [HttpGet]
        public ActionResult calculoNomina(nominas p)
        {
            p.año = DateTime.Today.Year;
            p.mes = DateTime.Today.Month.ToString();
            var nom = from m in db.empleadosSet where (m.estatus.Equals("Activo")) select m.salario;
            p.montototal = nom.Sum();
              
            return View(p);
        }

        public ActionResult guardarNomina()
        {
            
            nominas nominas = new nominas();

            nominas.año = DateTime.Today.Year;
            nominas.mes = DateTime.Today.Month.ToString();
            var nom = from m in db.empleadosSet where (m.estatus.Equals("Activo")) select m.salario;
            nominas.montototal = nom.Sum();

            db.nominasSet.Add(nominas);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public ActionResult salidaEmpleados()
        {
            var contac = from s in db.empleadosSet select s;

            contac = contac.Where(s => s.estatus.Equals("activo"));

            return View(contac.ToList());

            

        }

        public ActionResult inactivarEmpleado(int id)
        {
           
            salida salida = new salida();

            var nom = (from m in db.empleadosSet where (m.Id ==id) select m.codigoempleado).Single();

            salida.empleado = nom;
           
            return View(salida);
            

            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult inactivarEmpleado([Bind(Include = "Id,empleado,tiposalida,motivo,fechasalida")] salida salida)
        {

           

            if (ModelState.IsValid)
            {

                string id;
                id = salida.empleado;
                var personaEditar = db.empleadosSet.FirstOrDefault(x => x.codigoempleado == id);
                personaEditar.estatus = "Inactivo";


                db.salidaSet.Add(salida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salida);

          



        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult guardarInactivos([Bind(Include = "Id,empleado,tiposalida,motivo,fechasalida")] salida salida)
        //{

        //    if (ModelState.IsValid)
        //    {

        //        db.salidaSet.Add(salida);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(salida);
        //}
        public ActionResult vacaciones()
        {
            return View(db.vacacionesSet.ToList());
        }
        public ActionResult agregarVacaciones()
        {
            var list = new List<string>() { "2019", "2020", "2021", "2022", "2023", "2024", "2025" };
            ViewBag.List = list;
            ViewBag.Lista = db.empleadosSet.ToList();
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult agregarVacaciones([Bind(Include = "Id,empleado,desde,hasta,correspondiente,comentarios")] vacaciones vacaciones)
        {



            if (ModelState.IsValid)
            {

             
                db.vacacionesSet.Add(vacaciones);
                db.SaveChanges();
                return RedirectToAction("vacaciones");
            }
            return View(vacaciones);

        }
        public ActionResult editarVacaciones(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacaciones vacaciones = db.vacacionesSet.Find(id);
            if (vacaciones == null)
            {
                return HttpNotFound();
            }
            return View(vacaciones);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editarVacaciones([Bind(Include = "Id,empleado,desde,hasta,correspondiente,comentarios")] vacaciones vacaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("vacaciones");
            }
            return View(vacaciones);
        }
        public ActionResult eliminarVacaciones(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacaciones vacaciones = db.vacacionesSet.Find(id);
            if (vacaciones == null)
            {
                return HttpNotFound();
            }
            return View(vacaciones);
        }

        // POST: empleados/Delete/5
        [HttpPost, ActionName("eliminarVacaciones")]
        [ValidateAntiForgeryToken]
        public ActionResult eliminarConfirmada(int id)
        {
            vacaciones vacaciones = db.vacacionesSet.Find(id);
            db.vacacionesSet.Remove(vacaciones);
            db.SaveChanges();
            return RedirectToAction("vacaciones");
        }


        public ActionResult permisos()
        {
            return View(db.permisosSet.ToList());
        }
        public ActionResult agregarPermisos()
        {
            ViewBag.Lista = db.empleadosSet.ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult agregarPermisos([Bind(Include = "Id,empleado,desde,hasta,comentarios")] permisos permisos)
        {



            if (ModelState.IsValid)
            {


                db.permisosSet.Add(permisos);
                db.SaveChanges();
                return RedirectToAction("permisos");
            }
            return View(permisos);

        }
        public ActionResult editarPermisos(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permisos permisos = db.permisosSet.Find(id);
            if (permisos == null)
            {
                return HttpNotFound();
            }
            return View(permisos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editarPermisos([Bind(Include = "Id,empleado,desde,hasta,comentarios")] permisos permisos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permisos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("permisos");
            }
            return View(permisos);
        }
        public ActionResult eliminarPermisos(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permisos permisos = db.permisosSet.Find(id);
            if (permisos == null)
            {
                return HttpNotFound();
            }
            return View(permisos);
        }

        // POST: empleados/Delete/5
        [HttpPost, ActionName("eliminarPermisos")]
        [ValidateAntiForgeryToken]
        public ActionResult eliminarPermisosConfirmada(int id)
        {
            permisos permisos = db.permisosSet.Find(id);
            db.permisosSet.Remove(permisos);
            db.SaveChanges();
            return RedirectToAction("permisos");
        }



        public ActionResult licencias()
        {
            return View(db.licenciasSet.ToList());
        }
        public ActionResult agregarLicencias()
        {
            ViewBag.Lista = db.empleadosSet.ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult agregarLicencias([Bind(Include = "Id,empleado,desde,hasta,motivo,comentarios")] licencias licencias)
        {



            if (ModelState.IsValid)
            {


                db.licenciasSet.Add(licencias);
                db.SaveChanges();
                return RedirectToAction("licencias");
            }
            return View(licencias);

        }
        public ActionResult editarLicencias(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            licencias licencias = db.licenciasSet.Find(id);
            if (licencias == null)
            {
                return HttpNotFound();
            }
            return View(licencias);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editarLicencias([Bind(Include = "Id,empleado,desde,hasta,motivo,comentarios")] licencias licencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("licencias");
            }
            return View(licencias);
        }
        public ActionResult eliminarLicencias(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            licencias licencias = db.licenciasSet.Find(id);
            if (licencias == null)
            {
                return HttpNotFound();
            }
            return View(licencias);
        }

        // POST: empleados/Delete/5
        [HttpPost, ActionName("eliminarLicencias")]
        [ValidateAntiForgeryToken]
        public ActionResult eliminarLicenciasConfirmada(int id)
        {
            licencias licencias = db.licenciasSet.Find(id);
            db.licenciasSet.Remove(licencias);
            db.SaveChanges();
            return RedirectToAction("licencias");
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
