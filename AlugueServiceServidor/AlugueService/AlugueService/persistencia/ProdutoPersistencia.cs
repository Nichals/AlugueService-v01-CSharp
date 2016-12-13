using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alugueservice.vo;

namespace AlugueService.persistencia
{
    class ProdutoPersistencia : IProdutoDAO
    {
        ProdutoDAO produtoDAO;

        public ProdutoPersistencia()
        {
            produtoDAO = new ProdutoDAO();
        }

        public Boolean inserir(Produto produto)
        {
            

            if(produtoDAO.inserir(produto))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Produto> listar()
        {
            return produtoDAO.listar();
        }

        public Boolean editar(Produto produto)
        {
            if (produtoDAO.editar(produto))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean ativar(Produto produto)
        {
            if (produtoDAO.ativar(produto))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean desativar(Produto produto)
        {
            if (produtoDAO.desativar(produto))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Produto> listarProdutoAluguel(int idAluguel)
        {
            return produtoDAO.listarProdutoAluguel(idAluguel);
        }

        public List<Produto> Pesquisar(int idProduto)
        {
            return produtoDAO.Pesquisar(idProduto);
        }

        public List<Produto> listarHistorico()
        {
            return produtoDAO.listarHistorico();
        }
    }
}
