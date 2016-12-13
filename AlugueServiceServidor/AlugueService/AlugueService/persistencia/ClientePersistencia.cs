using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alugueservice.vo;

namespace AlugueService.persistencia
{
    class ClientePersistencia : IClienteDAO
    {
        ClienteDAO clienteDAO;

        public ClientePersistencia()
        {
            clienteDAO = new ClienteDAO();
        }


        public List<Cliente> listar()
        {
            return clienteDAO.listar();
        }

        public List<Cliente> pesquisar(string nomePesquisado)
        {
            return clienteDAO.pesquisar(nomePesquisado);
        }

        public Boolean ativar(Cliente cliente)
        {
            if (clienteDAO.ativar(cliente))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean desativar(Cliente cliente)
        {
            if (clienteDAO.desativar(cliente))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool ValidarCPFCliente(string cpf)
        {
            return clienteDAO.ValidarCPFCliente(cpf);
        }
    }
}
