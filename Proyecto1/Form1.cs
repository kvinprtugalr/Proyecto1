using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=.;Database=CalculadoraDB;TrustServerCertificate=True;Integrated Security=SSPI;";
        string operacion = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                // Guardamos la operación escrita antes de calcular
                string operacionActual = txtCalculo.Text;

                // Calculamos el resultado
                var resultado = new DataTable().Compute(operacionActual, "");
                string resultadoTexto = resultado.ToString();

                // Mostramos el resultado en el TextBox
                txtCalculo.Text = resultadoTexto;

                // Agregamos la operación al historial visual
                lstHistorial.Items.Add($"{operacionActual} = {resultadoTexto}");

                // Guardar en la base de datos con parámetros seguros
                string sql = "INSERT INTO Operaciones (Operacion, Resultado, Fecha) VALUES (@Operacion, @Resultado, GETDATE())";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Operacion", operacionActual);
                    cmd.Parameters.AddWithValue("@Resultado", resultadoTexto);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la operación: " + ex.Message);
            }
        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "0";
        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "1";
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "2";
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "3";
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "4";
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "5";
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "6";
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "7";
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "8";
        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "9";
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "+";
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "-";
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "*";
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "/";
        }

        private void btnPuntoDec_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += ".";
        }

        private void btnSigno_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtCalculo.Text, out double numero))
            {
                numero *= -1;
                txtCalculo.Text = numero.ToString();
            }
        }

        private void btnPorcentaje_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtCalculo.Text, out double numero))
            {
                txtCalculo.Text = (numero / 100).ToString();
            }
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtCalculo.Text, out double numero))
            {
                txtCalculo.Text = Math.Sqrt(numero).ToString();
            }
        }

        private void btnCuadrado_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtCalculo.Text, out double numero))
            {
                txtCalculo.Text = Math.Pow(numero, 2).ToString();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (txtCalculo.Text.Length > 0)
            {
                txtCalculo.Text = txtCalculo.Text.Substring(0, txtCalculo.Text.Length - 1);
            }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtCalculo.Text = ""; // limpia solo el TextBox
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtCalculo.Text = "";   // limpia TextBox
            operacion = "";         // resetea la operación guardada
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            lstHistorial.Items.Clear(); // Limpiamos antes de mostrar

            string sql = "SELECT Operacion, Resultado, Fecha FROM Operaciones ORDER BY Id";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string operacion = reader["Operacion"].ToString();
                        string resultado = reader["Resultado"].ToString();
                        string fecha = reader["Fecha"].ToString();

                        lstHistorial.Items.Add($"{fecha} → {operacion} = {resultado}");
                    }
                }
                catch
                {
                    MessageBox.Show("Error al mostrar el historial.");
                }
            }
        }
    }
