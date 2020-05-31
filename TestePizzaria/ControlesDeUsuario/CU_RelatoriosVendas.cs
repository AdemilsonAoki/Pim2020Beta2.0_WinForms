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
    public partial class CU_RelatoriosVendas : UserControl
    {
        public CU_RelatoriosVendas()
        {
            InitializeComponent();
        }
        Vendas vend = new Vendas();
        private void btnAddVenda_Click(object sender, EventArgs e)
        {
            using (Formularios.frmVendas abn = new Formularios.frmVendas())
            {

                abn.ShowDialog();

            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

            float b1 = 0;
            dgvVenda.DataSource = vend.ListarVendas();
            for (int i = 0; i < dgvVenda.Rows.Count; i++)
            {
                b1 += Convert.ToInt32(dgvVenda.Rows[i].Cells[4].Value);

            }

            lblTotal.Text = b1.ToString();
        }

        private void dgvVenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           


        }
        private void Pesquisa()
        {
            
            if (cmbConsultaVenda.Text == "Id Venda")
            {
                vend.IdVenda = int.Parse(txtConsultaVenda.Text.Trim());
                vend.Dados = dgvVenda;
                vend.PesquisarCodigo((txtConsultaVenda.Text));
            }
          

        }

        private void txtConsultaVenda_TextChanged(object sender, EventArgs e)
        {
            if (txtConsultaVenda.Text == "")
            {
                
                dgvVenda.DataSource = vend.ListarVendas();
            }
            else
            {

                Pesquisa();
            }
        }

        private void cmbConsultaVenda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void dgvVenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvVenda.CurrentRow.Selected = true;





            string mensagem = "Deseja fazer reclamacoes/elogios dessa venda? ";
            string fechar = "fechando cadastro!!";
            var result = MessageBox.Show(mensagem, fechar,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);

            if (result != DialogResult.No)
            {
                

                vend.IdVenda = int.Parse(this.dgvVenda.CurrentRow.Cells[0].Value.ToString()); 

                Formularios.frmElogiosReclamacoes ER = new Formularios.frmElogiosReclamacoes();

                ER.RecebendoValorDgv(vend.IdVenda);
                ER.Show();
            }
            else
            {

                string cancelado = "Deseja Cancelar essa Venda? ";
                string fecharvenda = "fechando cadastro!!";
                var result1 = MessageBox.Show(cancelado, fecharvenda,
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);



                if (result1 != DialogResult.No)
                {
                    vend.IdVenda = int.Parse(this.dgvVenda.CurrentRow.Cells[0].Value.ToString());
                    vend.IdCliente = int.Parse(this.dgvVenda.CurrentRow.Cells[1].Value.ToString());
                    vend.DataVenda = DateTime.Parse(this.dgvVenda.CurrentRow.Cells[6].Value.ToString());
                    vend.TotalVendas = float.Parse(this.dgvVenda.CurrentRow.Cells[4].Value.ToString());
                    
                    vend.CadastrarVendaCancelada();
                    vend.LimpandoProdutoVendido();


                    vend.ExcluirVEnda();

                    MessageBox.Show("Venda Cancelada com sucesso!!");

                }


            }
        }
    }
}

