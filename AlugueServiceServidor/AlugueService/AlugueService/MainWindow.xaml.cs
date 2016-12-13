using AlugueService.controller;
using AlugueService.persistencia;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace AlugueService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        OperadorController operadorController;
        OperadorDAO operadorDAO;
        Int32 id;
        private OracleConnection connection;

        public MainWindow()
        {
            InitializeComponent();
            tbLogin.Focus();
            lbCaps.Visibility = System.Windows.Visibility.Collapsed;
        }


        private void MenuItemSair_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(this, "Deseja realmente sair?", "Confirmação", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void MenuItemVersao_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Version: 1.0", "Versão", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnLogar_Click(object sender, RoutedEventArgs e)
        {
            operadorController = new OperadorController();

            if (tbLogin.Text != "")
            {

                if (operadorController.ValidarUsuario(id = Convert.ToInt32(tbLogin.Text), tbSenha.Password))
                {
                    TelaPrincipal jan = new TelaPrincipal();
                    jan.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login ou senha INCORRETOS", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbLogin.Focus();
                }

            }
            else
            {
                MessageBox.Show("DIGITE ID/SENHA DO USUÁRIO", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                tbLogin.Focus();
            }

        }


        //TEXTBOX LOGIN SÓ ACEITAR NUMEROS E TAB
        private void tbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            KeyConverter key = new KeyConverter();

            if ((char.IsNumber((string)key.ConvertTo(e.Key, typeof(string)), 0) == false))
            {
                e.Handled = true;
            }
            if (e.Key == Key.Tab)
            {
                tbSenha.Focus();
            }
        }


        //ACESSAR COM ENTER
        private void tbSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnLogar_Click(sender, e);
            }
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled)
            {
                lbCaps.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                lbCaps.Visibility = System.Windows.Visibility.Collapsed;
            }

        }

    }
}
