using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alugueservice.vo;
using System.Data;

namespace AlugueService.persistencia
{
    interface IProdutoDAO
    {
        Boolean inserir(Produto produto);
        List<Produto> listar();
        Boolean editar(Produto produto);
        Boolean ativar(Produto produto);
        Boolean desativar(Produto produto);
        List<Produto> Pesquisar(int idProduto);
        List<Produto> listarHistorico();

    }
}
