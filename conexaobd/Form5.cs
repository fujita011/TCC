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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        string usuario, palavra_chave;
        int x;
        private MySqlConnection conexao = new MySqlConnection();
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader leitor;
        public static String perfil;
        public static int codFunc;

        private void Form5_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            textBox2.Visible = false;
            label3.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox2.Text)
            {
                try
                {
                    if (!leitor.IsClosed) { leitor.Close(); }
                    {
                        leitor.Close();
                    }
                    string strsql;
                    strsql = "Update login_funcionario set ";
                    strsql += "senha = '" + textBox3.Text;
                    strsql += "' Where cod_func = " + codFunc + ";";


                    comando.Connection = conexao;
                    comando.CommandText = strsql;
                    comando.ExecuteNonQuery();

                    MessageBox.Show("Senha alterada com sucesso! Você sera direcionado à tela de login!", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form1 sakaue = new Form1();
                    sakaue.Show();
  
                    


                    if (!leitor.IsClosed)
                    {
                        leitor.Close();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Erro ao alterar senha "+ error.Message, "Alterar senha",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);//NANI////////////////Omaewa Moshindeiru
                }

                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
              usuario = textBox1.Text;
            palavra_chave = textBox4.Text;
            try
            {
                string strql = "SELECT * FROM login_funcionario WHERE login = '" + usuario + "' AND palavra_chave= '" + palavra_chave + "';";
                comando.Connection = conexao;
                comando.CommandText = strql;
                leitor = comando.ExecuteReader();
                //ExecuteReader() (parâmetro) = leitura do dado

                //HasRows = houver linhas/registros
                //leitor = uma tarefa por vez
                if (leitor.HasRows)
                {
                    leitor.Read();
                    codFunc = Convert.ToInt16(leitor["cod_func"].ToString());

                    //fechar quando não estiver fechado

                    MessageBox.Show("Palavra chave verificada!","Alterar Senha",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    label1.Visible = false;
                    textBox1.Visible = false;
                    label6.Visible = false;
                    textBox4.Visible = false;
                    button2.Visible = false;

                    label2.Visible = true;
                    textBox2.Visible = true;
                    label3.Visible = true;
                    textBox3.Visible = true;
                    button1.Visible = true;

                    /*
                    Form2 queijo = new Form2(codFunc);
                    queijo.Show();
                    conexao.Close();
                    this.Close();
                    */ 
                }
                else
                {
                    if (x < 3)
                    {
                        x++;
                        MessageBox.Show("Usuário e/ou palavra-chave inválidos!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                        textBox2.Clear();
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Falha na conexão com a palavra-chave!\nSessão finalizada!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                if (!leitor.IsClosed)
                {
                    leitor.Close();
                }
            }
            catch
            {
                MessageBox.Show("ERRO!","Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }

        
        }
    

