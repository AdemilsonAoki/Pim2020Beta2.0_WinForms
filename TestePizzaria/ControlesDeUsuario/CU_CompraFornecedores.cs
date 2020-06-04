using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzariaWinForm.ControlesDeUsuario
{
    public partial class CU_CompraFornecedores : UserControl
    {
        public CU_CompraFornecedores()
        {
            InitializeComponent();
        }

        private void btnAdicionarFornecedor_Click(object sender, EventArgs e)
        {
            using (Formularios.frmNovoFornecedor abn = new Formularios.frmNovoFornecedor())
            {
                abn.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* using (Formularios.frmCadastroEstoque ads = new Formularios.frmCadastroEstoque())
             {
                 ads.ShowDialog();
             }*/
        }



        private void btnAtulizar_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            int b1 = 0;
            dgvFornecedor.DataSource = fornecedor.Listar();

        }

        private void dgvFornecedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void Pesquisa()
        {
            if (cmbConsultaFornecedor.Text == "Nome Fantasia")
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.Nome = txtConsultaFornecedor.Text.Trim();
                dgvFornecedor.DataSource = fornecedor.PesquisarNome(txtConsultaFornecedor.Text);
            }
            if (cmbConsultaFornecedor.Text == "Razão Social")
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.Nome = txtConsultaFornecedor.Text.Trim();
                dgvFornecedor.DataSource = fornecedor.PesquisarRazaoSocial(txtConsultaFornecedor.Text);
            }
            if (cmbConsultaFornecedor.Text == "CNPJ")
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.Nome = txtConsultaFornecedor.Text.Trim();
                dgvFornecedor.DataSource = fornecedor.PesquisarCnpj(txtConsultaFornecedor.Text);
            }

        }


        private void cmbConsultaFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtConsultaFornecedor.Clear();
        }

        private void txtConsultaFornecedor_TextChanged(object sender, EventArgs e)
        {
            if (txtConsultaFornecedor.Text == "")
            {
                Fornecedor fornecedor = new Fornecedor();
                dgvFornecedor.DataSource = fornecedor.Listar();
            }
            else
            {

                Pesquisa();
            }
        }

        private void txtConsultaFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvFornecedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string razao_socialDgv;
            string cnpjDgv;
            string nomeDgv;
            string numeroDgv;
            string enderecoDgv;
            string telefoneDgv;

            string obsDgv;
            // dgvCliente.CurrentRow.Selected = true;

            razao_socialDgv = this.dgvFornecedor.CurrentRow.Cells[0].Value.ToString();
            cnpjDgv = this.dgvFornecedor.CurrentRow.Cells[1].Value.ToString();
            nomeDgv = this.dgvFornecedor.CurrentRow.Cells[2].Value.ToString();
            enderecoDgv = this.dgvFornecedor.CurrentRow.Cells[3].Value.ToString();
            numeroDgv = this.dgvFornecedor.CurrentRow.Cells[4].Value.ToString();
            telefoneDgv = this.dgvFornecedor.CurrentRow.Cells[5].Value.ToString();
            obsDgv = this.dgvFornecedor.CurrentRow.Cells[6].Value.ToString();


            using (Formularios.frmNovoFornecedor abn = new Formularios.frmNovoFornecedor())
            {
                abn.RecebendoValorDgv(razao_socialDgv, nomeDgv, enderecoDgv, numeroDgv, telefoneDgv, cnpjDgv, obsDgv);
                abn.ShowDialog();

            }
        }
    }
}
