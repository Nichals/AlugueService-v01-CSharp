using alugueservice.vo;
using AlugueService.persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueService.model
{
    class OperadorModel
    {
        OperadorPersistencia operadorPersistencia;

        public OperadorModel()
        {
            operadorPersistencia = new OperadorPersistencia();
        }

        public Boolean inserir(Operador operador)
        {
            return operadorPersistencia.inserir(operador);
        }

        public List<Operador> Listar()
        {
            return operadorPersistencia.Listar();
        }

        public Boolean ativar(Operador operador)
        {
            return operadorPersistencia.ativar(operador);
        }

        public Boolean ValidarIDSenha(int id, string senha)
        {
            return operadorPersistencia.ValidarIDSenha(id, senha);
        }

        public Boolean desativar(Operador operador)
        {
            return operadorPersistencia.desativar(operador);
        }

        public Boolean editar(Operador operador)
        {
            return operadorPersistencia.editar(operador);
        }

        public List<Operador> pesquisar(string nomePesquisado)
        {
            return operadorPersistencia.pesquisar(nomePesquisado);
        }

        internal Boolean ValidarCPFOperador(string cpf)
        {
            return operadorPersistencia.ValidarCPFOperador(cpf);
        }
    }
}
