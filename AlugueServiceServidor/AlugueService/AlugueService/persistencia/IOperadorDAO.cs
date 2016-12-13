using alugueservice.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueService.persistencia
{
    interface IOperadorDAO
    {
        Boolean inserir(Operador operador);
        List<Operador> pesquisar(string nomePesquisado);
        Boolean editar(Operador operador);
        Boolean ativar(Operador operador);
        Boolean desativar(Operador operador);
        List<Operador> Listar();
        
    }
}
