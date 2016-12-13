using alugueservice.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AlugueService.persistencia
{
    class ConfiguracaoPersistencia : IConfiguracaoDAO
    {
        ConfiguracaoDAO configuracaoDAO;

        public ConfiguracaoPersistencia()
        {
            configuracaoDAO = new ConfiguracaoDAO();
        }

        public Boolean inserir(Configuracao configuracao)
        {
            
            if (configuracaoDAO.inserir(configuracao))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Configuracao Listar()
        {
            return configuracaoDAO.Listar();
            
        }
    }
}
