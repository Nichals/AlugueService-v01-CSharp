using alugueservice.vo;
using AlugueService.controller;
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

namespace AlugueService.view
{
    /// <summary>
    /// Interaction logic for HistoricoProduto.xaml
    /// </summary>
    public partial class HistoricoProduto : Window
    {

        List<Produto> listaHistoricoProdutos;
        ProdutoController produtoController;

        public HistoricoProduto()
        {
            InitializeComponent();

            produtoController = new ProdutoController();
            this.listaHistoricoProdutos = produtoController.ListarHistorico();

            listarHistoricoProdutos();
        }

        public void listarHistoricoProdutos()
        {
            this.dgHistoricoProdutos.ItemsSource = this.listaHistoricoProdutos;
            
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
