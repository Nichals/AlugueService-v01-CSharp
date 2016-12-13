using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alugueservice.vo;
using AlugueService.model;

namespace AlugueService.controller
{
    class AluguelController
    {

        AluguelModel aluguelModel;

        public AluguelController()
        {
            aluguelModel = new AluguelModel();
        }

        public List<Aluguel> listar()
        {
            return aluguelModel.listar();
        }

        public List<Aluguel> listarHistorico()
        {
            return aluguelModel.listarHistorico();
        }
    }
}
