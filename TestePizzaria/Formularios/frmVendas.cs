using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzariaWinForm.Formularios
{
    public partial class frmVendas : Form
    {
        Vendas vendas = new Vendas();
        public frmVendas()
        {
            InitializeComponent();
            vendas.PreencherCliente(cmbCliente);
            vendas.PreencherFornecedor(cmbProduto);
            vendas.PreencherText(cmbProduto, txtPreco, txtTipo);
            timerData.Start();
        }

        string mensagem = "Deseja sair do cadastro?";
        string fechar = "fechando cadastro!!";

        private void RecebendoValor()
        {
            if (rbBroto.Checked == true)
            {
                vendas.TipoPizza = rbBroto.Text;
            }
            if (rbInteira.Checked == true)
            {
                vendas.TipoPizza = rbInteira.Text;
            }
            if (rbBroto.Checked != true && rbInteira.Checked != true)
            {
                vendas.TipoPizza = "Bebida";
            }

            vendas.IdCliente = int.Parse(cmbCliente.SelectedValue.ToString());
            vendas.Preco = float.Parse(txtPreco.Text);
            vendas.Quantidade = int.Parse(txtQuantidade.Text);
            vendas.Total = float.Parse(txtTotal.Text);
            vendas.DataVenda = DateTime.Parse(lblData.Text);
            vendas.Produto = int.Parse(cmbProduto.SelectedValue.ToString());


        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(mensagem, fechar,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

            if (result != DialogResult.No)
            {
                if (dgvVendas.RowCount == 1 || dgvVendas.RowCount == 0)
                {
                    MessageBox.Show("Venda Cancelada");
                    vendas.ExcluirVEnda();
                    this.Close();
                }
                else
                {
                    

                    MessageBox.Show("Esvazie os campos para cancelar a venda");
                }
            }

        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)))
                e.Handled = true;
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)))
                e.Handled = true;
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)))
                e.Handled = true;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(mensagem, fechar,
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question);

            if (result != DialogResult.No)
            {
                if (dgvVendas.RowCount == 1 || dgvVendas.RowCount == 0)
                {
                    MessageBox.Show("Venda Cancelada");
                    vendas.ExcluirVEnda();
                    this.Close();
                }
                else
                {


                    MessageBox.Show("Esvazie os campos para cancelar a venda");
                }
            }
        }

        private void cmbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            vendas.PreencherText(cmbProduto, txtPreco, txtTipo);

            float quantidade = 0;
            float total = 0;

            rbInteira.Checked = false;
            rbBroto.Checked = false;
            float preco = 0;
            if (txtQuantidade.Text != "")
            {
                quantidade = float.Parse(txtQuantidade.Text);
            }
            if (txtPreco.Text != "")
            {

                preco = float.Parse(txtPreco.Text);
            }
            total = quantidade * preco;


            txtTotal.Text = total.ToString("F2");
        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {
            if (txtTipo.Text == "Pizza")
            {
                rbBroto.Visible = true;
                rbInteira.Visible = true;
            }
            else
            {
                rbBroto.Visible = false;
                rbInteira.Visible = false;
            }
        }

        private void btnAddLista_Click(object sender, EventArgs e)
        {

            if (txtPreco.Text != " " && txtQuantidade.Text != " " && txtTipo.Text != "" && txtTotal.Text != "" &&  cmbProduto.Text != " " && cmbCliente.Text != "")
            {
                if (txtTipo.Text == "Pizza" && rbBroto.Checked == false && rbInteira.Checked == false)
                {
                    MessageBox.Show("Os campos devem Broto ou inteira devem ser selecionados !!", MessageBoxButtons.OK.ToString());
                }

                else
                {
                    RecebendoValor();
                   


                    if (txtId.Text != vendas.IdVenda.ToString())
                    {
                        vendas.IdVenda = int.Parse(txtId.Text);
                        vendas.CadastrarVenda();
                        vendas.IdVenda ++;
                    }
                    vendas.IdVenda = int.Parse(txtId.Text);

                    vendas.CadastrarProdutoVendido();
                    vendas.RetirarEstoque();

                    if (lblTotal.Text != "")
                    {
                        float total = float.Parse(txtTotal.Text);
                        total += float.Parse(lblTotal.Text);
                        lblTotal.Text = total.ToString();

                    }
                    else
                    {
                        lblTotal.Text = vendas.Total.ToString();
                    }


                    dgvVendas.DataSource = vendas.ListarCarrinho();

                    var result = MessageBox.Show("Cadastrado com sucesso!", MessageBoxButtons.OK.ToString());

                }

            }

            else
            {
                MessageBox.Show("Os campos devem ser preenchidos!!", MessageBoxButtons.OK.ToString());

            }
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            float quantidade = 0;
            float total = 0;


            float preco = 0;
            if (txtQuantidade.Text != "")
            {
                quantidade = float.Parse(txtQuantidade.Text);
            }
            if (txtPreco.Text != "")
            {

                preco = float.Parse(txtPreco.Text);
            }
            if (rbBroto.Checked == true)
            {

                total = (quantidade * preco) * 0.9f;
            }
            else
            {
                total = quantidade * preco;

            }


            txtTotal.Text = total.ToString();
        }

        private void frmVendas_Load(object sender, EventArgs e)
        {
            vendas.PreencherId(txtId);
            if (txtId.Text == "")
            {
                int fixo = 1;
                txtId.Text = fixo.ToString();
            }

           
            
        }

        private void rbInteira_CheckedChanged(object sender, EventArgs e)
        {
            float quantidade = 0;
            float total = 0;


            float preco = 0;
            if (txtQuantidade.Text != "")
            {
                quantidade = float.Parse(txtQuantidade.Text);
            }
            if (txtPreco.Text != "")
            {

                preco = float.Parse(txtPreco.Text);
            }


            total = quantidade * preco;

            txtTotal.Text = total.ToString("F2");
        }

        private void rbBroto_CheckedChanged(object sender, EventArgs e)
        {
            float quantidade = 0;
            float total = 0;


            float preco = 0;
            if (txtQuantidade.Text != "")
            {
                quantidade = float.Parse(txtQuantidade.Text);
            }
            if (txtPreco.Text != "")
            {

                preco = float.Parse(txtPreco.Text);
            }
            if (rbBroto.Text == "Broto" && txtTotal.Text != "")
            {
                total = (quantidade * preco) * 0.9f;
            }
            else
            {
                total = quantidade * preco;
            }
            txtTotal.Text = total.ToString("F2");
        }

        private void btnFinalizaVenda_Click(object sender, EventArgs e)
        {
            vendas.TotalVendas = float.Parse(lblTotal.Text);
            vendas.AtualizaTotal();
            this.Close();
        }

        private void dgvVendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvVendas.CurrentRow.Selected = true;

            vendas.IdProdutoVendido = int.Parse(this.dgvVendas.CurrentRow.Cells[7].Value.ToString());
            vendas.QuantidadeAdd = int.Parse(this.dgvVendas.CurrentRow.Cells[4].Value.ToString());
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            dgvVendas.CurrentRow.Selected = true;


            string mensagem = "Deseja retirar da lista?";
            string fechar = "Retirado com sucesso!!";
            var result = MessageBox.Show(mensagem, fechar,
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question);

            if (result != DialogResult.No)
            {
                vendas.ExcluirCarrinho();
                dgvVendas.DataSource = vendas.ListarCarrinho();
                vendas.AdicionarEstoque();

            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void timerData_Tick(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }
    }
}
