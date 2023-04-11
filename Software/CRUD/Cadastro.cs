using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Control;

namespace CRUD
{
	public partial class frmCadastro : Form
	{
		DataTable dt = null;
		string ID = "";
		int valor;
		string nome;
		string idade;
		public frmCadastro()
		{
			InitializeComponent();
		}

		private void Insert_Click(object sender, EventArgs e)
		{
			TextBox nome = txtNome;
			TextBox idade = txtIdade;
			if(nome.Text == String.Empty)
			{
				MessageBox.Show("Informe o nome da pessoa");
			}
			else if (idade.Text == String.Empty)
			{
				MessageBox.Show("Informe a idade da pessoa");
			}
			else
			{
			valor++;
            mdlPessoas pessoas = new mdlPessoas(valor, nome.Text, idade.Text);
			ctrlPessoas.Cadastrar(dtGrid, pessoas);
			nome.Text = String.Empty;
			idade.Text = String.Empty;
			nome.Focus();
			}
		}
		private void Tela_load(object sender, EventArgs e)
		{
           ctrlPessoas.ObterPessoas(dtGrid);
        }
		private void Alterar_Click(object sender, EventArgs e)
		{
			TextBox nome = txtNome;
			TextBox idade = txtIdade;

            if (dtGrid.Focus() == false)
			{
				MessageBox.Show("Por favor selecione a célula que contenha o código da pessoa");
			}
			else if(ID.ToString() == "Sem dados")
			{
				MessageBox.Show("Sem dados para serem alterados");
			}
			else
			{
				mdlPessoas pessoas = new mdlPessoas(int.Parse(ID), nome.Text, idade.Text);
				ctrlPessoas.Alterar(pessoas, dtGrid);
				ctrlPessoas.ObterPessoas(dtGrid);
            }
		}
		private void Pesquisar_Click(object sender, EventArgs e)
		{
			TextBox campoCodigo = txtCod;
			if(campoCodigo.Text == String.Empty)
			{
				MessageBox.Show("Por favor insira um código para efetuar a busca");
			}
			else
			{
			int codigo = Convert.ToInt32(txtCod.Text);
            ctrlPessoas.BuscaPorID(codigo, dtGrid);
			}
		}
		private void Exibir_Click(object sender, EventArgs e)
		{
			ctrlPessoas.ObterPessoas(dtGrid);
		}
        private void iconClose_Click(object sender, EventArgs e)
        {
			this.Close();
        }
        private void iconMaximize_Click(object sender, EventArgs e)
        {
			if(this.WindowState == FormWindowState.Maximized)
			{
                this.WindowState = FormWindowState.Normal;
			}
			else
			{
                this.WindowState = FormWindowState.Maximized;
            }
        }
        private void Excluir_Click(object sender, EventArgs e)
        {
            TextBox nome = txtNome;
            TextBox idade = txtIdade;

            if (dtGrid.Focus() == false)
            {
                MessageBox.Show("Por favor selecione a célula que contenha o código da pessoa");
            }
            else if (ID.ToString() == "Sem dados")
            {
                MessageBox.Show("Sem dados para serem alterados");
            }
			else { 
                mdlPessoas pessoas = new mdlPessoas(int.Parse(ID), nome.Text, idade.Text);
                ctrlPessoas.Remover(pessoas, dtGrid);
            }
        }
        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			TextBox Nome = txtNome;
			TextBox Idade = txtIdade;

			if(e.RowIndex >= 0) 
			{ 

			DataGridViewRow row = dtGrid.Rows[e.RowIndex];
			ID = row.Cells["Cod"].Value.ToString();
			nome = row.Cells["nome"].Value.ToString();
			idade = row.Cells["idade"].Value.ToString();
			Nome.Text = nome;
			Idade.Text = idade;

			}
        }
    }
}

