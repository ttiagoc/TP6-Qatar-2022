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
    public IActionResult GuardarJugador(int IdJugador, int IdEquipo, IFormFile Foto, string Nombre, DateTime FechaNacimiento, string EquipoActual){

           if(Foto.Length>0){
               string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + Foto.FileName;
               using(var stream = System.IO.File.Create(wwwRootLocal)){
                   Foto.CopyToAsync(stream);
               }
           }
           
           Jugador Jug = new Jugador(IdJugador,IdEquipo,Nombre,FechaNacimiento,("/" + Foto.FileName),EquipoActual);
            BD.AgregarJugador(Jug);

             ViewBag.miEquipo = BD.VerInfoEquipo(IdEquipo);
             ViewBag._ListaJugadores = BD.ListarJugadores(IdEquipo);
            
                return RedirectToAction("VerDetalleEquipo" , "Home", new {IdEquipo = IdEquipo});
    }


    public IActionResult EliminarJugador(int IdJugador, int IdEquipo){

             BD.EliminarJugador(IdJugador);

             ViewBag.miEquipo = BD.VerInfoEquipo(IdEquipo);
            ViewBag._ListaJugadores = BD.ListarJugadores(IdEquipo);

                 return RedirectToAction("DetalleEquipo");
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


 



}

