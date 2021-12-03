/* 
    Projeto do 2° Bimestre do segundo ano do Técnico em Informática.
    Programa que simula uma análise de dados estatísticos, onde são pegos dados referentes ao valor do salário, idade e grau de instrução.
    Após o cadastros de todos os dados, são feitas estatísticas com os dados de entrada.
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

namespace WindowsFormsApp2
{
	public partial class Form1 : Form
	{
		int csMenos500;
		float salTotalMenor25;
		int qtdPessoasMenor25;
		float salTotalMaior25;
		int qtdPessoasMaior25;
		int idadePessoas2Grau;
		int qtdPessoas2Grau;
		int qtdPessoasTotal;
		int qtdPessoasPrimario;
		int qtdPessoasSuperior;
		int idadePessoasSuperior;
		float maiorSal;
		float menorSal;

		public Form1()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textBox4.AppendText("Pessoas que possuem curso superior e ganham menos que R$500,00: "+ csMenos500.ToString("0.00") +" pessoas"+Environment.NewLine);

			if ((qtdPessoasMaior25 != 0) && (qtdPessoasMenor25 != 0))
            {
				float mediaSalMenor25 = salTotalMenor25 / qtdPessoasMenor25;

				float mediaSalMaior25 = salTotalMaior25 / qtdPessoasMaior25;

				float diferencaMediaSal25 = mediaSalMenor25 - mediaSalMaior25;
				diferencaMediaSal25 = Math.Abs(diferencaMediaSal25);

				textBox4.AppendText("A diferença de salário das pessoas com mais de 25 anos em relação as pessoas que tem menos de 25 anos é de: R$"+ diferencaMediaSal25.ToString("0.00") + Environment.NewLine);
			}

			if (qtdPessoas2Grau != 0)
			{
				int mediaIdade2Grau = (int)idadePessoas2Grau / qtdPessoas2Grau;
				textBox4.AppendText("Idade média das pessoas que possuem o 2° grau: " + mediaIdade2Grau.ToString("0.00") + " anos" + Environment.NewLine);
			}

			if (qtdPessoasTotal != 0)
			{
				float porcemPessoasPrimario = (100 * qtdPessoasPrimario) / qtdPessoasTotal;
				textBox4.AppendText("Porcentagem das pessoas que possuem o curso primário: " + porcemPessoasPrimario.ToString("0.00") + "%" + Environment.NewLine);

				float porcemPessoasSuperior = (100 * qtdPessoasSuperior) / qtdPessoasTotal;
				textBox4.AppendText("Porcentagem das pessoas que possuem curso superior: " + porcemPessoasSuperior.ToString("0.00") + "%" + Environment.NewLine);
			}

			if (qtdPessoasSuperior != 0)
			{
				int mediaIdadeSuperior = (int)idadePessoasSuperior / qtdPessoasSuperior;
				textBox4.AppendText("Idade média das pessoas que possuem o 2° grau: " + mediaIdadeSuperior.ToString("0.00") + " anos" + Environment.NewLine);
			}

			textBox4.AppendText("O maior salário foi: R$" + maiorSal.ToString("0.00") + Environment.NewLine);

			textBox4.AppendText("O menor salário foi: R$" + menorSal.ToString("0.00") + Environment.NewLine);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			float sal = float.Parse(textBox1.Text);
			int idade = int.Parse(textBox2.Text);
			int gi = int.Parse(textBox3.Text);

			qtdPessoasTotal++;

			if ((gi == 3) && (sal < 500))
			{
				csMenos500++;
			}

			if (idade < 25)
            {
				salTotalMenor25 += sal;
				qtdPessoasMenor25++;
            }
			else
            {
				salTotalMaior25 += sal;
				qtdPessoasMaior25++;
			}

			if (gi == 2)
			{
				idadePessoas2Grau += idade;
				qtdPessoas2Grau++;
			}

			if (gi == 1)
			{
				qtdPessoasPrimario++;
			}

			if (gi == 3)
			{
				idadePessoasSuperior += idade;
				qtdPessoasSuperior++;
			}

			if (maiorSal < sal)
			{
				maiorSal = sal;
			}

			if (qtdPessoasTotal == 1)
			{
				menorSal = sal;
			}
			else
			{
				if (menorSal > sal)
				{
					menorSal = sal;
				}
			}
		}
	}
}