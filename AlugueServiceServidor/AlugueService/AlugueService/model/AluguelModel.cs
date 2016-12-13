using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alugueservice.vo;
using AlugueService.persistencia;

namespace AlugueService.model
{
    class AluguelModel
    {
        AluguelPersistencia aluguelPersistencia;

        public AluguelModel()
        {
            aluguelPersistencia = new AluguelPersistencia();
        }

        public List<Aluguel> listar()
        {
            return aluguelPersistencia.listar();
        }

        public List<Aluguel> listarHistorico()
        {
            return aluguelPersistencia.listarHistorico();
        }
    }
}
