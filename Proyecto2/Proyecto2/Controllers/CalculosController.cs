using Proyecto2.Models;
using Proyecto2.Models.WS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto2.Controllers
{
    public class CalculosController : ApiController
    {
        private string connectionString = "Server=.;Database=CalculadoraDB;Trusted_Connection=True;";

        // GET api/calculos
        [HttpGet]
        public Reply GetAll()
        {
            Reply oR = new Reply();
            oR.result = 200;

            List<Calculo> lista = new List<Calculo>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Operacion, Resultado, Fecha FROM Operaciones", cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Calculo
                    {
                        id = dr.GetInt32(0),
                        operacion = dr.GetString(1),
                        resultado = dr.GetString(2),
                        fecha = dr.GetDateTime(3)
                    });
                }
                cn.Close();
            }

            oR.data = lista;
            oR.message = "OK";

            return oR;
        }

        // GET api/calculos/sumas
        [HttpGet]
        public Reply Sumas()
        {
            return GetByTipo("suma");
        }

        // GET api/calculos/restas
        [HttpGet]
        public Reply Restas()
        {
            return GetByTipo("resta");
        }

        // GET api/calculos/multiplicaciones
        [HttpGet]
        public Reply Multiplicaciones()
        {
            return GetByTipo("multiplicacion");
        }

        // GET api/calculos/divisiones
        [HttpGet]
        public Reply Divisiones()
        {
            return GetByTipo("division");
        }

        private Reply GetByTipo(string tipo)
        {
            Reply oR = new Reply();
            oR.result = 200;

            List<Calculo> lista = new List<Calculo>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, Operacion, Resultado, Fecha FROM Operaciones", cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string oper = dr.GetString(1);

                    bool esTipo = false;

                    switch (tipo)
                    {
                        case "suma":
                            esTipo = oper.Contains("+");
                            break;
                        case "resta":
                            esTipo = oper.Contains("-");
                            break;
                        case "multiplicacion":
                            esTipo = oper.Contains("*");
                            break;
                        case "division":
                            esTipo = oper.Contains("/");
                            break;
                    }

                    if (esTipo)
                    {
                        lista.Add(new Calculo
                        {
                            id = dr.GetInt32(0),
                            operacion = oper,
                            resultado = dr.GetString(2),
                            fecha = dr.GetDateTime(3)
                        });
                    }
                }
                cn.Close();
            }

            oR.data = lista;
            oR.message = "OK";

            return oR;
        }

    }
}
