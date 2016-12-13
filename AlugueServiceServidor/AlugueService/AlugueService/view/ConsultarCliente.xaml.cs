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

namespace AlugueService
{
    /// <summary>
    /// Interaction logic for ConsultarCliente.xaml
    /// </summary>
    public partial class ConsultarCliente : Window
    {

        Cliente cliente;
        List<Cliente> listaClientes;
        ClienteController clienteController;

        public ConsultarCliente()
        {
            InitializeComponent();
            clienteController = new ClienteController();
            this.listaClientes = clienteController.listar();
            listarClientes();

        }

        private void MenuItemVoltar_Click(object sender, RoutedEventArgs e)
        {
            TelaPrincipal jan = new TelaPrincipal();
            jan.Show();
            this.Close();
        }

        private void btnDesativar_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgCliente.SelectedItem == null)
            {
                MessageBox.Show("Selecione um cliente para ativar/desativar!", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Cliente cliente = new Cliente();

                var operadorSelecionado = this.dgCliente.SelectedItem as Cliente;
                this.cliente = operadorSelecionado;

                cliente.IdCliente = this.cliente.IdCliente;
                cliente.Status = this.cliente.Status;

                if (cliente.Status == 0)
                {
                    clienteController = new ClienteController();
                    clienteController.ativar(cliente);
                    this.listaClientes = clienteController.listar();
                    listarClientes();

                }
                else if (cliente.Status == 1)
                {
                    clienteController = new ClienteController();
                    clienteController.desativar(cliente);
                    this.listaClientes = clienteController.listar();
                    listarClientes();
                }

            }
        }

        private void listarClientes()
        {
            this.dgCliente.ItemsSource = this.listaClientes;
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            String nomePesquisado;
            if (tbNomePesquisa.Text == "")
            {
                MessageBox.Show("Informe um nome para pesquisar", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                nomePesquisado = tbNomePesquisa.Text;
                this.listaClientes = clienteController.pesquisar(nomePesquisado);

                listarClientes();
            }

        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            this.listaClientes = clienteController.listar();
            listarClientes();
        }

        private void tbNomePesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnPesquisar_Click(sender, e);
            }
        }
    }
}
