using alugueservice.vo;
using AlugueService.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueService.controller
{
    class ProdutoController
    {
        ProdutoModel produtoModel;
        public ProdutoController()
        {
            produtoModel = new ProdutoModel();
        }

        public Boolean inserir(Produto produto)
        {
            
            return produtoModel.inserir(produto);
        }

        public List<Produto> Listar()
        {
            return produtoModel.listar();
        }

        public Boolean editar(Produto produto)
        {
            return produtoModel.editar(produto);
        }

        public Boolean ativar(Produto produto)
        {
            return produtoModel.ativar(produto);
        }

        public Boolean desativar(Produto produto)
        {
            return produtoModel.desativar(produto);
        }

        public List<Produto> Pesquisar(int idProduto)
        {
            return produtoModel.Pesquisar(idProduto);
        }

        public List<Produto> ListarHistorico()
        {
            return produtoModel.listarHistorico();
        }

        public List<Produto> ListarProdutoAluguel(int idAluguel)
        {
            return produtoModel.listarProdutoAluguel(idAluguel);
        }
    }
}
