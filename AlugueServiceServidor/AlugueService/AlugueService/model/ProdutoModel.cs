using alugueservice.vo;
using AlugueService.persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueService.model
{
    class ProdutoModel
    {
        public ProdutoModel()
        {
            produtoPersistencia = new ProdutoPersistencia();
        }

        ProdutoPersistencia produtoPersistencia;
        public Boolean inserir(Produto produto)
        {
            return produtoPersistencia.inserir(produto);
        }

        public List<Produto> listar()
        {
            return produtoPersistencia.listar();
        }

        public Boolean editar(Produto produto)
        {
            return produtoPersistencia.editar(produto);
        }

        public Boolean ativar(Produto produto)
        {
            return produtoPersistencia.ativar(produto);
        }

        public Boolean desativar(Produto produto)
        {
            return produtoPersistencia.desativar(produto);
        }

        public List<Produto> Pesquisar(int idProduto)
        {
            return produtoPersistencia.Pesquisar(idProduto);
        }

        public List<Produto> listarHistorico()
        {
            return produtoPersistencia.listarHistorico();
        }

        public List<Produto> listarProdutoAluguel(int idAluguel)
        {
            return produtoPersistencia.listarProdutoAluguel(idAluguel);
        }
    }
}
