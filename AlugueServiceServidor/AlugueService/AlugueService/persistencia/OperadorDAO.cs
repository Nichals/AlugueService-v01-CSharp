using alugueservice.vo;
using AlugueService.utilitario;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AlugueService.persistencia
{
    class OperadorDAO : IOperadorDAO
    {
        private String sql;
        private OracleConnection connection;
        private ConnectionFactory factory;
        private OracleCommand comandoOracle = null;
        private OracleDataReader leitorOracle = null;
        private List<Operador> ListaLoginOperador;
        private Operador operador;
        Utilitaria util = new Utilitaria();
        OracleTransaction transaction = null;

        public Boolean inserir(Operador operador)
        {
            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();
            try
            {
                sql = "INSERT INTO TBL_OPERADOR(ID_OPERADOR, NOME_OPERADOR,SOBRENOME_OPERADOR,SENHA_OPERADOR,STATUS_OPERADOR,NIVEL_OPERADOR,CPF_OPERADOR,TELEFONE_OPERADOR,CELULAR_OPERADOR,RUA_OPERADOR,BAIRRO_OPERADOR,NUMERO_OPERADOR,CIDADE_OPERADOR,CEP_OPERADOR) VALUES (ID_OPERADOR.NEXTVAL,:nome_operador,:sobrenome_operador,:senha_operador,1,:nivel_operador,:cpf_operador,:telefone_operador,:celular_operador,:rua_operador,:bairro_operador,:numero_operador,:cidade_operador,:cep_operador)";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                comandoOracle.Transaction = transaction;
                comandoOracle.CommandText = sql;
                comandoOracle.Parameters.Add(":nome_operador", operador.Nome);
                comandoOracle.Parameters.Add(":sobrenome_operador", operador.Sobrenome);
                comandoOracle.Parameters.Add(":senha_operador", operador.Senha);
                comandoOracle.Parameters.Add(":nivel_operador", operador.Nivel);
                comandoOracle.Parameters.Add(":cpf_operador", operador.Cpf);
                comandoOracle.Parameters.Add(":telefone_operador", operador.Telefone);
                comandoOracle.Parameters.Add(":celular_operador", operador.Celular);
                comandoOracle.Parameters.Add(":rua_operador", operador.Rua);
                comandoOracle.Parameters.Add(":bairro_operador", operador.Bairro);
                comandoOracle.Parameters.Add(":numero_operador", operador.Numero);
                comandoOracle.Parameters.Add(":cidade_operador", operador.Cidade);
                comandoOracle.Parameters.Add(":cep_operador", operador.Cep);

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

        public List<Operador> pesquisar(string nomePesquisado)
        {
            List<Operador> listaOperadores = null;
            Operador operador = null;

            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();

            try
            {
                nomePesquisado = "%" + nomePesquisado.ToUpper() + "%";
                sql = "SELECT * FROM TBL_OPERADOR WHERE NOME_OPERADOR LIKE :nome_pesquisado";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                comandoOracle.CommandText = sql;
                comandoOracle.Parameters.Add(":nome_pesquisado", nomePesquisado);
                OracleDataReader leitorOracle = comandoOracle.ExecuteReader();

                if (leitorOracle.HasRows)
                {


                    listaOperadores = new List<Operador>();

                    while (leitorOracle.Read())
                    {
                        operador = new Operador();

                        operador.IdOperador = leitorOracle.GetInt32(0);
                        operador.Nome = leitorOracle.GetString(1);
                        operador.Sobrenome = leitorOracle.GetString(2);
                        operador.Senha = leitorOracle.GetString(3);
                        operador.Status = leitorOracle.GetInt32(4);
                        operador.Nivel = leitorOracle.GetInt32(5);
                        operador.Cpf = leitorOracle.GetString(6);
                        operador.Telefone = leitorOracle.GetString(7);
                        operador.Celular = leitorOracle.GetString(8);
                        operador.Rua = leitorOracle.GetString(9);
                        operador.Bairro = leitorOracle.GetString(10);
                        operador.Numero = leitorOracle.GetString(11);
                        operador.Cidade = leitorOracle.GetString(12);
                        operador.Cep = leitorOracle.GetString(13);

                        operador.Nome = util.DesnormalizarString(operador.Nome);

                        if (operador.Status == 1)
                        {
                            operador.StatusAux = "Ativo";
                        }
                        else if (operador.Status == 0)
                        {
                            operador.StatusAux = "Inativo";
                        }

                        listaOperadores.Add(operador);
                    }

                }

                leitorOracle.Close();

            }
            catch (OracleException exception)
            {
                MessageBox.Show("Erro ao pesquisar no banco, " + exception.Message);
                listaOperadores = null;
            }
            connection.Close();
            return listaOperadores;
        }

        public Boolean editar(Operador operador)
        {
            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();
            try
            {
                sql = "UPDATE TBL_OPERADOR SET NOME_OPERADOR = :nome_operador, SOBRENOME_OPERADOR = :sobrenome_operador, SENHA_OPERADOR = :senha_operador, NIVEL_OPERADOR = :nivel_operador, CPF_OPERADOR = :cpf_operador, TELEFONE_OPERADOR = :telefone_operador, CELULAR_OPERADOR = :celular_operador, RUA_OPERADOR = :rua_operador, BAIRRO_OPERADOR = :bairro_operador, NUMERO_OPERADOR = :numero_operador, CIDADE_OPERADOR = :cidade_operador, CEP_OPERADOR = :cep_operador WHERE ID_OPERADOR = :id_operador";

                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                comandoOracle.Transaction = transaction;
                comandoOracle.CommandText = sql;
                comandoOracle.Parameters.Add(":nome_operador", operador.Nome);
                comandoOracle.Parameters.Add(":sobrenome_operador", operador.Sobrenome);
                comandoOracle.Parameters.Add(":senha_operador", operador.Senha);
                comandoOracle.Parameters.Add(":nivel_operador", operador.Nivel);
                comandoOracle.Parameters.Add(":cpf_operador", operador.Cpf);
                comandoOracle.Parameters.Add(":telefone_operador", operador.Telefone);
                comandoOracle.Parameters.Add(":celular_operador", operador.Celular);
                comandoOracle.Parameters.Add(":rua_operador", operador.Rua);
                comandoOracle.Parameters.Add(":bairro_operador", operador.Bairro);
                comandoOracle.Parameters.Add(":numero_operador", operador.Numero);
                comandoOracle.Parameters.Add(":cidade_operador",operador.Cidade);
                comandoOracle.Parameters.Add(":cep_operador", operador.Cep);
                comandoOracle.Parameters.Add(":id_operador", operador.IdOperador);

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

        public Boolean ativar(Operador operador)
        {
            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();
            try
            {
                sql = "UPDATE TBL_OPERADOR SET STATUS_OPERADOR = 1 WHERE ID_OPERADOR = :id_operador";

                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                comandoOracle.Transaction = transaction;
                comandoOracle.CommandText = sql;
                comandoOracle.Parameters.Add(":id_operador", operador.IdOperador);

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

        public Boolean desativar(Operador operador)
        {
            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();
            try
            {
                sql = "UPDATE TBL_OPERADOR SET STATUS_OPERADOR = 0 WHERE ID_OPERADOR = :id_operador";

                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                comandoOracle.Transaction = transaction;
                comandoOracle.CommandText = sql;
                comandoOracle.Parameters.Add(":id_operador", operador.IdOperador);

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

        public List<Operador> Listar()
        {
            Operador operador;
            List<Operador> listaOperadores = null;

            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();

            try
            {
                sql = "SELECT * FROM TBL_OPERADOR";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                comandoOracle.CommandText = sql;
                OracleDataReader leitorOracle = comandoOracle.ExecuteReader();

                if (leitorOracle.HasRows)
                {


                    listaOperadores = new List<Operador>();

                    while (leitorOracle.Read())
                    {
                        operador = new Operador();
                        
                        operador.IdOperador = leitorOracle.GetInt32(0);
                        operador.Nome = leitorOracle.GetString(1);
                        operador.Sobrenome = leitorOracle.GetString(2);
                        operador.Senha = leitorOracle.GetString(3);
                        operador.Status = leitorOracle.GetInt32(4);
                        operador.Nivel = leitorOracle.GetInt32(5);
                        operador.Cpf = leitorOracle.GetString(6);
                        operador.Telefone = leitorOracle.GetString(7);
                        operador.Celular = leitorOracle.GetString(8);
                        operador.Rua = leitorOracle.GetString(9);
                        operador.Bairro = leitorOracle.GetString(10);
                        operador.Numero = leitorOracle.GetString(11);
                        operador.Cidade = leitorOracle.GetString(12);
                        operador.Cep = leitorOracle.GetString(13);

                        operador.Nome = util.DesnormalizarString(operador.Nome);

                        if (operador.Status == 1)
                        {
                            operador.StatusAux = "Ativo";
                        }
                        else if (operador.Status == 0)
                        {
                            operador.StatusAux = "Inativo";
                        }

                        listaOperadores.Add(operador);
                    }

                }

                leitorOracle.Close();

            }
            catch (OracleException exception)
            {
                MessageBox.Show("Erro ao gravar no banco, " + exception.Message);
                listaOperadores = null;
            }
            connection.Close();
            return listaOperadores;
        }

        public Boolean ValidarIDSenha(Int32 id, string senha)
        {

            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();
            try
            {
                sql = "SELECT ID_OPERADOR,SENHA_OPERADOR FROM TBL_OPERADOR WHERE NIVEL_OPERADOR = 1 AND STATUS_OPERADOR = 1";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                comandoOracle.CommandText = sql;
                OracleDataReader leitorOracle = comandoOracle.ExecuteReader();

                ListaLoginOperador = new List<Operador>();

                while (leitorOracle.Read())
                {
                    operador = new Operador();
                    operador.IdOperador = leitorOracle.GetInt32(0);
                    operador.Senha = leitorOracle.GetString(1);
                    ListaLoginOperador.Add(operador);                      
                }
                foreach (Operador item in ListaLoginOperador)
                {
                    if(item.IdOperador ==  id && item.Senha == senha)
                    {
                        return true;
                    }
                }
                return false;

            }
            catch (OracleException exception)
            {
                MessageBox.Show("Erro ao ler no banco, " + exception.Message);
                return false;
            }
            finally { connection.Close(); }
        }


        public Boolean ValidarCPFOperador(String cpf)
        {

            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();
            
            try
            {
                sql = "SELECT CPF_OPERADOR FROM TBL_OPERADOR";
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

