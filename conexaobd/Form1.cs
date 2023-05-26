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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String palavrachave, Login, Senha, logar;
        int x;
        private MySqlConnection conexao = new MySqlConnection();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader leitor;
        public static String perfil;

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Enabled = false;



            try
            {
                conexao = new MySqlConnection("Server=Localhost; Database=etim3_2018; UID=root; PWD=; Port=3306");
                conexao.Open();
                MessageBox.Show("Bem-Vindo ao StudyHelpp!", "Conexão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch {
                MessageBox.Show("Erro na conexão ao Banco de Dados!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login = textBox1.Text;
            Senha = textBox2.Text;
            try
            {
                string strsql = "SELECT * FROM login_funcionario WHERE login = '" + Login + "' AND senha = '" + Senha + "'";
                
                comando.Connection = conexao;
                comando.CommandText = strsql;
                leitor = comando.ExecuteReader();

                if (leitor.HasRows){
                
                    leitor.Read();
                    perfil = leitor ["login"].ToString();

                    if(!leitor.IsClosed) {leitor.Close();} 
                    MessageBox.Show("Login efetuado!","Acesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        MessageBox.Show("Usuário e/ou senha incorretos", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox2.Clear();

                        textBox1.Focus();
                        // Login sem autenticação funcionando pra cima
                    }
                    else{
                        MessageBox.Show("Seu acesso com a senha foi bloqueado!", "Acesso", MessageBoxButtons.OK);
                        conexao.Close();
                        MessageBox.Show("Tente com a palavra-chave!", "Acesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conexao.Close();
                        textBox2.Enabled = false;
                        this.Hide();
                        conexao.Close();
                        Form3 chave = new Form3();
                        chave.ShowDialog();
                        

                        textBox3.Enabled = true;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            conexao.Close();
            this.Hide();
            Form5 altsenha = new Form5();
            altsenha.ShowDialog();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conexao.Close();
            this.Hide();
            Form6 cadastro = new Form6();
            cadastro.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
            }

            }
        
    


