using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alugueservice.vo;
using AlugueService.model;

namespace AlugueService.controller
{
    class ClienteController
    {

        ClienteModel clienteModel;
        
        public ClienteController()
        {
            clienteModel = new ClienteModel();
        }

        public List<Cliente> listar()
        {
            return clienteModel.listar();
        }

        public List<Cliente> pesquisar(string nomePesquisado)
        {
            return clienteModel.pesquisar(nomePesquisado);
        }

        public Boolean ativar(Cliente cliente)
        {
            return clienteModel.ativar(cliente);
        }

        public Boolean desativar(Cliente cliente)
        {
            return clienteModel.desativar(cliente);
        }

        internal Boolean ValidarCPFCliente(string cpf)
        {
            return clienteModel.ValidarCPFCliente(cpf);
        }
    }
}
