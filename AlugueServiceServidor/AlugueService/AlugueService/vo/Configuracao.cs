using System;

namespace alugueservice.vo
{
	public class Configuracao
	{
		private float valorMulta;
        private float valorCupom;

        public Configuracao()
        {

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

        public float ValorCupom
        {
            get
            {
                return valorCupom;
            }

            set
            {
                valorCupom = value;
            }
        }
    }

}

