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
    public partial class frmAddFuncionario : Form
    {
        public frmAddFuncionario()
        {
            InitializeComponent();
        }



        private void frmAddFuncionario_Load(object sender, EventArgs e)
        {


        }


        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
        Funcionario funcionario = new Funcionario();
        string mensagem = "Deseja sair do cadastro?";
        string fechar = "fechando cadastro!!";
        private void RecebendoValor()
        {

            funcionario.NomeFuncionario = txtNome.Text;
            funcionario.EnderecoFuncionario = txtEndereco.Text;
            funcionario.TelefoneFuncionario = mskTelefone.Text;
            funcionario.CargoFuncionario = cmbCargo.Text;
            funcionario.CpfFuncionario = txtCpf.Text;
            funcionario.Usuario = txtUsuario.Text;
            funcionario.Senha = txtSenha.Text;
            funcionario.NumeroFuncionario = int.Parse(txtNumero.Text);

        }

        public void RecebendoValorDgv(string id, string cliente, string endereco, string numero, string telefone, string cpf, string cargo, string usuario, string senha)
        {
            txtId.Text = id;
            txtNome.Text = cliente;
            txtEndereco.Text = endereco;
            mskTelefone.Text = telefone;
            txtCpf.Text = cpf;
            txtNumero.Text = numero;
            cmbCargo.Text = cargo;
            txtUsuario.Text = usuario;
            txtSenha.Text = senha;
        }
        private void EsvaziandoCampos()
        {

            txtNome.Text = "";
            txtEndereco.Text = "";
            mskTelefone.Text = "" ;
            txtCpf.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtNumero.Text = "";

        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtCpf.Text != " " && txtNome.Text != " " && txtEndereco.Text != "" && mskTelefone.Text != "" && txtNumero.Text != "" && txtUsuario.Text != "" && txtSenha.Text != "" )
            {

                RecebendoValor();
                funcionario.Cadastrar();
                var result = MessageBox.Show("Cadastrado com sucesso!", MessageBoxButtons.OK.ToString());
                if (result == DialogResult.OK)
                {
                    this.Close();

                }

                
                
                EsvaziandoCampos();

            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)))
                e.Handled = true;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCpf.Text != " " && txtNome.Text != " " && txtEndereco.Text != "" && mskTelefone.Text != "" && txtNumero.Text != "" && txtUsuario.Text != "" && txtSenha.Text != "")
            {

                RecebendoValor();
                funcionario.CodFuncionario = int.Parse(txtId.Text);
                funcionario.Alterar();

            }


            var result = MessageBox.Show("Funcionario, Alterado com sucesso!", MessageBoxButtons.OK.ToString());

            if (result == DialogResult.OK)
            {
                this.Close();

                EsvaziandoCampos();

            }

            else
            {
                MessageBox.Show("Os campos devem ser preenchidos!!", MessageBoxButtons.OK.ToString());

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(mensagem, fechar,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);

            if (result != DialogResult.No)
            {
                this.Close();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(mensagem, fechar,
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);

            if (result != DialogResult.No)
            {
                this.Close();
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (txtCpf.Text != " " && txtNome.Text != " " && txtEndereco.Text != "" && mskTelefone.Text != "" && txtNumero.Text != "" && txtUsuario.Text != "" && txtSenha.Text != "")
            {

                RecebendoValor();
                funcionario.CodFuncionario = int.Parse(txtId.Text);
                funcionario.Excluir();

            }


            var result = MessageBox.Show("Funcionario, Excluido com sucesso!", MessageBoxButtons.OK.ToString());

            if (result == DialogResult.OK)
            {
                this.Close();

                EsvaziandoCampos();

            }

            else
            {
                MessageBox.Show("Os campos devem ser preenchidos!!", MessageBoxButtons.OK.ToString());

            }
        }
    }
}

