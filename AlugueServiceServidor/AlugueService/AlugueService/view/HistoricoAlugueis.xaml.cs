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
    /// Interaction logic for HistoricoAlugueis.xaml
    /// </summary>
    public partial class HistoricoAlugueis : Window
    {
        Aluguel aluguel;
        List<Aluguel> listaHistoricoAlugueis;
        AluguelController aluguelController;

        public HistoricoAlugueis()
        {
            InitializeComponent();
            aluguelController = new AluguelController();
            this.listaHistoricoAlugueis = aluguelController.listarHistorico();
            listarHistoricoAlugueis();
        }

        private void listarHistoricoAlugueis()
        {
            this.dgHistorico.ItemsSource = this.listaHistoricoAlugueis;
        }

        private void MenuItemVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Detalhes_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgHistorico.SelectedItem == null)
            {
                MessageBox.Show("Selecione um aluguel para visualizar!", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Aluguel aluguel = new Aluguel();

                var aluguelSelecionado = this.dgHistorico.SelectedItem as Aluguel;
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
