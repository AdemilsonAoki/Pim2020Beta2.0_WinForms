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
    public partial class CU_CadastrosUsuarios : UserControl
    {
        public CU_CadastrosUsuarios()
        {
            InitializeComponent();
        }
        Funcionario funcionario = new Funcionario();

        private void cU_RelatoriosVendas1_Load(object sender, EventArgs e)
        {
            dgvFuncionario.DataSource = funcionario.Listar();
        }





        private void dgvFuncionario_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnAdicionarFuncionario_Click_1(object sender, EventArgs e)
        {
            Formularios.frmAddFuncionario addFuncionario = new Formularios.frmAddFuncionario();

            addFuncionario.Show();
        }

        private void btnAtulizar_Click_1(object sender, EventArgs e)
        {
            dgvFuncionario.DataSource = funcionario.Listar();
        }

        private void dgvFuncionario_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string idDgv;
            string nomeDgv;
            string enderecoDgv;
            string numeroDgv;
            string loginDgv;
            string senhaDgv;
            string cpfDgv;
            string cargoDgv;
            string telefoneDgv;

            // dgvCliente.CurrentRow.Selected = true;

            idDgv = this.dgvFuncionario.CurrentRow.Cells[0].Value.ToString();
            nomeDgv = this.dgvFuncionario.CurrentRow.Cells[1].Value.ToString();
            enderecoDgv = this.dgvFuncionario.CurrentRow.Cells[2].Value.ToString();
            numeroDgv = this.dgvFuncionario.CurrentRow.Cells[3].Value.ToString();
            loginDgv = this.dgvFuncionario.CurrentRow.Cells[4].Value.ToString();
            senhaDgv = this.dgvFuncionario.CurrentRow.Cells[5].Value.ToString();
            cpfDgv = this.dgvFuncionario.CurrentRow.Cells[6].Value.ToString();
            cargoDgv = this.dgvFuncionario.CurrentRow.Cells[7].Value.ToString();
            telefoneDgv = this.dgvFuncionario.CurrentRow.Cells[8].Value.ToString();


            using (Formularios.frmAddFuncionario abn = new Formularios.frmAddFuncionario())
            {
                abn.RecebendoValorDgv(idDgv, nomeDgv, enderecoDgv, numeroDgv, telefoneDgv, cpfDgv, cargoDgv, loginDgv, senhaDgv);
                abn.ShowDialog();

            }
        }
        private void Pesquisa()
        {
            if (cmbConsultaFuncionario.Text == "ID")
            {
                Funcionario funcionario = new Funcionario();
                funcionario.CodFuncionario = int.Parse(txtConsultaFuncionario.Text.Trim());
                dgvFuncionario.DataSource = funcionario.PesquisarCodigo(txtConsultaFuncionario.Text);
            }
            if (cmbConsultaFuncionario.Text == "Nome")
            {
                Funcionario funcionario = new Funcionario();
                funcionario.NomeFuncionario = txtConsultaFuncionario.Text.Trim();
                dgvFuncionario.DataSource = funcionario.PesquisarNome(txtConsultaFuncionario.Text);
            }
            if (cmbConsultaFuncionario.Text == "Cpf")
            {
                Funcionario funcionario = new Funcionario();
                funcionario.CpfFuncionario = txtConsultaFuncionario.Text.Trim();
                dgvFuncionario.DataSource = funcionario.PesquisarCpf(txtConsultaFuncionario.Text);
            }
            if (cmbConsultaFuncionario.Text == "Cargo")
            {
                Funcionario funcionario = new Funcionario();
                funcionario.CargoFuncionario = txtConsultaFuncionario.Text.Trim();
                dgvFuncionario.DataSource = funcionario.PesquisarCargo(txtConsultaFuncionario.Text);
            }
        }

        private void txtConsultaFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (txtConsultaFuncionario.Text == "")
            {
                Funcionario funcionario = new Funcionario();
                dgvFuncionario.DataSource = funcionario.Listar();
            }
            else
            {

                Pesquisa();
            }
        }

        private void txtConsultaFuncionario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbConsultaFuncionario.Text == "ID")
            {
                if ((Char.IsLetter(e.KeyChar)))
                    e.Handled = true;
            }
        }

        private void cmbConsultaFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtConsultaFuncionario.Clear();
        }
    }
}
