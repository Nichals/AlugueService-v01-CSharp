using alugueservice.vo;
using AlugueService.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueService.controller
{
    class ConfiguracaoController
    {
        ConfiguracaoModel configuracaoModel;

        public ConfiguracaoController()
        {
            configuracaoModel = new ConfiguracaoModel();
        }

        public Boolean inserir(Configuracao configuracao)
        {
            return configuracaoModel.Inserir(configuracao);
        }

        public Configuracao Listar()
        {
            return configuracaoModel.Listar();
        }
    }
}
