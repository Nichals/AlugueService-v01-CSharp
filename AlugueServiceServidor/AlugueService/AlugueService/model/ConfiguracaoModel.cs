using alugueservice.vo;
using AlugueService.persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueService.model
{
    class ConfiguracaoModel
    {
        ConfiguracaoPersistencia configuracaoPersistencia;

        public ConfiguracaoModel()
        {
            configuracaoPersistencia = new ConfiguracaoPersistencia();
        }

        public Boolean Inserir(Configuracao configuracao)
        {
           return configuracaoPersistencia.inserir(configuracao);

        }

        public Configuracao Listar()
        {
            return configuracaoPersistencia.Listar();
        }
    }
}
