using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Examen2.Controllers;
using Examen2.Models;
namespace Examen2.Controllers
{
    public class OrdenController : ApiController
    {
        String cadenaconexion;

        public OrdenController()
        {
            //CADENA DE CONEXIÓN PARA ACCEDER A LA BBDD ALOJADA EN AZURE
            cadenaconexion = @"Data Source=fran2934152015.database.windows.net;Initial Catalog=AdventureWorks; User ID=fran2934152015;Password=P@$$w0rd";
        }

        [HttpGet]
        // GET: api/Tutorial
        public List<orden> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexion;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM SalesLT.SalesOrderDetail";
            sqlCmd.Connection = myConnection;

            myConnection.Open();
            reader = sqlCmd.ExecuteReader();

            List<orden> ordens = new List<orden>();

            while (reader.Read())
            {
                orden per = new orden();

                per.ID = Convert.ToInt32(reader.GetValue(0));
                per.Qty = Convert.ToInt32(reader.GetValue(1));


                ordens.Add(per);
            }

            myConnection.Close();

            return ordens;
        }

        [HttpGet]
        // GET: api/Tutorial/5
        public orden Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexion;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM SalesLT.SalesOrderDetail WHERE SalesOrderID=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            orden per = null;

            while (reader.Read())
            {
                per = new orden();

                per.ID = Convert.ToInt32(reader.GetValue(0));
                per.Qty = Convert.ToInt32(reader.GetValue(1));

            }

            myConnection.Close();

            return per;

        }
    }
}
