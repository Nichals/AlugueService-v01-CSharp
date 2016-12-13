using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alugueservice.vo;
using Oracle.ManagedDataAccess.Client;
using AlugueService.utilitario;
using System.Windows;
using System.Data;

namespace AlugueService.persistencia
{
    class ClienteDAO : IClienteDAO
    {
        private String sql;
        private OracleConnection connection;
        private ConnectionFactory factory;
        private OracleCommand comandoOracle = null;
        private OracleDataReader leitorOracle = null;
        private Cliente cliente;
        OracleTransaction transaction = null;


        public List<Cliente> listar()
        {
            Cliente cliente;
            List<Cliente> listaClientes = null;

            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();

            try
            {
                sql = "SELECT * FROM TBL_CLIENTE";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                comandoOracle.CommandText = sql;
                OracleDataReader leitorOracle = comandoOracle.ExecuteReader();

                if (leitorOracle.HasRows)
                {


                    listaClientes = new List<Cliente>();

                    while (leitorOracle.Read())
                    {
                        cliente = new Cliente();

                        cliente.IdCliente = leitorOracle.GetInt32(0);
                        cliente.Nome = leitorOracle.GetString(1);
                        cliente.Sobrenome = leitorOracle.GetString(2);
                        cliente.Telefone = leitorOracle.GetString(3);
                        cliente.Celular = leitorOracle.GetString(4);
                        cliente.Cpf = leitorOracle.GetString(5);
                        cliente.Rua = leitorOracle.GetString(6);
                        cliente.Bairro = leitorOracle.GetString(7);
                        cliente.Numero = leitorOracle.GetString(8);
                        cliente.Cidade = leitorOracle.GetString(9);
                        cliente.Cep = leitorOracle.GetString(10);
                        cliente.Status = leitorOracle.GetInt32(11);

                        if (cliente.Status == 1)
                        {
                            cliente.StatusAux = "Ativo";
                        }
                        else if (cliente.Status == 0)
                        {
                            cliente.StatusAux = "Inativo";
                        }

                        listaClientes.Add(cliente);
                    }

                }

                leitorOracle.Close();

            }
            catch (OracleException exception)
            {
                MessageBox.Show("Erro ao gravar no banco, " + exception.Message);
                listaClientes = null;
            }
            connection.Close();
            return listaClientes;
        }

        public List<Cliente> pesquisar(string nomePesquisado)
        {
            List<Cliente> listaClientes = null;
            Cliente cliente = null;

            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();

            try
            {
                nomePesquisado = "%" + nomePesquisado + "%";
                sql = "SELECT * FROM TBL_CLIENTE WHERE NOME_CLIENTE LIKE :nome_pesquisado";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                comandoOracle.CommandText = sql;
                comandoOracle.Parameters.Add(":nome_pesquisado", nomePesquisado);
                OracleDataReader leitorOracle = comandoOracle.ExecuteReader();

                if (leitorOracle.HasRows)
                {

                    listaClientes = new List<Cliente>();

                    while (leitorOracle.Read())
                    {
                        cliente = new Cliente();

                        cliente.IdCliente = leitorOracle.GetInt32(0);
                        cliente.Nome = leitorOracle.GetString(1);
                        cliente.Sobrenome = leitorOracle.GetString(2);
                        cliente.Telefone = leitorOracle.GetString(3);
                        cliente.Celular = leitorOracle.GetString(4);
                        cliente.Cpf = leitorOracle.GetString(5);
                        cliente.Rua = leitorOracle.GetString(6);
                        cliente.Bairro = leitorOracle.GetString(7);
                        cliente.Numero = leitorOracle.GetString(8);
                        cliente.Cidade = leitorOracle.GetString(9);
                        cliente.Cep = leitorOracle.GetString(10);
                        cliente.Status = leitorOracle.GetInt32(11);

                        if (cliente.Status == 1)
                        {
                            cliente.StatusAux = "Ativo";
                        }
                        else if (cliente.Status == 0)
                        {
                            cliente.StatusAux = "Inativo";
                        }

                        listaClientes.Add(cliente);
                        
                    }

                }

                leitorOracle.Close();

            }
            catch (OracleException exception)
            {
                MessageBox.Show("Erro ao pesquisar no banco, " + exception.Message);
                listaClientes = null;
            }
            connection.Close();
            return listaClientes;
        }

        public Boolean ativar(Cliente cliente)
        {
            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();
            try
            {
                sql = "UPDATE TBL_CLIENTE SET STATUS_CLIENTE = 1 WHERE ID_CLIENTE = :id_cliente";

                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                comandoOracle.Transaction = transaction;
                comandoOracle.CommandText = sql;
                comandoOracle.Parameters.Add(":id_cliente", cliente.IdCliente);

                comandoOracle.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch (OracleException exception)
            {
                transaction.Rollback();
                MessageBox.Show("Erro ao gravar no banco, " + exception.Message);
                return false;
            }
            finally { connection.Close(); }
        }

        public Boolean desativar(Cliente cliente)
        {
            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();
            try
            {
                sql = "UPDATE TBL_CLIENTE SET STATUS_CLIENTE = 0 WHERE ID_CLIENTE = :id_cliente";

                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                comandoOracle.Transaction = transaction;
                comandoOracle.CommandText = sql;
                comandoOracle.Parameters.Add(":id_cliente", cliente.IdCliente);

                comandoOracle.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch (OracleException exception)
            {
                transaction.Rollback();
                MessageBox.Show("Erro ao gravar no banco, " + exception.Message);
                return false;
            }
            finally { connection.Close(); }
        }

        public Boolean ValidarCPFCliente(String cpf)
        {

            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();

            try
            {
                sql = "SELECT CPF_CLIENTE FROM TBL_CLIENTE";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                comandoOracle.CommandText = sql;
                OracleDataReader leitorOracle = comandoOracle.ExecuteReader();

                while (leitorOracle.Read())
                {

                    if (cpf == leitorOracle.GetString(0))
                    {
                        MessageBox.Show("CPF já cadastrado", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }

                return true;

            }
            catch (OracleException exception)
            {
                MessageBox.Show("Erro ao ler no banco, " + exception.Message);
                return false;
            }
            finally { connection.Close(); }
        }



    }
}
