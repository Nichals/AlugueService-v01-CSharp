using System;

namespace alugueservice.vo
{
	public class Aluguel
	{
        Int32 idAluguel;
        Int32 idCliente;
        Int32 idOperador;
        Int32 idConf;
        Int32 idCupom;
        DateTime dataAluguel;
        DateTime dataPrevista;
        DateTime dataEntrega;
        Int32 status;
        Int32 qtMulta;
        float valorAluguel;
        float valorMulta;
        float valorTotal;
        String statusAux;


        public int IdAluguel
        {
            get
            {
                return idAluguel;
            }

            set
            {
                idAluguel = value;
            }
        }

        public int IdCliente
        {
            get
            {
                return idCliente;
            }

            set
            {
                idCliente = value;
            }
        }

        public int IdOperador
        {
            get
            {
                return idOperador;
            }

            set
            {
                idOperador = value;
            }
        }

        public int IdConf
        {
            get
            {
                return idConf;
            }

            set
            {
                idConf = value;
            }
        }

        public int IdCupom
        {
            get
            {
                return idCupom;
            }

            set
            {
                idCupom = value;
            }
        }

        public DateTime DataAluguel
        {
            get
            {
                return dataAluguel;
            }

            set
            {
                dataAluguel = value;
            }
        }

        public DateTime DataPrevista
        {
            get
            {
                return dataPrevista;
            }

            set
            {
                dataPrevista = value;
            }
        }

        public DateTime DataEntrega
        {
            get
            {
                return dataEntrega;
            }

            set
            {
                dataEntrega = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int QtMulta
        {
            get
            {
                return qtMulta;
            }

            set
            {
                qtMulta = value;
            }
        }

        public float ValorAluguel
        {
            get
            {
                return valorAluguel;
            }

            set
            {
                valorAluguel = value;
            }
        }

        public float ValorMulta
        {
            get
            {
                return valorMulta;
            }

            set
            {
                valorMulta = value;
            }
        }

        public float ValorTotal
        {
            get
            {
                return valorTotal;
            }

            set
            {
                valorTotal = value;
            }
        }

        public String StatusAux
        {
            get { return statusAux; }
            set { statusAux = value; }
        }
    }

}

