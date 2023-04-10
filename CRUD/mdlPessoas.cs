using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
	public class mdlPessoas
	{
		private int ID { get; set; }
		private string nome { get; set; }
		private string idade { get; set; }

		private static List<mdlPessoas> pessoas = new List<mdlPessoas>();
		public mdlPessoas(int id, string nome, string idade)
		{
			this.ID = id;
			this.nome = nome;
			this.idade = idade;
		}
        public int getID()
        {
			return ID;
        }
        public string getNome()
		{
			return nome;
		}
        public string setNome(string nome)
        {
            return this.nome = nome;
        }
        public string getIdade()
		{
			return idade;
		}
        public string setIdade(string idade)
        {
            return this.idade = idade;
        }
        public static List<mdlPessoas> GetList()
		{
			return pessoas;
		}
		public static List<mdlPessoas> SetList(mdlPessoas param)
		{
			pessoas.Add(new mdlPessoas(param.getID(), param.getNome(), param.getIdade()));
			return pessoas;
		}
	}
}
