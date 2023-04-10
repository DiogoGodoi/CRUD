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
		private int ID = 0;
		public frmCadastro()
		{
			InitializeComponent();
		}

		private void Insert_Click(object sender, EventArgs e)
		{
			TextBox nome = txtNome;
			TextBox idade = txtIdade;
            ID++;
            mdlPessoas pessoas = new mdlPessoas(ID, nome.Text, idade.Text);
			ctrlPessoas.Cadastrar(dtGrid, pessoas);
			nome.Text = String.Empty;
			idade.Text = String.Empty;
			nome.Focus();
		}
		private void Tela_load(object sender, EventArgs e)
		{
           ctrlPessoas.ObterPessoas(dtGrid);
        }
		private void Alterar_Click(object sender, EventArgs e)
		{
			string id = dtGrid.SelectedCells[0].Value.ToString();
			Form alterar = new frmAlterar(int.Parse(id), dtGrid);
			alterar.ShowDialog();
		}
		private void Pesquisar_Click(object sender, EventArgs e)
		{
			int codigo = Convert.ToInt32(txtCod.Text);
            ctrlPessoas.BuscaPorID(codigo, dtGrid);
		}
		private void Exibir_Click(object sender, EventArgs e)
		{
			ctrlPessoas.ObterPessoas(dtGrid);
		}
		private void Excluir_Click(object sender, EventArgs e)
		{
			int codigo = Convert.ToInt32(txtCod.Text);
            ctrlPessoas.Remover(codigo, dtGrid);
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
    }
}

