using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alugueservice.vo;
using AlugueService.persistencia;

namespace AlugueService.model
{
    class ClienteModel
    {

        ClientePersistencia clientePersistencia;

        public ClienteModel()
        {
            clientePersistencia = new ClientePersistencia();
        }

        public List<Cliente> listar()
        {
            return clientePersistencia.listar();
        }

        public List<Cliente> pesquisar(string nomePesquisado)
        {
            return clientePersistencia.pesquisar(nomePesquisado);
        }

        public Boolean ativar(Cliente cliente)
        {
            return clientePersistencia.ativar(cliente);
        }

        public Boolean desativar(Cliente cliente)
        {
            return clientePersistencia.desativar(cliente);
        }

        internal bool ValidarCPFCliente(string cpf)
        {
            return clientePersistencia.ValidarCPFCliente(cpf);
        }
    }
}
