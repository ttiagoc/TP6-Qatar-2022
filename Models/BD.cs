using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;

    namespace TP6_Qatar_2022.Models{

        public static class BD{


            private static string _connectionString = @"Server=A-AMI-203\SQLEXPRESS;
            DataBase = Qatar2022;Trusted_Connection=True";

            public static void AgregarJugador(Jugador Jug){

              string SQL = "INSERT INTO Jugador(IdJugador, IdEquipo, Nombre, FechaNacimiento, Foto, EquipoActual) VALUES (@pIdJugador, @pIdEquipo, @pNombre, @pFechaNacimiento, @pFoto, @pEquipoActual)";

                using(SqlConnection db = new SqlConnection(_connectionString)){
                    db.Execute(SQL, new {pIdJugador = Jug.IdJugador, pIdEquipo = Jug.IdEquipo, pNombre = Jug.Nombre, pFechaNacimiento = Jug.FechaNacimiento, pFoto = Jug.Foto, pEquipoActual = Jug.EquipoActual } );
                }



            }

             public static int EliminarJugador(string JugadorAEliminar){
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

















        }























}