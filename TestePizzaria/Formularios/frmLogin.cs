using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzariaWinForm
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
      
        Login login = new Login();
        Funcionario funcionario = new Funcionario();
        

        frmMenu menu = new frmMenu();
        public void RecebendoValor()
        {
            
            login.Usuario = txtUsuario.Text;
            login.Senha = txtSenha.Text;
            
            funcionario.Usuario = txtUsuario.Text;
            funcionario.Senha = txtSenha.Text;
            
           
            

          


        }
        
        private void btnEntrar_Click(object sender, EventArgs e)
        {

            RecebendoValor();

            

            var validar = funcionario.VerificaoFuncioanrio(txtUsuario.Text, txtSenha.Text);
            if(validar == true)
            {
                MessageBox.Show("Bem vindo ao sistema!!", txtUsuario.Text);
                this.Hide();
                    
            }
            else
            {
                MessageBox.Show("Login ou senha invalidos");
                txtUsuario.Clear();
                txtSenha.Clear();
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }



}
