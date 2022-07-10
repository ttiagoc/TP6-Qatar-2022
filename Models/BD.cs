using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;

    namespace TP6_Qatar_2022.Models{

        public static class BD{

            private static List <Equipo> _ListaEquipos = new List<Equipo>();
            private static List <Jugador> _ListaJugadores = new List<Jugador>();

            private static string _connectionString = @"Server=DESKTOP-P8MR2F6\SQLEXPRESS;
                  DataBase=Qatar2022;Trusted_Connection=True;";

            public static int AgregarJugador(Jugador Jug){

              string SQL = "INSERT INTO Jugador(Nombre, FechaNacimiento, Foto, EquipoActual) VALUES (@pNombre, @pFechaNacimiento, @pFoto, @pEquipoActual)";

                using(SqlConnection db = new SqlConnection(_connectionString)){
                    db.Execute(SQL, new {pNombre = Jug.Nombre, pFechaNacimiento = Jug.FechaNacimiento, pFoto = Jug.Foto, pEquipoActual = Jug.EquipoActual } );
                }

                    return Jug.IdEquipo;

            }

             public static void AgregarEquipo(Equipo Eq){

              string SQL = "INSERT INTO Equipo(Nombre, Escudo, Camiseta, Continente, CopasGanadas) VALUES (@pNombre, @pEscudo, @pCamiseta, @pCamiseta, @pCopasGanadas)";

                using(SqlConnection db = new SqlConnection(_connectionString)){
                    db.Execute(SQL, new {pNombre = Eq.Nombre, pEscudo = Eq.Escudo, pCamiseta = Eq.Camiseta, pContinente = Eq.Continente, pCopasGanadas = Eq.CopasGanadas } );
                }

                   

            }





             public static int EliminarJugador(int JugadorAEliminar){
                 int jugadoresEliminados = 0;
                 string sql = "DELETE FROM Jugador WHERE Jugador = @jJugador";
                    using(SqlConnection db = new SqlConnection(_connectionString)){
                      jugadoresEliminados = db.Execute(sql, new {jJugador = JugadorAEliminar} );
                    }

                        return jugadoresEliminados;
            }


            public static Equipo VerInfoEquipo(int IdEquipo){

                Equipo miEquipo = null;
                using(SqlConnection db = new SqlConnection(_connectionString)){
                      string sql = "SELECT * FROM Equipo WHERE IdEquipo = @pIdEquipo";
                      miEquipo = db.QueryFirstOrDefault<Equipo>(sql, new {pIdEquipo = IdEquipo});
                    }
                    return miEquipo;
            }

            public static Jugador VerInfoJugador(int IdJugador){

                Jugador miJugador = null;
                using(SqlConnection db = new SqlConnection(_connectionString)){
                      string sql = "SELECT * FROM Jugador WHERE IdJugador = @pIdJugador";
                      miJugador = db.QueryFirstOrDefault<Jugador>(sql, new {pIdJugador = IdJugador});
                    }
                    return miJugador;
            }

            public static List <Equipo> ListarEquipos(){

                    using(SqlConnection db = new SqlConnection(_connectionString)){
                      string sql = "SELECT * FROM Equipo";
                     _ListaEquipos = db.Query<Equipo>(sql).ToList();
                    }

                    return _ListaEquipos;
            }

            public static List <Jugador> ListarJugadores(int IdEquipo){

                    using(SqlConnection db = new SqlConnection(_connectionString)){
                      string sql = "SELECT * FROM Jugador WHERE IdEquipo = @pIdEquipo";
                     _ListaJugadores = db.Query<Jugador>(sql).ToList();
                    }

                    return _ListaJugadores;
            }
















        }























}