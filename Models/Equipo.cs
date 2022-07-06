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

    public Equipo (int pidEquipo, string pnombre, string pescudo, string pcamiseta, string pcontinente, int pcopasGanadas){

        _idEquipo = pidEquipo;
        _nombre = pnombre;
        _escudo = pescudo;
        _camiseta = pcamiseta;
        _continente = pcontinente;
        _copasGanadas = pcopasGanadas;
    }

    public Equipo(){

         _idEquipo = 0;
        _nombre = "Sin nombre aún";
        _escudo = "Sin escudo aún";
        _camiseta = "Sin camiseta aún";
        _continente = "Sin continente aún";
        _copasGanadas = 0;


    }






}

}