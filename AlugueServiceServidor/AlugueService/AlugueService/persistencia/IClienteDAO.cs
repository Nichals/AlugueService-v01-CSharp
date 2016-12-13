using alugueservice.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueService.persistencia
{
    interface IClienteDAO
    {
        List<Cliente> listar();
        List<Cliente> pesquisar(string nomePesquisado);
        Boolean ativar(Cliente cliente);
        Boolean desativar(Cliente cliente);
    }
}
