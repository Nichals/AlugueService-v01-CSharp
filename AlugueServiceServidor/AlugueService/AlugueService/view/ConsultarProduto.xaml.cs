using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using alugueservice.vo;
using AlugueService.controller;
using AlugueService.view;

namespace AlugueService
{
    /// <summary>
    /// Interaction logic for ConsultarProduto.xaml
    /// </summary>
    public partial class ConsultarProduto : Window
    {
        Produto produto;
        List<Produto> listaProdutos;
        ProdutoController produtoController;


        public ConsultarProduto()
        {
            InitializeComponent();

            produtoController = new ProdutoController();
            this.listaProdutos = produtoController.Listar();

            listarProdutos();

        }


        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            Int32 idProduto;
            if (tbIDProduto.Text == "")
            {
                MessageBox.Show("Informe um ID para pesquisar", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                idProduto = Convert.ToInt32(tbIDProduto.Text);
                this.listaProdutos = produtoController.Pesquisar(idProduto);

                listarProdutos();
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgProduto.SelectedItem == null)
            {
                MessageBox.Show("Selecione um produto para editar!", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Produto produto = new Produto();


                var produtoSelecionado = this.dgProduto.SelectedItem as Produto;
                this.produto = produtoSelecionado;

                produto.IdProduto = this.produto.IdProduto;
                produto.Valor = this.produto.Valor;
                produto.Status = this.produto.Status;

                if(produto.Status == 2)
                {
                    MessageBox.Show("Não é possivel editar produto alugado!", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                    produto = null;
                    return;
                }

                produto.Nome = this.produto.Nome;
                produto.Descricao = this.produto.Descricao;
                produto.Tamanho = this.produto.Tamanho;
                produto.Genero = this.produto.Genero;

                EditarProduto jan = new EditarProduto(produto);
                jan.Show();
                this.Close();
            }

        }


        private void btnDesativar_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgProduto.SelectedItem == null)
            {
                MessageBox.Show("Selecione um produto para ativar/desativar!", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Produto produto = new Produto();

                var produtoSelecionado = this.dgProduto.SelectedItem as Produto;
                this.produto = produtoSelecionado;

                produto.IdProduto = this.produto.IdProduto;
                produto.Status = this.produto.Status;

                if (produto.Status == 0)
                {
                    produtoController = new ProdutoController();
                    produtoController.ativar(produto);
                    this.listaProdutos = produtoController.Listar();
                    listarProdutos();
                }
                else if (produto.Status == 1)
                {
                    produtoController = new ProdutoController();
                    produtoController.desativar(produto);
                    this.listaProdutos = produtoController.Listar();
                    listarProdutos();
                }
                else
                {
                    MessageBox.Show("Não é possivel alterar status de produto alugado!", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                    produto = null;
                    return;
                }


            }

        }

        private void MenuItemVoltar_Click(object sender, RoutedEventArgs e)
        {
            TelaPrincipal jan = new TelaPrincipal();
            jan.Show();
            this.Close();
        }

        private void listarProdutos()
        {
            this.dgProduto.ItemsSource = this.listaProdutos;
        }


        //TEXTBOX ID PRODUTO SÓ ACEITAR NUMEROS E ENTER
        private void tbIDProduto_KeyDown(object sender, KeyEventArgs e)
        {
            KeyConverter key = new KeyConverter();

            if ((char.IsNumber((string)key.ConvertTo(e.Key, typeof(string)), 0) == false))
            {
                e.Handled = true;
            }
            if (e.Key == Key.Return)
            {
                btnPesquisar_Click(sender, e);
            }
            if (e.Key == Key.F5)
            {
                btnAtualizar_Click(sender, e);
            }

        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            this.listaProdutos = produtoController.Listar();

            listarProdutos();
        }

        private void btnHistoricoProduto_Click(object sender, RoutedEventArgs e)
        {
            HistoricoProduto jan = new HistoricoProduto();
            jan.ShowDialog();
        }



    }
}
