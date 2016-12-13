using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alugueservice.vo;

namespace AlugueService.persistencia
{
    class AluguelPersistencia : IAluguelDAO
    {
        AluguelDAO aluguelDAO;

        public AluguelPersistencia()
        {
            aluguelDAO = new AluguelDAO();
        }


        public List<Aluguel> listar()
        {
            return aluguelDAO.listar();
        }

        public List<Aluguel> listarHistorico()
        {
            return aluguelDAO.listarHistorico();
        }
    }
}
