using alugueservice.vo;
using AlugueService.controller;
using AlugueService.view;
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

namespace AlugueService
{
    /// <summary>
    /// Interaction logic for TelaPrincipal.xaml
    /// </summary>
    public partial class TelaPrincipal : Window
    {
        Aluguel aluguel;
        List<Aluguel> listaAlugueis;
        AluguelController aluguelController;

        public TelaPrincipal()
        {
            InitializeComponent();
            aluguelController = new AluguelController();
            this.listaAlugueis = aluguelController.listar();

            listarAlugueis();
        }

        private void MenuItemConsultarCliente_Click(object sender, RoutedEventArgs e)
        {
            ConsultarCliente jan = new ConsultarCliente();
            jan.Show();
            this.Close();
        }
        private void MenuItemCadastrarProduto_Click(object sender, RoutedEventArgs e)
        {
            CadastrarProduto jan = new CadastrarProduto();
            jan.Show();
            this.Close();
        }
        private void MenuItemConsultarProduto_Click(object sender, RoutedEventArgs e)
        {
            ConsultarProduto jan = new ConsultarProduto();
            jan.Show();
            this.Close();

        }
        private void MenuItemCadastrarOperador_Click(object sender, RoutedEventArgs e)
        {
            CadastrarOperador jan = new CadastrarOperador();
            jan.Show();
            this.Close();
        }
        private void MenuItemConsultarOperador_Click(object sender, RoutedEventArgs e)
        {
            ConsultarOperador jan = new ConsultarOperador();
            jan.Show();
            this.Close();
        }

        private void MenuItemLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(this, "Deseja realmente sair?", "Confirmação", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                MainWindow jan = new MainWindow();
                jan.Show();
                this.Close();
            }
        }

        private void MenuItemConfiguracoes_Click(object sender, RoutedEventArgs e)
        {
            Configuracoes jan = new Configuracoes();
            jan.ShowDialog();
        }



        private void btnHistorico_Click(object sender, RoutedEventArgs e)
        {
            HistoricoAlugueis jan = new HistoricoAlugueis();
            jan.ShowDialog();
        }

        private void listarAlugueis()
        {
            this.dgAluguelAtivo.ItemsSource = this.listaAlugueis;
        }

        private void btn_Detalhes_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgAluguelAtivo.SelectedItem == null)
            {
                MessageBox.Show("Selecione um aluguel para visualizar!", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Aluguel aluguel = new Aluguel();

                var aluguelSelecionado = this.dgAluguelAtivo.SelectedItem as Aluguel;
                this.aluguel = aluguelSelecionado;

                aluguel.IdAluguel = this.aluguel.IdAluguel;
                aluguel.DataAluguel = this.aluguel.DataAluguel;
                aluguel.ValorAluguel = this.aluguel.ValorAluguel;

                DetalhesAluguel jan = new DetalhesAluguel(aluguel);
                jan.ShowDialog();
        }

    }
    }
}

