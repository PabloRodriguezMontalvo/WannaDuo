using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using WannaDuo.Model;
using Newtonsoft.Json;
using System.Globalization;

namespace WannaDuo.Controllers
{
    public class HomeController : Controller
    {
        private Contexto _context;
        private RiotApi _rito;
        public HomeController(Contexto context)
        {
            _context = context;
           _rito = RiotApi.GetInstance("NO");
        }

        public IActionResult Inicio()
        {
           
            return View();
        }
       
        [HttpGet]  
        public ActionResult Buscar(string id)
        {
            try
            {
                var id_invocador = _rito.GetSummoner(Region.euw, id);
                return Json(id_invocador.Id);
            }
            catch (Exception)
            {

                return Json("");
            }
          
           
        
        }

        private List<string> Gamemode()
        {
            var lista = new List<string>();

            lista.Add("Ranked 3x3");
            lista.Add("Ranked 5x5");
            lista.Add("Normal 3x3");
            lista.Add("Normal 5x5");
            lista.Add("Weekend Special");
            lista.Add("ARAM");

            return lista;
        }
        public IActionResult Nuevo()
        {
          
            var api = "NO";
            var staticApi = StaticRiotApi.GetInstance(api);
        
            //  var modo = Enum.GetNames(typeof(Queue)).ToList();
            var modo = Gamemode();



            var idioma = Enum.GetNames(typeof(Language)).ToList();
            var server = Enum.GetNames(typeof(Region)).ToList();
            var lista_idiomas= new List<string>();
            foreach (var i in idioma)
            {
                var rep = i.Replace("_", "-");

                try
                {
                    var idiomanombre = new CultureInfo(rep).DisplayName;
                    if(new CultureInfo(rep).KeyboardLayoutId== new CultureInfo(rep).LCID)
                      lista_idiomas.Add(idiomanombre);
                }
                catch (Exception)
                {



                }
            }

            var posicion = Enum.GetNames(typeof(TagStatic)).ToList();
            //  var Campeones = staticApi.GetChampions(Region.euw, ChampionData.image, Language.es_ES).Champions.ToList();
            ViewBag.Campeones = new SelectList(staticApi.GetChampions(Region.euw, ChampionData.image, Language.es_ES).Champions, "Value", "Key").ToList().OrderBy(o=>o.Text);
            ViewBag.Modo = new SelectList(modo);
            ViewBag.Idioma = new SelectList(lista_idiomas);
            ViewBag.Posicion = new SelectList(posicion);
            ViewBag.Server = new SelectList(server);
            return View(new Entrada());
        }
        public IActionResult Index()
        {
            // Aqui vamos a hacer los calculos de los jugadores que quieren jugar en este momento.
            var contador = _context.Entrada.Count();
            var lista= _context.Entrada.ToList();

            ViewBag.Contador = contador;
            return View(lista);
        }
       
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
