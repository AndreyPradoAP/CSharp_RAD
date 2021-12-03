/*
    Projeto do 3° Bimestre do segundo ano do Técnico em Informática.
    Programa que simula um sistema de vendas, onde o usuário pode parcelar suas compras, estabelecer as datas de vencimento, ter acrescimo de juros se a parcela vencer.

    OBS:    textBox1 - Entrada valor total da compra;
            textBox2 - Entrada valor da entrada do pagamento;
             textBox3 - Entrada quantidade de parcelas;
             textBox4 - Entrada dia da compra;
             textBox5 - Entrada mês da compra;
             textBox6 - Entrada ano da compra;
             textBox7 - Saída parecelas e seus respctivos valores e datas, caixa de texto multiline;
             textBox8 - Entrada dia do pagamento;
             textBox9 - Entrada mês do pagamento;
             textBox10 - Entrada ano do pagamento;
             label1 - Saída valor parcela a ser paga;
             label2 - Saída valor total a pagar; 
             button1 - Calculo das parcelas e do que falta pagar;
             button2 - Especifica o valor da parcela a ser paga;
             button3 - Dá baixa no pagamento da parcela.             
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

namespace Projeto_3_Bimestre
{
    public partial class Form1 : Form
    {
        DateTime dataCompra = new DateTime();
        DateTime dataParcelas = new DateTime();
        float valorParcela = 0;
        float valorRestoCompra = 0;
        int numParcelas = 0;
        int parcelasPagas = 0;
        int diaNum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox7.Clear();

            float totalCompra = int.Parse(textBox1.Text);
            float entrada = float.Parse(textBox2.Text);
            numParcelas = int.Parse(textBox3.Text);
            valorRestoCompra = totalCompra - entrada;
            valorParcela = valorRestoCompra / numParcelas;

            label1.Text = string.Format("{0:C2}", valorRestoCompra);

            parcelasPagas = 0;
            
            dataCompra = new DateTime(int.Parse(textBox6.Text), int.Parse(textBox5.Text), int.Parse(textBox4.Text));
            dataParcelas = dataCompra;

            // Estabelecer os valores e datas de pagamento de cada parcela
            for (int c = 0; c <= numParcelas - 1; c++)
            {
                // Soma 30 dias e confere se cai no final de semana
                dataParcelas = dataParcelas.AddDays(30);
                diaNum = (int)dataParcelas.DayOfWeek;

                if (diaNum == 0)
                {
                    textBox7.AppendText(string.Format("{0}° Parcela - Valor: {1:C2}, Vencimento: ", c + 1, valorParcela) + dataParcelas.AddDays(1).ToString("dd/MM/yyyy") + Environment.NewLine);
                }
                else if (diaNum == 6)
                {
                    textBox7.AppendText(string.Format("{0}° Parcela - Valor: {1:C2}, Vencimento: ", c + 1, valorParcela) + dataParcelas.AddDays(2).ToString("dd/MM/yyyy") + Environment.NewLine);
                }
                else
                {
                    textBox7.AppendText(string.Format("{0}° Parcela - Valor: {1:C2}, Vencimento: ", c + 1, valorParcela) + dataParcelas.ToString("dd/MM/yyyy") + Environment.NewLine);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numParcelas != parcelasPagas)
            {
                DateTime dataPagar = new DateTime(int.Parse(textBox10.Text), int.Parse(textBox9.Text), int.Parse(textBox8.Text));

                dataParcelas = dataCompra;

                // Calculo do dia da parcela à ser paga
                dataParcelas = dataParcelas.AddDays(parcelasPagas * 30);

                dataParcelas = dataParcelas.AddDays(30);
                diaNum = (int)dataParcelas.DayOfWeek;

                if (diaNum == 0)
                {
                    dataParcelas = dataParcelas.AddDays(1);
                }
                else
                {
                    if (diaNum == 6)
                    {
                        dataParcelas = dataParcelas.AddDays(2);
                    }
                }

                // Mostra o valor da parcela a ser paga
                if (dataParcelas >= dataPagar)
                {
                    label2.Text = "Valor Parcela à Pagar: " + string.Format("{0:C2}", valorParcela);
                }
                else
                {
                    label2.Text = "Valor Parcela à Pagar + Juros: " + string.Format("{0:C2}", valorParcela + (valorParcela / 100 * 3));
                }
            }
            else
            {
                label2.Text = "A divida já foi quitada!";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (numParcelas != parcelasPagas)
            {
                textBox7.Clear();

                valorRestoCompra -= valorParcela;
                label1.Text = string.Format("{0:C2}", valorRestoCompra);

                dataParcelas = dataCompra;

                parcelasPagas++;
                dataParcelas = dataParcelas.AddDays(parcelasPagas * 30);

                diaNum = (int)dataParcelas.DayOfWeek;

                for (int c = parcelasPagas; c <= numParcelas - 1; c++)
                {
                    dataParcelas = dataParcelas.AddDays(30);
                    diaNum = (int)dataParcelas.DayOfWeek;

                    if (diaNum == 0)
                    {
                        textBox7.AppendText(string.Format("{0}° Parcela - Valor: {1:C2}, Vencimento: ", c + 1, valorParcela) + dataParcelas.AddDays(1).ToString("dd/MM/yyyy") + Environment.NewLine);
                    }
                    else if (diaNum == 6)
                    {
                        textBox7.AppendText(string.Format("{0}° Parcela - Valor: {1:C2}, Vencimento: ", c + 1, valorParcela) + dataParcelas.AddDays(2).ToString("dd/MM/yyyy") + Environment.NewLine);
                    }
                    else
                    {
                        textBox7.AppendText(string.Format("{0}° Parcela - Valor: {1:C2}, Vencimento: ", c + 1, valorParcela) + dataParcelas.ToString("dd/MM/yyyy") + Environment.NewLine);
                    }

                    label2.Text = "Pagamento: ";
                }
            }
            else
            {
                textBox7.Clear();
                textBox7.AppendText("A divida já foi quitada!");
                label1.Text = "A divida já foi quitada!";
            }
        }
    }
}
