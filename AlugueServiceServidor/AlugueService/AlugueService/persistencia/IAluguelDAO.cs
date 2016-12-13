using alugueservice.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueService.persistencia
{
    interface IAluguelDAO
    {
        List<Aluguel> listar();
        List<Aluguel> listarHistorico();
    }
}
