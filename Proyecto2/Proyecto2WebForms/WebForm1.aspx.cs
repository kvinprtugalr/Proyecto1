using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto2WebForms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public class Calculo
        {
            public int id { get; set; }
            public string operacion { get; set; }
            public string resultado { get; set; }
            public DateTime fecha { get; set; }
        }

        public class Reply
        {
            public int result { get; set; }
            public string message { get; set; }
            public List<Calculo> data { get; set; }
        }


        private void GetItems(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return;

                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();

                        // deserializar JSON
                        Reply respuesta = Newtonsoft.Json.JsonConvert.DeserializeObject<Reply>(responseBody);

                        // limpiar listado
                        ltbResultados.Items.Clear();

                        // llenar ListBox con operaciones
                        foreach (var item in respuesta.data)
                        {
                            ltbResultados.Items.Add($"{item.operacion} = {item.resultado}");
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                ltbResultados.Items.Clear();
                ltbResultados.Items.Add("Error al consumir API: " + ex.Message);
            }
        }


        protected void btnSumas_Click(object sender, EventArgs e)
        {
            GetItems("https://localhost:44303/api/calculos/Sumas");
        }

        protected void btnRestas_Click(object sender, EventArgs e)
        {
            GetItems("https://localhost:44303/api/calculos/Restas");
        }

        protected void btnMultiplicaciones_Click(object sender, EventArgs e)
        {
            GetItems("https://localhost:44303/api/calculos/Multiplicaciones");
        }

        protected void btnDivisiones_Click(object sender, EventArgs e)
        {
            GetItems("https://localhost:44303/api/calculos/Divisiones");
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            GetItems("https://localhost:44303/api/calculos/GetAll");
        }
    }
}