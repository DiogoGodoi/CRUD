using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Control;

namespace CRUD
{
    public partial class frmAlterar : Form
    {
        DataGridView dtGrid;
        int id;
        public frmAlterar(int id, DataGridView dtGrid)
        {
            InitializeComponent();
            this.dtGrid = dtGrid;
            this.id = id;
        }

        private void Alterar_click(object sender, EventArgs e)
        {
            TextBox nome = txtNome;
            TextBox idade = txtIdade;
            mdlPessoas pessoas = new mdlPessoas(id, nome.Text, idade.Text);
            ctrlPessoas.Alterar(id, pessoas, dtGrid);
            ctrlPessoas.ObterPessoas(dtGrid);
            nome.Text = String.Empty;
            idade.Text = String.Empty;
            nome.Focus();
            this.Close();
        }
    }
}
