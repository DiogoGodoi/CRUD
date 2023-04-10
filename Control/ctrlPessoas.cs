using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace Control
{
	public class ctrlPessoas
	{
		private static DataTable dt;
		private static List<mdlPessoas> listPessoa = new List<mdlPessoas>();
        public static Object Cadastrar(DataGridView dtGrid, mdlPessoas pessoas)
        {
            listPessoa.Add(new mdlPessoas(pessoas.getID(), pessoas.getNome(), pessoas.getIdade()));
            if (listPessoa.Count == 0)
            {
                dt = new DataTable();
                dt.Columns.Add("Cod", typeof(string));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Idade", typeof(string));
                dt.Rows.Add("Sem dados", "Sem dados", "Sem dados");
                return dtGrid.DataSource = dt;
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("Cod", typeof(string));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Idade", typeof(string));
                foreach (var item in listPessoa)
                {
                    dt.Rows.Add(item.getID(), item.getNome(), item.getIdade());
                }
                return dtGrid.DataSource = dt;
            }
        }
		public static Object ObterPessoas(DataGridView dtGrid)
		{
            if(listPessoa.Count != 0)
            {
                dt = new DataTable();
                dt.Columns.Add("Cod", typeof(string));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Idade", typeof(string));

                foreach (var item in listPessoa)
                {
                    dt.Rows.Add(item.getID(), item.getNome(), item.getIdade());
                }
                return dtGrid.DataSource = dt;
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Idade", typeof(string));
                dt.Rows.Add("Sem dados", "Sem dados", "Sem dados");
                return dtGrid.DataSource = dt;
            }
        }
		public static Object BuscaPorID(int id, DataGridView dtGrid)
		{
            var filtro = listPessoa.Where(i => i.getID() == id).ToList();
            if (filtro.Count > 0)
            {
                dt = new DataTable();
                dt.Columns.Add("Cod", typeof(string));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Idade", typeof(string));
                foreach (var item in filtro)
                {
                    dt.Rows.Add(item.getID(), item.getNome(), item.getIdade());
                }
                return dtGrid.DataSource = dt;
            }
            else
            {
				dt = new DataTable();
				dt.Columns.Add("Cod", typeof(string));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Idade", typeof(string));
				dt.Rows.Add("Sem dados", "Sem dados", "Sem dados");
                return dtGrid.DataSource = dt;
            }
        }
        public static Object Alterar(int id, mdlPessoas pessoas, DataGridView dtGrid)
        {
            var filtro = listPessoa.Where(i => i.getID() == id).ToList();
            if(filtro.Count > 0)
            {
                dt = new DataTable();
                dt.Columns.Add("Cod", typeof(string));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Idade", typeof(string));
                foreach (var item in filtro)
                {
                    item.setNome(pessoas.getNome());
                    item.setIdade(pessoas.getIdade());
                }
                return dtGrid.DataSource = dt;
            }
            else
            {
                return dtGrid.DataSource = listPessoa;
            }
        }
		public static Object Remover(int id, DataGridView dtGrid)
		{
            listPessoa.RemoveAll(i => i.getID() == id);
            if (listPessoa.Count == 0)
            {
                dt = new DataTable();
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Idade", typeof(string));
                dt.Rows.Add("Sem dados", "Sem dados", "Sem dados");
                return dtGrid.DataSource = dt;
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("Cod", typeof(string));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Idade", typeof(string));
				foreach (var item in listPessoa)
				{
				dt.Rows.Add(item.getID(), item.getNome(), item.getIdade());
				}
                return dtGrid.DataSource = dt;
            }
        }
    }
}
