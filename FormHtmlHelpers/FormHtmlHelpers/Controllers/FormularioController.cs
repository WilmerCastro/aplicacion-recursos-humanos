using FormHtmlHelpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormHtmlHelpers.Controllers
{
    public class FormularioController : Controller
    {
        // GET: Formulario
        public ActionResult Index()
        {
            Persona persona = new Persona();
            List<Persona> ItemList = new List<Persona>();

            ItemList.Add(new Persona { idhobby = 1, hobby = "correr", chekeado = false });

            ItemList.Add(new Persona { idhobby = 2, hobby = "tocar un instrumento", chekeado = false });
            ItemList.Add(new Persona { idhobby = 3, hobby = "jugar video juegos", chekeado = false });
            ItemList.Add(new Persona { idhobby = 4, hobby = "leer libro", chekeado = false });

            ViewBag.ItemList = ItemList;
            //foreach (var item in ViewBag.ItemList)
            //{
            //    if (persona.chekeado == true)
            //    {
            //        persona.hobby = (persona.hobby + Request.Form["Check_" + item.idhobby.ToString()].ToString());
            //    }
            //}
            return View();
        }
        public ActionResult Persona()
        {
            
            Persona persona = new Persona();
            persona.cedula = Convert.ToInt32(Request.Form["cedula"]);
            persona.nombre= Request.Form["nombre"].ToString();
            persona.apellido = Request.Form["apellido"].ToString();
            persona.edad = Convert.ToInt32(Request.Form["edad"]);
            persona.telefono = Request.Form["telefono"].ToString();
            persona.correo = Request.Form["correo"].ToString();
            persona.genero = Request.Form["genero"].ToString();
            persona.estado_civil = Request.Form["estado_civil"].ToString();
            for(int i=1; i<=4; i++)
            {
               
                persona.hobby = Request.Form["Check_"+i];
            }
            
            return View(persona);
        }
    }
}