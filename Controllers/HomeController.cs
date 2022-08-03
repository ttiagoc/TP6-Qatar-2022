using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP6_Qatar_2022.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TP6_Qatar_2022.Controllers;

public class HomeController : Controller
{

   private IWebHostEnvironment Environment;


    private readonly ILogger<HomeController> _logger;

    public HomeController(IWebHostEnvironment environment)
    {
        Environment = environment;
    }

    public IActionResult Index()
    {
        ViewBag._ListaEquipos = BD.ListarEquipos();
        return View();
    }

    public IActionResult VerDetalleEquipo(int IdEquipo)
    {
        ViewBag.InfoEquipo = BD.VerInfoEquipo(IdEquipo);
        ViewBag._ListaJugadores = BD.ListarJugadores(IdEquipo);
        return View("DetalleEquipo");
    }

    public IActionResult VerDetalleJugador(int IdJugador)
    {
        ViewBag.miJugador = BD.VerInfoJugador(IdJugador);
        return View("DetalleJugador");
    }

    public IActionResult AgregarJugador(int IdEquipo)
    {
        ViewBag.IdEquipo = IdEquipo;
        return View("CrearJugador");
    }

    [HttpPost] 
    public IActionResult GuardarJugador(int IdJugador, int IdEquipo, IFormFile Foto, string Nombre, DateTime FechaNacimiento, string EquipoActual, int NumCamiseta){

           if(Foto.Length>0){
               string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\Imagenes\" + Foto.FileName;
               using(var stream = System.IO.File.Create(wwwRootLocal)){
                   Foto.CopyToAsync(stream);
               }
           }
           
           List<Jugador> listaJugadores = new List<Jugador>();
           listaJugadores = BD.ListarJugadores(IdEquipo);
           int numeroRep = -1;
           ViewBag.numeroRep = numeroRep;
           foreach(Jugador jug in listaJugadores)
           {
            if(jug.NumCamiseta == NumCamiseta)
            {
                if( jug.IdEquipo == IdEquipo){
                     numeroRep = 1;
                ViewBag.numeroRep = numeroRep;
                ViewBag.IdEquipo = IdEquipo;
                 return View("CrearJugador");
                }
               
            }
           }
        
           Jugador Jug = new Jugador(IdJugador,IdEquipo,Nombre,FechaNacimiento,("/" + Foto.FileName),EquipoActual, NumCamiseta);
            BD.AgregarJugador(Jug);

          
                return RedirectToAction("VerDetalleEquipo" , "Home", new {IdEquipo = IdEquipo});
    }


    public IActionResult EliminarJugador(int IdJugador, int IdEquipo){

             BD.EliminarJugador(IdJugador);

             return RedirectToAction("VerDetalleEquipo" , "Home", new {IdEquipo = IdEquipo});
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


     
     [HttpPost] 
    public IActionResult GuardarEquipo(int IdEquipo,string Nombre, IFormFile Escudo, IFormFile Camiseta, string Continente, int CopasGanadas, string PagOficial, string Video){

           if(Escudo.Length>0){
               string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\Imagenes\" + Escudo.FileName;
               using(var stream = System.IO.File.Create(wwwRootLocal)){
                   Escudo.CopyToAsync(stream);
               }
           }
              if(Camiseta.Length>0){
               string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\Imagenes\" + Camiseta.FileName;
               using(var stream = System.IO.File.Create(wwwRootLocal)){
                   Camiseta.CopyToAsync(stream);
               }
           }
           
           Equipo Eq = new Equipo(IdEquipo,Nombre,("/" + Escudo.FileName),("/" + Camiseta.FileName),Continente, CopasGanadas, PagOficial, Video);
            BD.AgregarEquipo(Eq);

          
                return RedirectToAction("Index" , "Home");
    }

      public IActionResult AgregarEquipo()
    {
       
        return View("CrearEquipo");
    }



}

