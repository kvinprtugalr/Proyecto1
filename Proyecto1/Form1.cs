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


            lstHistorial.Items.Clear();
            // Guardamos la operación
            string operacion = txtCalculo.Text;

            
            var resultado = new DataTable().Compute(operacion, null);
            txtCalculo.Text = resultado.ToString();

            // Agregamos la operación al historial visual
            lstHistorial.Items.Add($"{operacion} = {resultado}");

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
            string resultado = "";
            string operacion = "";

            if (double.TryParse(txtCalculo.Text, out double numero))
            {
                txtCalculo.Text = (numero / 100).ToString();
            }
            lstHistorial.Items.Add($"{numero}% = {txtCalculo.Text}");
            resultado = txtCalculo.Text;
            operacion = numero + "%";

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

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            string resultado = "";
            string operacion = "";
            if (double.TryParse(txtCalculo.Text, out double numero))
            {
                txtCalculo.Text = Math.Sqrt(numero).ToString();
                resultado = txtCalculo.Text;
                operacion = "√" + numero;
            }
            // Agregamos la operación al historial visual
            lstHistorial.Items.Add("√" + $"{numero} = {txtCalculo.Text}");

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

        private void btnCuadrado_Click(object sender, EventArgs e)
        {
            string resultado = "";
            string operacion = "";

            if (double.TryParse(txtCalculo.Text, out double numero))
            {
                txtCalculo.Text = Math.Pow(numero, 2).ToString();
                resultado = txtCalculo.Text;
                operacion = numero + "^2";
            }

            // Agregamos la operación al historial visual
            lstHistorial.Items.Add( $"{numero}^2 = {txtCalculo.Text}");

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
            lstHistorial.Items.Clear();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtCalculo.Text = "";   // limpia TextBox
            operacion = "";         // resetea la operación guardada
            lstHistorial.Items.Clear();
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
    

        private void lstHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnHex_Click(object sender, EventArgs e)
        {
            string resultado = "";
            string operacion = "";

            if (double.TryParse(txtCalculo.Text, out double numero))
            {
                // Convertimos a entero primero
                int entero = (int)numero;
                // Convertimos a hexadecimal
                string hex = entero.ToString("X"); // "X" produce letras mayúsculas A-F
                                                   // Mostramos en el TextBox
                txtCalculo.Text = hex;

                // Guardamos en el historial visual
                lstHistorial.Items.Add($"{entero}  HEX = {hex}");
                operacion = entero.ToString() + " HEX";
                resultado = txtCalculo.Text;
            }
            else
            {
                MessageBox.Show("Ingrese un número válido para convertir a HEX.");
            }

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

        private void btnBin_Click(object sender, EventArgs e)
        {
            string resultado = "";
            string operacion = "";

            if (double.TryParse(txtCalculo.Text, out double numero))
            {
                // Convertimos a entero primero
                int entero = (int)numero;
                // Convertimos a binario
                string binario = Convert.ToString(entero, 2); // base 2 para binario
                                                              // Mostramos en el TextBox
                txtCalculo.Text = binario;

                // Guardamos en el historial visual
                lstHistorial.Items.Add($"{entero}  BIN = {binario}");
                operacion = entero.ToString() + " BIN";
                resultado = txtCalculo.Text;
            }
            else
            {
                MessageBox.Show("Ingrese un número válido para convertir a BIN.");
            }

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

        private void btnDec_Click(object sender, EventArgs e)
        {
            string texto = txtCalculo.Text.Trim();
            string resultado = "";
            string operacion = "";

            try
            {
                int numeroDecimal;
                

                // Detectar si es binario (solo 0 y 1)
                if (texto.All(c => c == '0' || c == '1'))
                {
                    numeroDecimal = Convert.ToInt32(texto, 2); // base 2
                }
                // Detectar si es hexadecimal (0-9 y A-F)
                else
                {
                    numeroDecimal = Convert.ToInt32(texto, 16); // base 16
                }

                // Mostrar resultado en decimal
                txtCalculo.Text = numeroDecimal.ToString();

                // Guardar en historial
                lstHistorial.Items.Add($"{texto} DEC = {numeroDecimal}");
                operacion = texto + " DEC";
                resultado = txtCalculo.Text;
            }
            catch
            {
                MessageBox.Show("Número inválido para conversión a decimal.");
            }

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
