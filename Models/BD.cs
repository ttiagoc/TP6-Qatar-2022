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

            public static void AgregarJugador(Jugador Jug){

              string SQL = "INSERT INTO Jugador(IdEquipo, Nombre, FechaNacimiento, Foto, EquipoActual, NumCamiseta) VALUES (@pIdEquipo, @pNombre, @pFechaNacimiento, @pFoto, @pEquipoActual, @pNumCamiseta)";

                using(SqlConnection db = new SqlConnection(_connectionString)){
                    db.Execute(SQL, new {pIdEquipo = Jug.IdEquipo, pNombre = Jug.Nombre, pFechaNacimiento = Jug.FechaNacimiento, pFoto = Jug.Foto, pEquipoActual = Jug.EquipoActual, pNumCamiseta = Jug.NumCamiseta } );
                }

                  

            }

             public static void AgregarEquipo(Equipo Eq){

              string SQL = "INSERT INTO Equipo(Nombre, Escudo, Camiseta, Continente, CopasGanadas, PagOficial, Video) VALUES (@pNombre, @pEscudo, @pCamiseta, @pContinente, @pCopasGanadas, @pPagOficial, @pVideo)";

                using(SqlConnection db = new SqlConnection(_connectionString)){
                    db.Execute(SQL, new {pNombre = Eq.Nombre, pEscudo = Eq.Escudo, pCamiseta = Eq.Camiseta, pContinente = Eq.Continente, pCopasGanadas = Eq.CopasGanadas, pPagOficial = Eq.PagOficial, pVideo = Eq.Video} );
                }

                   

            }





             public static int EliminarJugador(int JugadorAEliminar){
                 int jugadoresEliminados = 0;
                 string sql = "DELETE FROM Jugador WHERE IdJugador = @jJugador";
                    using(SqlConnection db = new SqlConnection(_connectionString)){
                      jugadoresEliminados = db.Execute(sql, new {jJugador = JugadorAEliminar} );
                    }

                        return jugadoresEliminados;
            }


            public static Equipo VerInfoEquipo(int IdEquipo){

                Equipo miEquipo;
              
                string sql = "SELECT * FROM Equipo WHERE IdEquipo = @pIdEquipo";
                using(SqlConnection db = new SqlConnection(_connectionString)){
                      
                      miEquipo = db.QueryFirstOrDefault<Equipo>(sql, new{pIdEquipo = IdEquipo});
                    }
                    return miEquipo;
            }

            public static Jugador VerInfoJugador(int IdJugador){

                Jugador miJugador;
                 string sql = "SELECT * FROM Jugador WHERE IdJugador = @pIdJugador";
                using(SqlConnection db = new SqlConnection(_connectionString)){
                     
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

                 string sql = "SELECT * FROM Jugador";

                 using(SqlConnection db = new SqlConnection(_connectionString)){
                     
                     _ListaJugadores = db.Query<Jugador>(sql).ToList();
                    }

                    return _ListaJugadores;
            }
















        }























}