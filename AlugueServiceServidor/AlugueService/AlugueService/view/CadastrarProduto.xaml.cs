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
    /// Interaction logic for CadastrarProduto.xaml
    /// </summary>
    public partial class CadastrarProduto : Window
    {
        Produto produto;
        ProdutoController produtoController;

        public CadastrarProduto()
        {
            InitializeComponent();
        }

        private void MenuItemVoltar_Click(object sender, RoutedEventArgs e)
        {
            TelaPrincipal jan = new TelaPrincipal();
            jan.Show();
            this.Close();
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            tbNomeProduto.Text = "";
            tbDescricaoProduto.Text = "";
            tbValorProduto.Text = "";
            cbGeneroProduto.SelectedIndex = -1;
            cbTamanhoProduto.SelectedIndex = -1;
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            produto = new Produto();

            if (tbNomeProduto.Text == "")
            {
                MessageBox.Show("Informe o nome do produto", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbNomeProduto.Focus();
                return;
            }
            else
               produto.Nome = tbNomeProduto.Text;
            
            // VALIDAR TAMANHO
            if (cbTamanhoProduto.Text == "")
            {
                MessageBox.Show("Informe o tamanho do produto", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                cbTamanhoProduto.Focus();
                return;
            }
            else
               produto.Tamanho = cbTamanhoProduto.Text;

            //VALIDAR GENERO
            if (cbGeneroProduto.Text == "")
            {
                MessageBox.Show("Informe o genero do produto", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                cbGeneroProduto.Focus();
                return;
            }
            else
                produto.Genero = cbGeneroProduto.Text;

           //VALIDAR VALOR
           if (tbValorProduto.Text == "")
            {
                MessageBox.Show("Informe o valor do produto", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbValorProduto.Focus();
                return;
            }
            else
            {
                String valorRecebido = tbValorProduto.Text;
                if (Regex.IsMatch(valorRecebido, @"^[0-9]+(\,[0-9]{2})$") && (float)Convert.ToDouble(valorRecebido) > 0)
                {
                    // ATRIBUIR VALOR AO ATRIBUTO DO OBJETO AQUI
                    produto.Valor = (float)Convert.ToDouble(tbValorProduto.Text);

                    if(tbDescricaoProduto.Text == "")
                    {
                        produto.Descricao = "Sem descrição";
                    }
                    else
                    {
                        produto.Descricao = tbDescricaoProduto.Text;
                    }
                    

                    MessageBoxResult result = MessageBox.Show(this, "Confirmar cadastro do produto?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        produtoController = new ProdutoController();
                        produtoController.inserir(produto);
                        MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                        TelaPrincipal jan = new TelaPrincipal();
                        jan.Show();
                        this.Close();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Valor inválido", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbValorProduto.Focus();
                    return;
                }
            }

        }
    }
}
