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
using alugueservice.vo;
using AlugueService.controller;

namespace AlugueService.view
{
    /// <summary>
    /// Interaction logic for DetalhesAluguel.xaml
    /// </summary>
    public partial class DetalhesAluguel : Window
    {
        private Aluguel aluguel;
        List<Produto> listaProdutosAluguel;
        ProdutoController produtoController;

        public DetalhesAluguel(Aluguel aluguel)
        {
            InitializeComponent();
            this.aluguel = aluguel;
            aluguel.IdAluguel = this.aluguel.IdAluguel;
            aluguel.DataAluguel = this.aluguel.DataAluguel;
            aluguel.ValorAluguel = this.aluguel.ValorAluguel;


            tblockIdAluguel.Text = Convert.ToString(aluguel.IdAluguel);
            tblockData.Text = aluguel.DataAluguel.ToString("dd/MM/yyyy");
            tblockIdValor.Text = aluguel.ValorAluguel.ToString("c");

            produtoController = new ProdutoController();
            this.listaProdutosAluguel = produtoController.ListarProdutoAluguel(aluguel.IdAluguel);

            this.dgDetalhe.ItemsSource = this.listaProdutosAluguel;

        }

        private void MenuItemVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
