using alugueservice.vo;
using AlugueService.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AlugueService
{
    /// <summary>
    /// Interaction logic for Configuracoes.xaml
    /// </summary>
    public partial class Configuracoes : Window
    {
        Configuracao configuracao;
        ConfiguracaoController configuracaoController;

        public Configuracoes()
        {
            InitializeComponent();
            
            configuracaoController = new ConfiguracaoController();
            this.configuracao = configuracaoController.Listar();

            listarConfiguracao();

        }

        private void listarConfiguracao()
        {
            String valorCupom, valorMulta;
            valorCupom = this.configuracao.ValorCupom.ToString();
            valorMulta = this.configuracao.ValorMulta.ToString();

                // RETORNAR VALOR CUPOM VALIDADO
               if (Regex.IsMatch(valorCupom, @"^[0-9]+(\,[0-9]{2})$"))
                {
                    tbValorCupom.Text = valorCupom;
                }
                else if (Regex.IsMatch(valorCupom, @"^[0-9]+(\,[0-9]{1})$"))
                {
                    tbValorCupom.Text = valorCupom + "0";
                }
               else
               {
                   tbValorCupom.Text = valorCupom + ",00";
               }
                
                //RETORNAR VALOR MULTA VALIDADO
               if (Regex.IsMatch(valorMulta, @"^[0-9]+(\,[0-9]{2})$"))
               {
                   tbValorMulta.Text = valorMulta;
               }
               else if (Regex.IsMatch(valorMulta, @"^[0-9]+(\,[0-9]{1})$"))
               {
                   tbValorMulta.Text = valorMulta + "0";
               }
               else
               {
                   tbValorMulta.Text = valorMulta + ",00";
               }
            
            
        }

        private void MenuItemVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            configuracao = new Configuracao();
            if (tbValorCupom.Text == "")
            {
                MessageBox.Show("Informe o valor do cupom", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbValorCupom.Focus();
                return;
            }
            else
            {
                String valorCupom = tbValorCupom.Text;
                if (Regex.IsMatch(valorCupom, @"^[0-9]+(\,[0-9]{2})$") && (float)Convert.ToDouble(valorCupom) > 0)
                {
                    configuracao.ValorCupom = (float)Convert.ToDouble(tbValorCupom.Text);
                }
                else
                {
                    MessageBox.Show("Valor do cumpom inválido", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbValorCupom.Focus();
                    return;
                }
            }


            //VALOR MULTA
            if (tbValorMulta.Text == "")
            {
                MessageBox.Show("Informe o valor da multa", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbValorMulta.Focus();
                return;
            }
            else
            {
                String valorMulta = tbValorMulta.Text;
                if (Regex.IsMatch(valorMulta, @"^[0-9]+(\,[0-9]{2})$") && (float)Convert.ToDouble(valorMulta) > 0)
                {
                    configuracao.ValorMulta = (float)Convert.ToDouble(tbValorMulta.Text);
                    MessageBoxResult result = MessageBox.Show(this, "Deseja atualizar configuração?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        configuracaoController = new ConfiguracaoController();
                        configuracaoController.inserir(configuracao);
                        MessageBox.Show("Configuração atualizada!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Valor da multa inválido", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbValorMulta.Focus();
                    return;
                }
            }

        }
    }
}
