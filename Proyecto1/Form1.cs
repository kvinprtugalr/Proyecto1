using Microsoft.Data.SqlClient;
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

            lstHistorial.Items.Clear();
            // 1️⃣ Guardamos la operación
            string operacion = txtCalculo.Text;
            txtCalculo.Text = "3";
            string resultado = txtCalculo.Text;


            // Guardar en la base de datos
            string sql = "INSERT INTO Operaciones (Operacion, Resultado)" + "VALUES ('" + operacion + "', '" + resultado + "')";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                cmd.ExecuteNonQuery(); // se guarda en la base de datos
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                con.Close(); // siempre cierra la conexión
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
            txtCalculo.Text = "4";
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            txtCalculo.Text = "5";
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            txtCalculo.Text = "6";
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

        private void Form1_Load(object sender, EventArgs e)
        {

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
            if (txtCalculo.Text != "")
            {
                double numero = double.Parse(txtCalculo.Text); // convierte el texto a número
                numero = numero * -1;                          // cambia el signo
                txtCalculo.Text = numero.ToString();           // reemplaza el TextBox con el nuevo valor
            }
        }

        private void btnPorcentaje_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "%";
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            txtCalculo.Text = "√" + txtCalculo.Text;
        }

        private void btnCuadrado_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "^2";
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
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            con.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string operacion = reader["Operacion"].ToString();
                    string resultado = reader["Resultado"].ToString();
                    string fecha = reader["Fecha"].ToString();

                    lstHistorial.Items.Add(fecha + " → " + operacion + " = " + resultado + Environment.NewLine);
                }
                reader.Close();
            }
            catch
            {
                // Si falla no hacemos nada
            }
            finally
            {
                con.Close();
            }
        }
    }
}
