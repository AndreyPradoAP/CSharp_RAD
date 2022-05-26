/*
    Projeto do 4° Bimestre do segundo ano do Técnico em Informática.
    Programa que possibilita cadastrar novos registros, visualizá-los e pesquisar um registro específico através do código. 
    Os registros podem ter uma foto da pessoa.
    OBS: Os registros são salvos em um arquivo texto.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Projeto4_Bimestre
{
    public partial class Form1 : Form
    {
        int indexListBox = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public void pegarDados()
        {
            string[] dadosPessoas = File.ReadAllLines(@"c:\imagem\pessoas.txt");

            listBox1.Items.Clear();

            foreach (string dados in dadosPessoas)
            {
                listBox1.Items.Add(dados);

                indexListBox = 0;
                separarDados(indexListBox);
            }
        }

        public void separarDados(int indexListBox)
        {
            string dado = listBox1.Items[indexListBox].ToString();
            
            textBox1.Text = dado.Substring(0, dado.IndexOf(","));
            dado = dado.Substring(dado.IndexOf(",") + 1, dado.Length - dado.IndexOf(",") - 1);

            textBox2.Text = dado.Substring(0, dado.IndexOf(","));
            dado = dado.Substring(dado.IndexOf(",") + 1, dado.Length - dado.IndexOf(",") - 1);

            textBox3.Text = dado.Substring(0, dado.IndexOf(","));
            dado = dado.Substring(dado.IndexOf(",") + 1, dado.Length - dado.IndexOf(",") - 1);

            textBox4.Text = dado.Substring(0, dado.IndexOf(","));
            dado = dado.Substring(dado.IndexOf(",") + 1, dado.Length - dado.IndexOf(",") - 1);

            textBox5.Text = dado.Substring(0, dado.IndexOf(","));
            dado = dado.Substring(dado.IndexOf(",") + 1, dado.Length - dado.IndexOf(",") - 1);

            textBox6.Text = dado.Substring(0, dado.Length);

            pictureBox1.Load(@"c:\imagem\" + dado);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            pegarDados();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Achar cadastro através do codigo inserido pelo user

            for (int c = 0; c <= listBox1.Items.Count - 1; c++)
            {
                // Pego o item relacionado à variavel c na listBox1
                string dado = listBox1.Items[c].ToString();

                // Comparo se o codigo que o User digitou com o cadastro da listBox1
                if (int.Parse(textBox1.Text) == int.Parse(dado.Substring(0, dado.IndexOf(","))))
                {
                    indexListBox = c;
                    separarDados(indexListBox);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            indexListBox = 0;
            separarDados(indexListBox);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(indexListBox > 0)
            {
                indexListBox--;
                separarDados(indexListBox);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (indexListBox < listBox1.Items.Count - 1)
            {
                indexListBox++;
                separarDados(indexListBox);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            indexListBox = listBox1.Items.Count - 1;
            separarDados(indexListBox);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 8)
            {
                File.AppendAllText(@"c:\imagem\pessoas.txt", textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + "," + textBox5.Text + "," + textBox6.Text + Environment.NewLine);

                MessageBox.Show("Cadastro realizado com sucesso!");

                pegarDados();                
            }
            else
            {
                MessageBox.Show("Erro! O código deve ter oito(8) dígitos.");
            }

            
        }
    }
}
