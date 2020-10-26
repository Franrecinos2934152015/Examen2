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
    public class ProductoController : ApiController
    {
        String cadenaconexion;

        public ProductoController()
        {
            //CADENA DE CONEXIÓN PARA ACCEDER A LA BBDD ALOJADA EN AZURE
            cadenaconexion = @"Data Source=fran2934152015.database.windows.net;Initial Catalog=AdventureWorks; User ID=fran2934152015;Password=P@$$w0rd";
        }

        [HttpGet]
        // GET: api/Tutorial
        public List<productos> Get()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexion;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM SalesLT.Product";
            sqlCmd.Connection = myConnection;

            myConnection.Open();
            reader = sqlCmd.ExecuteReader();

            List<productos> productoss = new List<productos>();

            while (reader.Read())
            {
                productos per = new productos();

                per.ID = Convert.ToInt32(reader.GetValue(0));
                per.Nombre = reader.GetValue(1).ToString();
                per.precio = Convert.ToDouble(reader.GetValue(5));

                productoss.Add(per);
            }

            myConnection.Close();

            return productoss;
        }

        [HttpGet]
        // GET: api/Tutorial/5
        public productos Get(int id)
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = cadenaconexion;

            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM SalesLT.Product WHERE ProductID=" + id + "";
            sqlCmd.Connection = myConnection;

            myConnection.Open();

            reader = sqlCmd.ExecuteReader();

            productos per = null;

            while (reader.Read())
            {
                per = new productos();

                per.ID = Convert.ToInt32(reader.GetValue(0));
                per.Nombre = reader.GetValue(1).ToString();
                per.precio = Convert.ToDouble(reader.GetValue(5));

            }

            myConnection.Close();

            return per;

        }
    }
}
