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
    /// Interaction logic for ConsultarOperador.xaml
    /// </summary>
    public partial class ConsultarOperador : Window
    {
        Operador operador;
        List<Operador> listaOperadores;
        OperadorController operadorController;

        public ConsultarOperador()
        {
            InitializeComponent();
            operadorController = new OperadorController();
            this.listaOperadores = operadorController.Listar();

            listarOperadores();

        }

        private void MenuItemVoltar_Click(object sender, RoutedEventArgs e)
        {
            TelaPrincipal jan = new TelaPrincipal();
            jan.Show();
            this.Close();
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
                this.listaOperadores = operadorController.pesquisar(nomePesquisado);

                listarOperadores();
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgOperador.SelectedItem == null)
            {
                MessageBox.Show("Selecione um operador para editar!", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Operador operador = new Operador();

                var operadorSelecionado = this.dgOperador.SelectedItem as Operador;
                this.operador = operadorSelecionado;

                if (this.operador.IdOperador != 1)
                {

                    operador.IdOperador = this.operador.IdOperador;
                    operador.Nome = this.operador.Nome;
                    operador.Sobrenome = this.operador.Sobrenome;
                    operador.Senha = this.operador.Senha;
                    operador.Status = this.operador.Status;
                    operador.Nivel = this.operador.Nivel;
                    operador.Cpf = this.operador.Cpf;
                    operador.Telefone = this.operador.Telefone;
                    operador.Celular = this.operador.Celular;
                    operador.Rua = this.operador.Rua;
                    operador.Numero = this.operador.Numero;
                    operador.Cidade = this.operador.Cidade;
                    operador.Cep = this.operador.Cep;
                    operador.Bairro = this.operador.Bairro;

                    EditarOperador jan = new EditarOperador(operador);
                    jan.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Não é possivel editar o ADMIN!", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                    operador = null;
                    return;
                }

            }
        }

        private void btnDesativar_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgOperador.SelectedItem == null)
            {
                MessageBox.Show("Selecione um operador para ativar/desativar!", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Operador operador = new Operador();

                var operadorSelecionado = this.dgOperador.SelectedItem as Operador;
                this.operador = operadorSelecionado;

                operador.IdOperador = this.operador.IdOperador;
                operador.Status = this.operador.Status;
                if (operador.IdOperador != 1)
                {


                    if (operador.Status == 0)
                    {
                        operadorController = new OperadorController();
                        operadorController.ativar(operador);
                        this.listaOperadores = operadorController.Listar();
                        listarOperadores();
                        
                    }
                    else if (operador.Status == 1)
                    {
                        operadorController = new OperadorController();
                        operadorController.desativar(operador);
                        this.listaOperadores = operadorController.Listar();
                        listarOperadores();
                    }
                }
                else
                {
                    MessageBox.Show("Não é possivel alterar status do ADMIN!", "ERRO!", MessageBoxButton.OK, MessageBoxImage.Error);
                    operador = null;
                    return;
                }

            }
        }

        private void listarOperadores()
        {
            this.dgOperador.ItemsSource = this.listaOperadores;
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            this.listaOperadores = operadorController.Listar();
            listarOperadores();
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
