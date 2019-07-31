using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalVideo.Controllers
{
   
    public class RentaController : Controller
    {              
        private videoEntities db = new videoEntities();
  
        public ActionResult Index()
        {
            SelectList lista_socios = new SelectList(db.SOCIO, "SOC_ID", "SOC_NOMBRE");
            SelectList lista_peliculas = new SelectList(db.PELICULA, "PEL_ID", "PEL_NOMBRE");

            int longitud_soc = int.Parse(lista_socios.Max(x => x.Value));
            string[] nombres = new string[longitud_soc + 1];
            foreach (var aux in lista_socios)
            {
                nombres[int.Parse(aux.Value.ToString())] = aux.Text;
            }
            List<string> pel_nombres = new List<string>();
            List<string> pel_id = new List<string>();
           

            foreach (var aux in db.PELICULA)
            {
                pel_nombres.Add(aux.PEL_NOMBRE.ToString());
                pel_id.Add(aux.PEL_ID.ToString());
               
            }
            int longitud_pel = int.Parse(lista_peliculas.Max(x => x.Value));
            string[] pel_valor = new string[30];//SE USA UN ARREGLO PARA HACER REFERENCIA A EL CON EL INDICE, INCLUSO SI SE HA BORRADO UN DATO
            foreach (var aux in db.PELICULA)
            {
                pel_valor[int.Parse(aux.PEL_ID.ToString())] = aux.PEL_COSTO.ToString();
            }

            ViewBag.PEL_ID = lista_peliculas;
            ViewBag.SOC_ID = lista_socios;

            ViewBag.SOC_NOMBRES = nombres;
            ViewBag.PEL_NOMBRES = pel_nombres;
            ViewBag.PEL_IDS = pel_id;
            ViewBag.PEL_COSTOS = pel_valor;


            return View();
        }
        [HttpPost]
        public ActionResult Index(ICollection<ALQUILER> aLQUILERs)
        {
            if (aLQUILERs != null)
            {
                foreach(var aux in aLQUILERs)
                {
                    aux.ALQ_FECHA_ENTREGA = null;
                }
                db.ALQUILER.AddRange(aLQUILERs);
                db.SaveChanges();
                return RedirectToAction("Index", "ALQUILERs");
            }

            SelectList lista_socios = new SelectList(db.SOCIO, "SOC_ID", "SOC_NOMBRE");
            SelectList lista_peliculas = new SelectList(db.PELICULA, "PEL_ID", "PEL_NOMBRE");

            int longitud_soc = int.Parse(lista_socios.Max(x => x.Value));
            string[] nombres = new string[longitud_soc + 1];//SE USA UN ARREGLO PARA QUE EL ID COINCIDA CON EL INDICE DEL ARREGLO (INCLUSO SI SE BORRÓ UN ELEMENTO)
            foreach (var aux in lista_socios)
            {
                nombres[int.Parse(aux.Value.ToString())] = aux.Text;
            }
            List<string> pel_nombres = new List<string>();
            List<string> pel_id = new List<string>();
            //List<string> pel_valor = new List<string>();

            foreach (var aux in db.PELICULA)
            {
                pel_nombres.Add(aux.PEL_NOMBRE.ToString());
                pel_id.Add(aux.PEL_ID.ToString());
                //pel_valor.Add(aux.PEL_COSTO.ToString());
            }
            int longitud_pel = int.Parse(lista_peliculas.Max(x => x.Value));
            string[] pel_valor = new string[longitud_pel + 1];//SE USA UN ARREGLO PARA HACER REFERENCIA A EL CON EL INDICE, INCLUSO SI SE HA BORRADO UN DATO
            foreach (var aux in db.PELICULA)
            {
                pel_valor[int.Parse(aux.PEL_ID.ToString())] = aux.PEL_COSTO.ToString();
            }

            ViewBag.PEL_ID = lista_peliculas;
            ViewBag.SOC_ID = lista_socios;

            ViewBag.SOC_NOMBRES = nombres;
            ViewBag.PEL_NOMBRES = pel_nombres;
            ViewBag.PEL_IDS = pel_id;
            ViewBag.PEL_COSTOS = pel_valor;


            return View();
        }
    }
}