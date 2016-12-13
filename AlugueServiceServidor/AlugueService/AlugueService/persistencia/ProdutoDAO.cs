using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alugueservice.vo;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using AlugueService.utilitario;
using System.Data.SqlClient;
using System.Windows;
using System.Data;


namespace AlugueService.persistencia
{
    class ProdutoDAO : IProdutoDAO
    {
        private String sql;
        private OracleConnection connection;
        private ConnectionFactory factory;
        private OracleCommand comandoOracle = null;
        private OracleDataReader leitorOracle = null;
        OracleTransaction transaction = null;


        public Boolean inserir(Produto produto)
        {
            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();


            try
            {
                
                sql = "INSERT INTO TBL_PRODUTO(ID_PRODUTO,VALOR_PRODUTO,STATUS_PRODUTO,NOME_PRODUTO,DESCRICAO_PRODUTO,TAMANHO_PRODUTO,GENERO_PRODUTO) VALUES (ID_PRODUTO.NEXTVAL,:valor_produto, 1, :nome_produto, :descricao_produto, :tamanho_produto, :genero_produto)";
                
            connection = factory.getConnection();
            comandoOracle.Connection = connection;
            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
            comandoOracle.Transaction = transaction;
            comandoOracle.CommandText = sql;
            comandoOracle.Parameters.Add(":valor_produto", produto.Valor);
            comandoOracle.Parameters.Add(":nome_produto", produto.Nome);
            comandoOracle.Parameters.Add(":descricao_produto", produto.Descricao);
            comandoOracle.Parameters.Add(":tamanho_produto", produto.Tamanho);
            comandoOracle.Parameters.Add(":genero_produto", produto.Genero);
            
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

        internal List<Produto> listarProdutoAluguel(int idAluguel)
        {
            Produto produto;
            List<Produto> listaProdutosAluguel = null;

            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();

            try
            {
                sql = "SELECT ID_PRODUTO, VALOR_PRODUTO_ALUGUEL, NOME_PRODUTO_ALUGUEL FROM TBL_PRODUTOS_ALUGUEL WHERE ID_ALUGUEL = :id_aluguel";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                comandoOracle.CommandText = sql;
                comandoOracle.Parameters.Add(":id_aluguel", idAluguel);
                OracleDataReader leitorOracle = comandoOracle.ExecuteReader();

                if (leitorOracle.HasRows)
                {


                    listaProdutosAluguel = new List<Produto>();

                    while (leitorOracle.Read())
                    {
                        produto = new Produto();
                        produto.IdProduto = leitorOracle.GetInt32(0);
                        produto.Valor = leitorOracle.GetFloat(1);
                        produto.Nome = leitorOracle.GetString(2);
                        listaProdutosAluguel.Add(produto);
                    }

                }

                leitorOracle.Close();

            }
            catch (OracleException exception)
            {
                MessageBox.Show("Erro ao ler no banco, " + exception.Message);
                listaProdutosAluguel = null;
            }
            connection.Close();
            return listaProdutosAluguel;


        }

        public List<Produto> listar()
        {
            Produto produto;
            List<Produto> listaProdutos = null;

            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();

            try
            {
                sql = "SELECT * FROM TBL_PRODUTO";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                comandoOracle.CommandText = sql;
                OracleDataReader leitorOracle = comandoOracle.ExecuteReader();

                if (leitorOracle.HasRows)
                {


                    listaProdutos = new List<Produto>();

                    while (leitorOracle.Read())
                    {
                        produto = new Produto();
                        produto.IdProduto = leitorOracle.GetInt32(0);
                        produto.Valor = leitorOracle.GetFloat(1);
                        produto.Status = leitorOracle.GetInt32(2);
                        produto.Nome = leitorOracle.GetString(3);
                        produto.Descricao = leitorOracle.GetString(4);
                        produto.Tamanho = leitorOracle.GetString(5);
                        produto.Genero = leitorOracle.GetString(6);

                        if (produto.Status == 1)
                        {
                            produto.StatusAux = "Ativo";
                        }else if (produto.Status == 2)
                        {
                            produto.StatusAux = "Alugado";
                        }else if (produto.Status == 0)
                        {
                            produto.StatusAux = "Inativo";
                        }

                        listaProdutos.Add(produto);
                    }

                }

                leitorOracle.Close();

            }
            catch (OracleException exception)
            {
                MessageBox.Show("Erro ao ler no banco, " + exception.Message);
                listaProdutos = null;
            }
            connection.Close();
            return listaProdutos;


        }

        public Boolean editar(Produto produto)
        {
            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();
            try
            {
                sql = "UPDATE TBL_PRODUTO SET VALOR_PRODUTO = :valor_produto, NOME_PRODUTO = :nome_produto, DESCRICAO_PRODUTO = :descricao_produto, TAMANHO_PRODUTO = :tamanho_produto, GENERO_PRODUTO = :genero_produto WHERE ID_PRODUTO = :id_produto";
                
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                comandoOracle.Transaction = transaction;
                comandoOracle.CommandText = sql;
                comandoOracle.Parameters.Add(":valor_produto", produto.Valor);
                comandoOracle.Parameters.Add(":nome_produto", produto.Nome);
                comandoOracle.Parameters.Add(":descricao_produto", produto.Descricao);
                comandoOracle.Parameters.Add(":tamanho_produto", produto.Tamanho);
                comandoOracle.Parameters.Add(":genero_produto", produto.Genero);
                comandoOracle.Parameters.Add(":id_produto", produto.IdProduto);
                            
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


        public Boolean ativar(Produto produto)
        {
            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();
            try
            {
                sql = "UPDATE TBL_PRODUTO SET STATUS_PRODUTO = 1 WHERE ID_PRODUTO = :id_produto";

                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                comandoOracle.Transaction = transaction;
                comandoOracle.CommandText = sql;
                comandoOracle.Parameters.Add(":id_produto", produto.IdProduto);

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

        public Boolean desativar(Produto produto)
        {
            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();
            try
            {
                sql = "UPDATE TBL_PRODUTO SET STATUS_PRODUTO = 0 WHERE ID_PRODUTO = :id_produto";

                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                comandoOracle.Transaction = transaction;
                comandoOracle.CommandText = sql;
                comandoOracle.Parameters.Add(":id_produto", produto.IdProduto);

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

        public List<Produto> Pesquisar(int idProduto)
        {
            
            List<Produto> listaProdutos = null;
            Produto produto;

            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();

            try
            {
                sql = "SELECT * FROM TBL_PRODUTO WHERE ID_PRODUTO = :id_produto";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                comandoOracle.CommandText = sql;
                comandoOracle.Parameters.Add(":id_produto", idProduto);
                OracleDataReader leitorOracle = comandoOracle.ExecuteReader();

                if (leitorOracle.HasRows)
                {


                    listaProdutos = new List<Produto>();

                    while (leitorOracle.Read())
                    {
                        produto = new Produto();
                        produto.IdProduto = leitorOracle.GetInt32(0);
                        produto.Valor = leitorOracle.GetFloat(1);
                        produto.Status = leitorOracle.GetInt32(2);
                        produto.Nome = leitorOracle.GetString(3);
                        produto.Descricao = leitorOracle.GetString(4);
                        produto.Tamanho = leitorOracle.GetString(5);
                        produto.Genero = leitorOracle.GetString(6);

                        if (produto.Status == 1)
                        {
                            produto.StatusAux = "Ativo";
                        }
                        else if (produto.Status == 2)
                        {
                            produto.StatusAux = "Alugado";
                        }
                        else if (produto.Status == 0)
                        {
                            produto.StatusAux = "Inativo";
                        }

                        listaProdutos.Add(produto);
                    }

                }

                leitorOracle.Close();

            }
            catch (OracleException exception)
            {
                MessageBox.Show("Erro ao pesquisar no banco, " + exception.Message);
                listaProdutos = null;
            }
            connection.Close();
            return listaProdutos;
        }

        public List<Produto> listarHistorico()
        {
            Produto produto;
            List<Produto> listaProdutosHistorico = null;

            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();

            try
            {
                sql = "SELECT * FROM TBL_PRODUTO_ANTIGO";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                comandoOracle.CommandText = sql;
                OracleDataReader leitorOracle = comandoOracle.ExecuteReader();

                if (leitorOracle.HasRows)
                {


                    listaProdutosHistorico = new List<Produto>();

                    while (leitorOracle.Read())
                    {
                        produto = new Produto();
                        produto.IdProduto = leitorOracle.GetInt32(0);
                        produto.Valor = leitorOracle.GetFloat(1);
                        produto.Status = leitorOracle.GetInt32(2);
                        produto.Nome = leitorOracle.GetString(3);
                        produto.Descricao = leitorOracle.GetString(4);
                        produto.Tamanho = leitorOracle.GetString(5);
                        produto.Genero = leitorOracle.GetString(6);
                        produto.Data = leitorOracle.GetString(7);

                        if (produto.Status == 1)
                        {
                            produto.StatusAux = "Ativo";
                        }
                        else if (produto.Status == 2)
                        {
                            produto.StatusAux = "Alugado";
                        }
                        else if (produto.Status == 0)
                        {
                            produto.StatusAux = "Inativo";
                        }

                        listaProdutosHistorico.Add(produto);
                    }

                }

                leitorOracle.Close();

            }
            catch (OracleException exception)
            {
                MessageBox.Show("Erro ao ler no banco, " + exception.Message);
                listaProdutosHistorico = null;
            }
            connection.Close();
            return listaProdutosHistorico;
        }
    }

    }

