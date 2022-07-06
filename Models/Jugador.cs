using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_Qatar_2022.Models

{

public class Jugador{

    private int _idJugador;
    private int _idEquipo;
    private string _nombre = "";
    private DateTime _fechaNacimiento;
    private string _foto = "";
    private string _equipoActual = "";


    public Jugador (int pidJugador, int pidEquipo, string pnombre, DateTime pfechaNacimiento, string pfoto, string pequipoActual){

        _idJugador = pidJugador;
        _idEquipo = pidEquipo;
        _nombre = pnombre;
        _fechaNacimiento = pfechaNacimiento;
        _foto = pfoto;
        _equipoActual = pequipoActual;
    }

    public Jugador(){

         _idJugador = 0;
        _idEquipo = 0;
        _nombre = "Sin nombre";
        _fechaNacimiento = ;
        _foto = "Sin foto";
        _equipoActual = "Sin equipo";
    }

    public int IdJugador{
        get{return _idJugador;}
        set{_idJugador = value;}
    }

      public int IdEquipo{
        get{return _idEquipo;}
        set{_idEquipo = value;}
    }

      public string Escudo{
        get{return _escudo;}
        set{_escudo = value;}
    }

      public string Camiseta{
        get{return _camiseta;}
        set{_camiseta = value;}
    }

      public string Continente{
        get{return _continente;}
        set{_continente = value;}
    }

      public int CopasGanadas{
        get{return _copasGanadas;}
        set{_copasGanadas = value;}
    }



}

}