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
    public partial class CU_CadastroClientes : UserControl
    {


        public CU_CadastroClientes()
        {
            InitializeComponent();

            //this.clienteTableAdapter.Fill(this.pizzariaDataSet.Cliente);
        }
    



        private void btnAdicionarFornecedor_Click(object sender, EventArgs e)
        {
            using (Formularios.frmCadastroCliente abn = new Formularios.frmCadastroCliente())
            {
                abn.ShowDialog();

            }
        }
      



        private void btnAtulizar_Click(object sender, EventArgs e)
        {

            Cliente cliente = new Cliente();
            dgvCliente.DataSource = cliente.Listar();

        }


       

         
        private void Pesquisa()
        {
            Cliente cliente = new Cliente();
            if (cmbConsultaCliente.Text == "Código Cliente")
            {
                cliente.Id = int.Parse( txtConsultaCliente.Text.Trim());
                dgvCliente.DataSource =  cliente.PesquisarCodigo((txtConsultaCliente.Text));
            }
            if (cmbConsultaCliente.Text == "Nome")
            {
                cliente.Nome = txtConsultaCliente.Text.Trim();
                 dgvCliente.DataSource = cliente.PesquisarNome(txtConsultaCliente.Text);
            }
            if (cmbConsultaCliente.Text == "Cpf")
            {
                cliente.CPF = dgvCliente.Text.Trim();
               
                dgvCliente.DataSource = cliente.PesquisarCpf(txtConsultaCliente.Text);

            }

        }
        private void cmbConsultaCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtConsultaCliente.Clear();
        }

        

        private void txtConsultaCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtConsultaCliente.Text == "")
            {
                Cliente cli = new Cliente();
                dgvCliente.DataSource = cli.Listar();
            }
            else
            {

                Pesquisa();
            }
        }

        private void txtConsultaCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbConsultaCliente.Text == "Código Cliente")
            {
                if ((Char.IsLetter(e.KeyChar)))
                    e.Handled = true;
            }
        }

        private void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string idDgv;
            string nomeDgv;
            string enderecoDgv;
            string numeroDgv;
            string telefoneDgv;
            string cpfdDgv;

           // dgvCliente.CurrentRow.Selected = true;
            
            idDgv = this.dgvCliente.CurrentRow.Cells[0].Value.ToString();
            nomeDgv  = this.dgvCliente.CurrentRow.Cells[1].Value.ToString();
            enderecoDgv = this.dgvCliente.CurrentRow.Cells[2].Value.ToString();
            numeroDgv   = this.dgvCliente.CurrentRow.Cells[3].Value.ToString();
            telefoneDgv = this.dgvCliente.CurrentRow.Cells[4].Value.ToString();
            cpfdDgv = this.dgvCliente.CurrentRow.Cells[5].Value.ToString();


            using (Formularios.frmCadastroCliente abn = new Formularios.frmCadastroCliente())
            {
                abn.RecebendoValorDgv(idDgv, nomeDgv, enderecoDgv, numeroDgv, telefoneDgv, cpfdDgv);
                abn.ShowDialog();

            }
           

            
            
        }

        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /* private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {



                 string idDgv;
                 string nomeDgv;
                 string enderecoDgv;
                 string numeroDgv;
                 string telefoneDgv;
                 string cpfdDgv;

                 dgvCliente.CurrentRow.Selected = true;
                 idDgv = dgvCliente.Rows[e.RowIndex].Cells["Código Cliente"].FormattedValue.ToString();
                 nomeDgv = dgvCliente.Rows[e.RowIndex].Cells["Nome"].FormattedValue.ToString();
                 enderecoDgv = dgvCliente.Rows[e.RowIndex].Cells["Endereco"].FormattedValue.ToString();
                 numeroDgv = dgvCliente.Rows[e.RowIndex].Cells["Numero"].FormattedValue.ToString();
                 telefoneDgv = dgvCliente.Rows[e.RowIndex].Cells["Telefone"].FormattedValue.ToString();
                 cpfdDgv = dgvCliente.Rows[e.RowIndex].Cells["Cpf"].FormattedValue.ToString();



                 Formularios.frmCadastroCliente cad = new Formularios.frmCadastroCliente();

                 cad.RecebendoValorDgv(idDgv, nomeDgv, enderecoDgv, numeroDgv, telefoneDgv, cpfdDgv);
                 cad.Show();

         }*/
    }
}
