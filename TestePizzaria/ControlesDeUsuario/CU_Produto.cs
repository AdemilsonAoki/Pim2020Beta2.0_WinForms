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
    public partial class CU_Produto : UserControl
    {
        public CU_Produto()
        {
            InitializeComponent();
            
        }
     
        private void btnAdicionarFornecedor_Click(object sender, EventArgs e)
        {
            using (Formularios.frmVendas ab = new Formularios.frmVendas())
            {
                ab.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Formularios.frmCadastroProduto abc = new Formularios.frmCadastroProduto())
            {
                abc.ShowDialog();
            }
        }

        private void dgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void btnAtulizar_Click(object sender, EventArgs e)
        {
            Produto prod = new Produto();
            dgvProduto.DataSource = prod.Listar();

        }
        private void Pesquisa()
        {
            Produto produto = new Produto();
            if (cmbConsultaProduto.Text == "Código Produto")
            {
                produto.Id = int.Parse(txtConsultaProduto.Text.Trim());
                produto.Dados = dgvProduto;
                produto.PesquisarCodigo((txtConsultaProduto.Text));
            }
            if (cmbConsultaProduto.Text == "Descricao")
            {
                produto.Descricao = txtConsultaProduto.Text.Trim();
                produto.Dados = dgvProduto;

                produto.PesquisarNome(txtConsultaProduto.Text);
            }
            if (cmbConsultaProduto.Text == "Categoria")
            {
                produto.Fabricante = dgvProduto.Text.Trim();
                produto.Dados = dgvProduto;

                produto.PesquisarCategoria(txtConsultaProduto.Text);
            } 
            if (cmbConsultaProduto.Text == "Fornecedor")
            {
                produto.Fabricante = dgvProduto.Text.Trim();
                produto.Dados = dgvProduto;

                produto.PesquisarFornecedor(txtConsultaProduto.Text);
            }

        }

        private void txtConsultaProduto_TextChanged(object sender, EventArgs e)
        {
            if (txtConsultaProduto.Text == "")
            {
                Produto produto = new Produto();
                dgvProduto.DataSource = produto.Listar();
            }
            else
            {

                Pesquisa();
            }
        }

        private void cmbConsultaProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtConsultaProduto.Clear();
        }

        private void txtConsultaProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbConsultaProduto.Text == "Código Produto")
            {
                if ((Char.IsLetter(e.KeyChar)))
                    e.Handled = true;
            }
        }

        private void dgvProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string descricaoDgv;
            string precoDgv;
            string precoVendaDgv;
            string categoriaDgv;
            string quantidadeDgv;
            string fornecedorDgv;
            string id_produtoDgv;
            string porcentagem;

            id_produtoDgv = this.dgvProduto.CurrentRow.Cells[0].Value.ToString();
            descricaoDgv = this.dgvProduto.CurrentRow.Cells[1].Value.ToString();
            precoDgv = this.dgvProduto.CurrentRow.Cells[2].Value.ToString();
            porcentagem = this.dgvProduto.CurrentRow.Cells[3].Value.ToString();
            precoVendaDgv = this.dgvProduto.CurrentRow.Cells[4].Value.ToString();
            categoriaDgv = this.dgvProduto.CurrentRow.Cells[5].Value.ToString();
            quantidadeDgv = this.dgvProduto.CurrentRow.Cells[6].Value.ToString();
            fornecedorDgv = this.dgvProduto.CurrentRow.Cells[7].Value.ToString();


            using (Formularios.frmCadastroProduto abn = new Formularios.frmCadastroProduto())
            {
                abn.RecebendoValorDgv(id_produtoDgv, descricaoDgv, precoDgv, precoVendaDgv, quantidadeDgv, fornecedorDgv, categoriaDgv, porcentagem);
                abn.ShowDialog();

            }
        }
    }
}
