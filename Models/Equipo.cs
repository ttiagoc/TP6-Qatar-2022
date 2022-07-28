using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


  namespace TP6_Qatar_2022.Models

  {
    public class Equipo{
    private int _idEquipo;
    private string _nombre = "";
    private string _escudo = "";
    private string _camiseta = "";
    private string _continente = "";
    private  int _copasGanadas;
    private string _pagOficial;
    private string _video = "";
    public Equipo (int pIdEquipo, string pnombre, string pescudo, string pcamiseta, string pcontinente, int pcopasGanadas, string pPagOficial, string pVideo){

       _idEquipo = pIdEquipo;
        _nombre = pnombre;
        _escudo = pescudo;
        _camiseta = pcamiseta;
        _continente = pcontinente;
        _copasGanadas = pcopasGanadas;
        _pagOficial = pPagOficial;
        _video = pVideo;
    }

    public Equipo(){

        _idEquipo = 0;
        _nombre = "Sin nombre aún";
        _escudo = "Sin escudo aún";
        _camiseta = "Sin camiseta aún";
        _continente = "Sin continente aún";
        _copasGanadas = 0;
        _pagOficial = "Sin página aún";
        _video = "Sin video aún";
    }

      public int IdEquipo{
         get{return _idEquipo;}
         set{_idEquipo = value;}
    }

      public string Nombre{
        get{return _nombre;}
        set{_nombre = value;}
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

  public string PagOficial{
    get{return _pagOficial;}
    set{_pagOficial = value;}
  }

   public string Video{
    get{return _video;}
    set{_video = value;}
  }
}

}