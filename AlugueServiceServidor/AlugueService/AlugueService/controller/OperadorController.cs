using alugueservice.vo;
using AlugueService.model;
using AlugueService.persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueService.controller
{
    class OperadorController
    {

        OperadorModel operadorModel;

        public OperadorController()
        {
            operadorModel = new OperadorModel();
        }

        public Boolean inserir(Operador operador)
        {
            return operadorModel.inserir(operador);
        }

        public Boolean ValidarUsuario(Int32 id, String senha)
        {
            return operadorModel.ValidarIDSenha(id, senha);
        }

        public List<Operador> Listar()
        {
            return operadorModel.Listar();
        }

        public Boolean ativar(Operador operador)
        {
            return operadorModel.ativar(operador);
        }

        public Boolean desativar(Operador operador)
        {
            return operadorModel.desativar(operador);
        }

        public Boolean editar(Operador operador)
        {
            return operadorModel.editar(operador);
        }

        public List<Operador> pesquisar(string nomePesquisado)
        {
            return operadorModel.pesquisar(nomePesquisado);
        }

        internal Boolean ValidarCPFOperador(string cpf)
        {
            return operadorModel.ValidarCPFOperador(cpf);
        }
    }
}
