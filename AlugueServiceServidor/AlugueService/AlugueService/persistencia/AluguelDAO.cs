using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alugueservice.vo;
using Oracle.ManagedDataAccess.Client;
using AlugueService.utilitario;
using System.Windows;

namespace AlugueService.persistencia
{
    class AluguelDAO : IAluguelDAO
    {

        private String sql;
        private OracleConnection connection;
        private ConnectionFactory factory;
        private OracleCommand comandoOracle = null;
        private OracleDataReader leitorOracle = null;
        private List<Operador> ListaLoginOperador;
        private Aluguel aluguel;
        Utilitaria util = new Utilitaria();

        public List<Aluguel> listar()
        {
            Aluguel aluguel;
            List<Aluguel> listaAlugueis = null;

            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();

            try
            {
                sql = "SELECT ID_ALUGUEL, ID_CLIENTE, ID_OPERADOR, ID_CONF, NVL(ID_CUPOM,0), DATA_ALUGUEL, DATA_PREVISTA, NVL(DATA_ENTREGA,'01-01-1999'), STATUS_ALUGUEL, NVL(QUANTIDADE_MULTA,0), VALOR_ALUGUEL, NVL(VALOR_MULTA,0), NVL(VALOR_TOTAL,0) FROM TBL_ALUGUEL WHERE STATUS_ALUGUEL = 1";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                comandoOracle.CommandText = sql;
                OracleDataReader leitorOracle = comandoOracle.ExecuteReader();

                if (leitorOracle.HasRows)
                {


                    listaAlugueis = new List<Aluguel>();

                    while (leitorOracle.Read())
                    {
                        aluguel = new Aluguel();

                        aluguel.IdAluguel = leitorOracle.GetInt32(0);
                        aluguel.IdCliente = leitorOracle.GetInt32(1);
                        aluguel.IdOperador = leitorOracle.GetInt32(2);
                        aluguel.IdConf = leitorOracle.GetInt32(3);
                        aluguel.IdCupom = leitorOracle.GetInt32(4);
                        aluguel.DataAluguel = leitorOracle.GetDateTime(5);
                        aluguel.DataPrevista = leitorOracle.GetDateTime(6);
                        aluguel.DataEntrega = leitorOracle.GetDateTime(7);
                        aluguel.Status = leitorOracle.GetInt32(8);
                        aluguel.QtMulta = leitorOracle.GetInt32(9);
                        aluguel.ValorAluguel = leitorOracle.GetFloat(10);
                        aluguel.ValorMulta = leitorOracle.GetFloat(11);
                        aluguel.ValorTotal = leitorOracle.GetFloat(12);
                        if(aluguel.Status == 1){
                            aluguel.StatusAux = "Ativo";
                        }                           

                        listaAlugueis.Add(aluguel);
                    }

                }

                leitorOracle.Close();

            }
            catch (OracleException exception)
            {
                MessageBox.Show("Erro ao gravar no banco, " + exception.Message);
                listaAlugueis = null;
            }
            connection.Close();
            return listaAlugueis;
        }

        public List<Aluguel> listarHistorico()
        {
            Aluguel aluguel;
            List<Aluguel> listaHistoricoAlugueis = null;

            connection = new OracleConnection();
            factory = new ConnectionFactory();
            comandoOracle = new OracleCommand();

            try
            {
                sql = "SELECT ID_ALUGUEL, ID_CLIENTE, ID_OPERADOR, ID_CONF, NVL(ID_CUPOM,0), DATA_ALUGUEL, DATA_PREVISTA, NVL(DATA_ENTREGA,'01-01-1999'), STATUS_ALUGUEL, NVL(QUANTIDADE_MULTA,0), VALOR_ALUGUEL, NVL(VALOR_MULTA,0), NVL(VALOR_TOTAL,0) FROM TBL_ALUGUEL WHERE STATUS_ALUGUEL = 0 OR STATUS_ALUGUEL = 2";
                connection = factory.getConnection();
                comandoOracle.Connection = connection;
                comandoOracle.CommandText = sql;
                OracleDataReader leitorOracle = comandoOracle.ExecuteReader();

                if (leitorOracle.HasRows)
                {


                    listaHistoricoAlugueis = new List<Aluguel>();

                    while (leitorOracle.Read())
                    {
                        aluguel = new Aluguel();

                        aluguel.IdAluguel = leitorOracle.GetInt32(0);
                        aluguel.IdCliente = leitorOracle.GetInt32(1);
                        aluguel.IdOperador = leitorOracle.GetInt32(2);
                        aluguel.IdConf = leitorOracle.GetInt32(3);
                        aluguel.IdCupom = leitorOracle.GetInt32(4);
                        aluguel.DataAluguel = leitorOracle.GetDateTime(5);
                        aluguel.DataPrevista = leitorOracle.GetDateTime(6);
                        aluguel.DataEntrega = leitorOracle.GetDateTime(7);
                        aluguel.Status = leitorOracle.GetInt32(8);
                        aluguel.QtMulta = leitorOracle.GetInt32(9);
                        aluguel.ValorAluguel = leitorOracle.GetFloat(10);
                        aluguel.ValorMulta = leitorOracle.GetFloat(11);
                        aluguel.ValorTotal = leitorOracle.GetFloat(12);

                        if (aluguel.Status == 2)
                        {
                            aluguel.StatusAux = "Finalizado";
                        }
                        else if (aluguel.Status == 0)
                        {
                            aluguel.StatusAux = "Cancelado";
                        }

                        listaHistoricoAlugueis.Add(aluguel);
                    }

                }

                leitorOracle.Close();

            }
            catch (OracleException exception)
            {
                MessageBox.Show("Erro ao gravar no banco, " + exception.Message);
                listaHistoricoAlugueis = null;
            }
            connection.Close();
            return listaHistoricoAlugueis;
        }
    }
}
