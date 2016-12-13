using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows;

namespace AlugueService.utilitario
{
    class ConnectionFactory
    {
       public ConnectionFactory()
        {
            openConnection();
        }


        private const String STRING_CONEXAO = "Data Source=localhost;user id=aluno;password=aluno";
        private OracleConnection conexaoOracle = null;



        public bool openConnection()
        {
            conexaoOracle = new OracleConnection(STRING_CONEXAO);

            try
            {
                if (conexaoOracle.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    conexaoOracle.Open();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.StackTrace);
                return false;
            }

           
           
        }
        public bool closeConnection()
        {
            try
            {
                if (conexaoOracle.State == System.Data.ConnectionState.Open)
                {
                    conexaoOracle.Close();
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro: " + e.StackTrace);
                return false;
            }
          
        }
        public OracleConnection getConnection()
        {
            if(conexaoOracle == null)
            {
                new ConnectionFactory();
            }
            return conexaoOracle;
        }
    }
}
