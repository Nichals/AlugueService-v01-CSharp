using System;
using alugueservice.vo;


namespace alugueservice.vo
{
	public class Operador
	{
        private int idOperador;
        private String nome;
        private String sobrenome;
        private String senha;
        private int status;
        private int nivel;
        private String cpf;
        private String telefone;
        private String celular;
        private String rua;
        private String numero;
        private String cidade;
        private String cep;
        private String bairro;
        private String statusAux;




        //Metodo construtor
        public Operador()
        {

        }

        public int IdOperador
        {
            get { return idOperador; }
            set { idOperador = value; }
        }

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public String Sobrenome
        {
            get { return sobrenome; }
            set { sobrenome = value; }
        }

        public String Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        public String Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public String Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        public String Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public String Rua
        {
            get { return rua; }
            set { rua = value; }
        }

        public String Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public String Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public String Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        public String Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        public String StatusAux
        {
            get { return statusAux; }
            set { statusAux = value; }
        }
    }

}

