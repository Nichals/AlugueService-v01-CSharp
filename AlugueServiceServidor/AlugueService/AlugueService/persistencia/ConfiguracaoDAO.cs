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
    class ConfiguracaoDAO : IConfiguracaoDAO
    {
        private String sql;
        private OracleConnection connection;
        private ConnectionFactory factory;
        private OracleCommand comandoOracle = null;
        private OracleDataReader leitorOracle = null;
        OracleTransaction transaction = null;

        public Boolean inserir(Configuracao configuracao)
        {
            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();
            try
            {
                sql = "INSERT INTO TBL_CONFIGURACOES(ID_CONF,MULTA_VALOR,CUPOM_VALOR) VALUES (ID_CONF.NEXTVAL,:valor_multa,:valor_cupom)";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                comandoOracle.Transaction = transaction;
                comandoOracle.CommandText = sql;
                comandoOracle.Parameters.Add(":valor_multa", configuracao.ValorMulta);
                comandoOracle.Parameters.Add(":valor_cupom", configuracao.ValorCupom);

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

        public Configuracao Listar()
        {
            Configuracao configuracao;
            
            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();

            try
            {
                sql = "SELECT CUPOM_VALOR, MULTA_VALOR FROM TBL_CONFIGURACOES WHERE ID_CONF = (SELECT MAX(ID_CONF) from TBL_CONFIGURACOES)";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                comandoOracle.CommandText = sql;
                OracleDataReader leitorOracle = comandoOracle.ExecuteReader();

                configuracao = new Configuracao();

                    while (leitorOracle.Read())
                    {
                        configuracao = new Configuracao();
                        configuracao.ValorCupom = leitorOracle.GetFloat(0);
                        configuracao.ValorMulta = leitorOracle.GetFloat(1);
                        
                    }

                      leitorOracle.Close();
                

            }
            catch (OracleException exception)
            {
                MessageBox.Show("Erro ao gravar no banco, " + exception.Message);
                configuracao = null;
            }
            connection.Close();
                  return configuracao;

        }
    }
}
