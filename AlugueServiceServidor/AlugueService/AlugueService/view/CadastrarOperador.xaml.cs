using alugueservice.vo;
using AlugueService.controller;
using AlugueService.utilitario;
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
    /// Interaction logic for CadastrarOperador.xaml
    /// </summary>
    public partial class CadastrarOperador : Window
    {
        Operador operador;
        OperadorController operadorController;
        ClienteController clienteController;
        Utilitaria util = new Utilitaria();


        public CadastrarOperador()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            tbNomeOperador.Text = "";
            tbSobrenomeOperador.Text = "";
            tbTelefoneOperador.Text = "";
            tbCelularOperador.Text = "";
            tbCPFOperador.Text = "";
            tbRuaOperador.Text = "";
            tbNumeroOperador.Text = "";
            tbBairroOperador.Text = "";
            cbCidadeOperador.SelectedIndex = -1;
            tbCEPOperador.Text = "";
            pbSenhaOperador.Password = "";
            cbAcessos.SelectedIndex = -1;
        }

        private void MenuItemVoltar_Click(object sender, RoutedEventArgs e)
        {
            TelaPrincipal jan = new TelaPrincipal();
            jan.Show();
            this.Close();
        }



        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            operador = new Operador();
            //VALIDAR NOME
            if (tbNomeOperador.Text == "")
            {
                MessageBox.Show("Informe o nome do operador", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbNomeOperador.Focus();
                return;
            }
            else
            {
                String nomeRecebido = tbNomeOperador.Text;
                if (Regex.IsMatch(nomeRecebido, @"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]+$"))

                {
                    operador.Nome = util.normalizarString(nomeRecebido);
                }
                else
                {
                    MessageBox.Show("Nome inválido", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbNomeOperador.Focus();
                    return;
                }
            }


            //VALIDAR SOBRENOME
            if (tbSobrenomeOperador.Text == "")
            {
                MessageBox.Show("Informe o sobrenome do operador", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbSobrenomeOperador.Focus();
                return;
            }
            else
            {
                String sobrenomeRecebido = tbSobrenomeOperador.Text;
                if (Regex.IsMatch(sobrenomeRecebido, @"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$"))

                {
                    operador.Sobrenome = sobrenomeRecebido;
                }
                else
                {
                    MessageBox.Show("Sobrenome inválido", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbSobrenomeOperador.Focus();
                    return;
                }
            }

            //VALIDAR TELEFONE
            if (tbTelefoneOperador.Text == "")
            {
                MessageBox.Show("Informe o telefone do operador", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbTelefoneOperador.Focus();
                return;
            }
            else
            {
                String telefoneRecebido = tbTelefoneOperador.Text;
                if (Regex.IsMatch(telefoneRecebido, @"^\(\d{2}\)\d{4}-\d{4}$"))
                {
                    operador.Telefone = telefoneRecebido;
                }
                else
                {
                    MessageBox.Show("Telefone invalido", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbTelefoneOperador.Focus();
                    return;
                }
            }

            //VALIDAR CELULAR
            if (tbCelularOperador.Text == "")
            {
                MessageBox.Show("Informe o celular do operador", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbCelularOperador.Focus();
                return;
            }
            else
            {
                String celularRecebido = tbCelularOperador.Text;
                if (Regex.IsMatch(celularRecebido, @"^\(\d{2}\)\d{4,5}-\d{4}$"))
                {
                    operador.Celular = celularRecebido;
                }
                else
                {
                    MessageBox.Show("Celular invalido", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbCelularOperador.Focus();
                    return;
                }
            }

            //VALIDAR CPF
            if (tbCPFOperador.Text == "")
            {
                MessageBox.Show("Informe o CPF do operador", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbCPFOperador.Focus();
                return;
            }
            else
            {
                String CPFRecebido = tbCPFOperador.Text;
                if (Regex.IsMatch(CPFRecebido, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$"))
                {
                    operador.Cpf = CPFRecebido;

                }
                else
                {
                    MessageBox.Show("CPF invalido", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbCPFOperador.Focus();
                    return;
                }
            }


            //VALIDAR SENHA
            if (pbSenhaOperador.Password == "")
            {
                MessageBox.Show("Informe a senha do operador", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                pbSenhaOperador.Focus();
                return;
            }
            else
            {
                String SenhaRecebida = pbSenhaOperador.Password;
                if (Regex.IsMatch(SenhaRecebida, @"^[a-zA-Z0-9]{4,10}$"))
                {
                    CheckSenha.IsChecked = false;
                    operador.Senha = SenhaRecebida;
                }
                else
                {
                    MessageBox.Show("Senha invalida", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                    pbSenhaOperador.Focus();
                    return;
                }
            }

            //VALIDAR RUA 
            if (tbRuaOperador.Text == "")
            {
                MessageBox.Show("Informe a rua do operador", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbRuaOperador.Focus();
                return;
            }
            else
                operador.Rua = tbRuaOperador.Text;

            //VALIDAR NUMERO 
            if (tbNumeroOperador.Text == "")
            {
                MessageBox.Show("Informe o numero do operador", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbNumeroOperador.Focus();
                return;
            }
            else
                operador.Numero = tbNumeroOperador.Text;

            //VALIDAR BAIRRO 
            if (tbBairroOperador.Text == "")
            {
                MessageBox.Show("Informe o bairro do operador", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbBairroOperador.Focus();
                return;
            }
            else
                operador.Bairro = tbBairroOperador.Text;

            //VALIDAR CIDADE
            if (cbCidadeOperador.Text == "")
            {
                MessageBox.Show("Informe a cidade do operador", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbBairroOperador.Focus();
                return;
            }
            else
                operador.Cidade = cbCidadeOperador.Text;

            //VALIDAR CEP
            if (tbCEPOperador.Text == "")
            {
                MessageBox.Show("Informe o CEP do operador", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                tbCEPOperador.Focus();
                return;
            }
            else
            {
                String CEPRecebido = tbCEPOperador.Text;
                if (Regex.IsMatch(CEPRecebido, @"^\d{5}-\d{3}$"))
                {
                    operador.Cep = CEPRecebido;
                }
                else
                {
                    MessageBox.Show("CEP invalido", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbCEPOperador.Focus();
                    return;
                }
            }

            //VALIDAR ACESSO
            if (cbAcessos.Text == "")
            {
                MessageBox.Show("Informe o nível de acesso do operador", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                cbAcessos.Focus();
                return;
            }
            else

            if (cbAcessos.Text == "ADM")
            {
                operador.Nivel = 1;
            }
            else
            {
                operador.Nivel = 2;
            }

            {
                operadorController = new OperadorController();
                clienteController = new ClienteController();
                if (operadorController.ValidarCPFOperador(operador.Cpf))
                {
                    if (clienteController.ValidarCPFCliente(operador.Cpf))
                    {
                        MessageBoxResult result = MessageBox.Show(this, "Confirmar cadastro do operador?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {

                            operadorController.inserir(operador);
                            MessageBox.Show("Operador cadastrado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                            TelaPrincipal jan = new TelaPrincipal();
                            jan.Show();
                            this.Close();
                        }
                    }
                    tbCPFOperador.Focus();

                }

            }
        }


        //CHECKBOX VISUALIZAR SENHA
        private void CheckSenha_Checked(object sender, RoutedEventArgs e)
        {
            pbSenhaOperador.Visibility = System.Windows.Visibility.Collapsed;
            tbSenha.Visibility = System.Windows.Visibility.Visible;
            tbSenha.Text = pbSenhaOperador.Password;
            tbSenha.Focus();
        }
        private void CheckSenha_Unchecked(object sender, RoutedEventArgs e)
        {
            pbSenhaOperador.Visibility = System.Windows.Visibility.Visible;
            tbSenha.Visibility = System.Windows.Visibility.Collapsed;
            pbSenhaOperador.Password = tbSenha.Text;
            pbSenhaOperador.Focus();
        }
    }
}
