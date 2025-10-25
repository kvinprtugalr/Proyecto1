namespace Proyecto1
{
    public partial class Form1 : Form
    {

        string connectionString = @"Server=.;Database=Productos;TrustServerCertificate=True;Integrated Security=SSPI;";
        string operacion = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            txtCalculo.Text += "0";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            operacion = txtCalculo.Text;

            try
            {
                // aquí va la lógica para calcular el resultado
                string[] numeros = txtCalculo.Text.Split('+'); // ejemplo simple de suma
                double resultado = 0;

                foreach (string num in numeros)
                {
                    resultado += double.Parse(num);
                }

                txtCalculo.Text = resultado.ToString(); // muestra el resultado
            }
            catch
            {
                txtCalculo.Text = "Error"; // si hay algo mal
            }
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
    }
}   
