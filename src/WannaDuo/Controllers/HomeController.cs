using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RiotSharp;
using RiotSharp.StaticDataEndpoint;
using RiotSharp.StaticDataEndpoint.Champion.Enums;
using WannaDuo.Migrations;
using WannaDuo.Model;
using WannaDuo.Repository;
using WannaDuo.Services;

namespace WannaDuo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositoryBase<Entrada> _context;
        public string _clave { get; set; }
        private readonly string k = "e822c187-091a-447c-ad09-ef938ca38425";
        private readonly RiotApi _rito;
        private readonly Claves _claves;
        private readonly StaticRiotApi _staticApi;

        public HomeController(IRepositoryBase<Entrada> context)
        {
            _context = context;
            _rito = RiotApi.GetInstance(k);
        _claves=new Claves(new HttpContextAccessor());
            _staticApi = StaticRiotApi.GetInstance(k);
          
        }

        public IActionResult Inicio()
        {
            return View();
        }
     
        [HttpGet]
        public IActionResult Buscar(string id)
        {
            try
            {
                var id_invocador = _rito.GetSummoner(Region.euw, id);
                var listadeuno = new List<long>();
                listadeuno.Add(id_invocador.Id);
                var paginas = _rito.GetMasteryPages(Region.euw, listadeuno);
                var a = paginas.SelectMany(o => o.Value).ToList();
                var nombre = a[0].Name;
                var clave = _claves.ComprobarClave();
                if (nombre == clave)
                    return Json(id_invocador.Id);
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
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
            var clave = _claves.DameClave();
            var modo = Enum.GetNames(typeof(Queue)).ToList();
            //     var modo = Gamemode();


            var idioma = Enum.GetNames(typeof(Language)).ToList();
            var server = Enum.GetNames(typeof(Region)).ToList();
            var lista_idiomas = new List<string>();
            foreach (var i in idioma)
            {
                var rep = i.Replace("_", "-");

                try
                {
                    var idiomanombre = new CultureInfo(rep).DisplayName;
                    if (new CultureInfo(rep).Name == new CultureInfo(rep).NativeName)
                        lista_idiomas.Add(idiomanombre);
                }
                catch (Exception)
                {
                }
            }

            var posicion = Enum.GetNames(typeof(TagStatic)).ToList();
            //  var Campeones = staticApi.GetChampions(Region.euw, ChampionData.image, Language.es_ES).Champions.ToList();
            ViewBag.Campeones =
                new SelectList(_staticApi.GetChampions(Region.euw, ChampionData.image, Language.es_ES).Champions,
                    "Value", "Key").ToList().OrderBy(o => o.Text);
            ViewBag.Modo = new SelectList(modo);
            ViewBag.IdiomaC = new SelectList(lista_idiomas);
            ViewBag.PosicionC = new SelectList(posicion);
            ViewBag.ServerC = new SelectList(server);
            ViewBag.Palabro = clave;
            return View(new Entrada());
        }

        [HttpPost]
        public IActionResult Nuevo(Entrada registroEntrada)
        {
            if (ModelState.IsValid)
            {
                _context.Insert(registroEntrada);
                return RedirectToAction("Index");
            }
            var idioma = Enum.GetNames(typeof(Language)).ToList();
            var server = Enum.GetNames(typeof(Region)).ToList();
            var lista_idiomas = new List<string>();
            foreach (var i in idioma)
            {
                var rep = i.Replace("_", "-");

                try
                {
                    var idiomanombre = new CultureInfo(rep).DisplayName;
                    if (new CultureInfo(rep).Name == new CultureInfo(rep).NativeName)
                        lista_idiomas.Add(idiomanombre);
                }
                catch (Exception)
                {
                }
            }
            var modo = Gamemode();
            var posicion = Enum.GetNames(typeof(TagStatic)).ToList();
            ViewBag.Campeones =
                new SelectList(_staticApi.GetChampions(Region.euw, ChampionData.image, Language.es_ES).Champions,
                    "Value", "Key").ToList().OrderBy(o => o.Text);
            ViewBag.Modo = new SelectList(modo);
            ViewBag.IdiomaC = new SelectList(lista_idiomas);
            ViewBag.PosicionC = new SelectList(posicion);
            ViewBag.ServerC = new SelectList(server);
            return View(registroEntrada);
            //var api = "e822c187-091a-447c-ad09-ef938ca38425";
            //var staticApi = StaticRiotApi.GetInstance(api);

            ////  var modo = Enum.GetNames(typeof(Queue)).ToList();
            //var modo = Gamemode();


            //var idioma = Enum.GetNames(typeof(Language)).ToList();
            //var server = Enum.GetNames(typeof(Region)).ToList();
            //var lista_idiomas = new List<string>();
            //foreach (var i in idioma)
            //{
            //    var rep = i.Replace("_", "-");

            //    try
            //    {
            //        var idiomanombre = new CultureInfo(rep).DisplayName;
            //        if (new CultureInfo(rep).KeyboardLayoutId == new CultureInfo(rep).LCID)
            //            lista_idiomas.Add(idiomanombre);
            //    }
            //    catch (Exception)
            //    {


            //    }
            //}

            //var posicion = Enum.GetNames(typeof(TagStatic)).ToList();
            ////  var Campeones = staticApi.GetChampions(Region.euw, ChampionData.image, Language.es_ES).Champions.ToList();
            //ViewBag.Campeones = new SelectList(staticApi.GetChampions(Region.euw, ChampionData.image, Language.es_ES).Champions, "Value", "Key").ToList().OrderBy(o => o.Text);
            //ViewBag.Modo = new SelectList(modo);
            //ViewBag.Idioma = new SelectList(lista_idiomas);
            //ViewBag.Posicion = new SelectList(posicion);
            //ViewBag.Server = new SelectList(server);
            //return View(new Entrada());
        }

        public IActionResult Index()
        {
            // Aqui vamos a hacer los calculos de los jugadores que quieren jugar en este momento.
            var contador = _context.FindAll().Count();
            var lista = _context.FindAll().ToList();

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