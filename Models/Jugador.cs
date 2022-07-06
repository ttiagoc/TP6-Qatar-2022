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
        _fechaNacimiento = new DateTime(1111,11,11);
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

      public string Nombre{
        get{return _nombre;}
        set{_nombre = value;}
    }

      public DateTime FechaNacimiento{
        get{return _fechaNacimiento;}
        set{_fechaNacimiento = value;}
    }

      public string Foto{
        get{return _foto;}
        set{_foto = value;}
    }

      public string EquipoActual{
        get{return _equipoActual;}
        set{_equipoActual = value;}
    }



}

}