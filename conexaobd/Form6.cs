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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        String palavrachave, nome, senha, RM, usuario, email;
        int x;
        private MySqlConnection conexao = new MySqlConnection();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader leitor;
        public static String perfil;

        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=Localhost; Database=etim3_2018; UID=root; PWD=; Port=3306");
                conexao.Open();
            }
            catch
            {
                MessageBox.Show("Erro na conexão ao Banco de Dados!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


// ==============================================


        private void button1_Click(object sender, EventArgs e)
        {
            nome = textBox1.Text;
            usuario = textBox3.Text;
            palavrachave = textBox7.Text;
            senha = textBox4.Text;
            email = textBox5.Text;
            RM = textBox6.Text;










            MessageBox.Show("Cadastrado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conexao.Close();
            this.Hide();
            Form1 back = new Form1();
            back.ShowDialog();

        }
    }
}
