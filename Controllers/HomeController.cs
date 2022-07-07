using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP6_Qatar_2022.Models;

namespace TP6_Qatar_2022.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag._ListaEquipos = BD.ListarEquipos();
        return View();
    }

    public IActionResult VerDetalleEquipo(int IdEquipo)
    {
        ViewBag.miEquipo = BD.VerInfoEquipo(IdEquipo);
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
        return View("CargarJugadores");
    }

    [HttpPost] IActionResult GuardarJugador(Jugador Jug){

            int IdEquipo = BD.AgregarJugador(Jug);
            
             ViewBag.miEquipo = BD.VerInfoEquipo(IdEquipo);
             ViewBag._ListaJugadores = BD.ListarJugadores(IdEquipo);
            
                return View("DetalleEquipo");
    }





    public IActionResult EliminarJugador(int IdJugador, int IdEquipo){

        BD.EliminarJugador()


         return View("DetalleEquipo");
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
