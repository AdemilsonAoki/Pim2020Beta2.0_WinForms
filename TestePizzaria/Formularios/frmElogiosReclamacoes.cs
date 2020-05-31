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
    public partial class frmElogiosReclamacoes : Form
    {
        public frmElogiosReclamacoes()
        {
            InitializeComponent();
        }


        Vendas vendas = new Vendas();
        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void RecebendoValorDgv(int id)
        {
            txtId.Text = id.ToString();
        }
        public void RecebendoValor()
        {
            vendas.reclamcoesElogios = rtxtElogiosReclamcos.Text;
            vendas.IdVenda = int.Parse(txtId.Text);

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            RecebendoValor();
            vendas.reclamcoesElogios = rtxtElogiosReclamcos.Text;
            vendas.InserindoElogioReclamacao();
            MessageBox.Show("Campo preenchido");
            this.Close();
        }
    }
}
