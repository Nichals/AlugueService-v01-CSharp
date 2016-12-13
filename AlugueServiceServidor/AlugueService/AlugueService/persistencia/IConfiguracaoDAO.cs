using alugueservice.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueService.persistencia
{
    interface IConfiguracaoDAO
    {
        Boolean inserir(Configuracao configuracao);
        Configuracao Listar();
    }
}
