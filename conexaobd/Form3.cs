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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        String palavrachave, Login, Senha, logar;
        int x;
        private MySqlConnection conexao = new MySqlConnection();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader leitor;
        public static String perfil;

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox3.Enabled = true;
            conexao = new MySqlConnection("Server=Localhost; Database=etim3_2018; UID=root; PWD=; Port=3306");
            conexao.Open();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Login = textBox1.Text;
            palavrachave = textBox3.Text;
            try
            {
                string strsql = "SELECT * FROM login_funcionario WHERE login = '" + Login + "' AND palavra_chave = '" + palavrachave + "'";

                comando.Connection = conexao;
                comando.CommandText = strsql;
                leitor = comando.ExecuteReader();

                if (leitor.HasRows)
                {

                    leitor.Read();
                    perfil = leitor["login"].ToString();

                    if (!leitor.IsClosed) { leitor.Close(); }
                    MessageBox.Show("Login efetuado!", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Hide();
                    conexao.Close();
                    Form2 logar = new Form2();
                    logar.ShowDialog();

                }

            // Login funcionando pra cima
                else
                {
                    x++;
                    if (x < 3)
                    {
                        MessageBox.Show("Usuário e/ou palavra-chave incorretos", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Clear();

                        textBox1.Focus();
                        // Login sem autenticação funcionando pra cima
                    }
                     else{
                        MessageBox.Show("Seu acesso com a palavra-chave foi bloqueado!", "Acesso", MessageBoxButtons.OK);
                        conexao.Close();
                        MessageBox.Show("Altere sua senha, retorne à tela inicial!", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conexao.Close();
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        button1.Enabled = false;
                        
                     
                        
                        textBox3.Clear();

                        /////////////////////////////////////

                 
                    }



                }
                if (!leitor.IsClosed) { leitor.Close(); } 
                    
                }
                    


                
            

            catch
            {

            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            conexao.Close();
            Form1 inicial = new Form1();
            inicial.ShowDialog();
        }
       
        
    }
}
        


