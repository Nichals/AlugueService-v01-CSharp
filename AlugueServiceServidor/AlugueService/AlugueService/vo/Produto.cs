
using System;

namespace alugueservice.vo
{
	public class Produto
	{
		private int idProduto;
		private String nome;
		private String descricao;
		private float valor;
		private int status;
		private String tamanho;
		private String genero;
        private String data;
        private String statusAux;

         

        //Metodo construtor

        public Produto()
        {

        }
        public int IdProduto
        {
            get
            {
                return idProduto;
            }

            set
            {
                idProduto = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                descricao = value;
            }
        }
      
        public float Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }

        public Int32 Status
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

        public string Tamanho
        {
            get
            {
                return tamanho;
            }

            set
            {
                tamanho = value;
            }
        }

        public string Genero
        {
            get
            {
                return genero;
            }

            set
            {
                genero = value;
            }
        }

        public String Data
        {
            get { return data; }
            set { data = value; }
        }

        public String StatusAux
        {
            get { return statusAux; }
            set { statusAux = value; }
        }

    }

}

