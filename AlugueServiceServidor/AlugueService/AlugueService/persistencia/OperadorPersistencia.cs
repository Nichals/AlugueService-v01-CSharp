using alugueservice.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueService.persistencia
{
    class OperadorPersistencia : IOperadorDAO
    {
        OperadorDAO operadorDAO;

        public OperadorPersistencia()
        {
            operadorDAO = new OperadorDAO();
        }

        public Boolean inserir(Operador operador)
        {
            
            if (operadorDAO.inserir(operador))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Operador> Listar()
        {
            return operadorDAO.Listar();
        }

        public Boolean ativar(Operador operador)
        {
            if (operadorDAO.ativar(operador))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean ValidarIDSenha(int id, string senha)
        {
            if (operadorDAO.ValidarIDSenha(id, senha))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean desativar(Operador operador)
        {
            if (operadorDAO.desativar(operador))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Operador> pesquisar(string nomePesquisado)
        {
            return operadorDAO.pesquisar(nomePesquisado);
        }

        internal bool ValidarCPFOperador(string cpf)
        {
            return operadorDAO.ValidarCPFOperador(cpf);
        }

        public Boolean editar(Operador operador)
        {
            if (operadorDAO.editar(operador))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
