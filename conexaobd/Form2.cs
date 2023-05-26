using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace conexaobd
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        String palavrachave, Nome, prox;
        int x;
        private MySqlConnection conexao = new MySqlConnection();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader leitor;
        public static String perfil;
        private void Form2_Load(object sender, EventArgs e)
        {
            Nome = "Vinicius Fujita";
            try
            {
                conexao = new MySqlConnection("Server=Localhost; Database=etim3_2018; UID=root; PWD=; Port=3306");
                string strsql = "SELECT * FROM funcionario WHERE nome = "+Nome+"";
                conexao.Open();
                MessageBox.Show(" Bem-Vindo\n"+Nome +"", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Erro na conexão ao Banco de Dados!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            label2.Text = DateTime.Now.ToString("dd/MM/yyyy");






        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 prox = new Form4();
            prox.ShowDialog();
            this.Hide();
            conexao.Close();
        }
        }
    }

