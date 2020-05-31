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
    public partial class CU_Relatorios : UserControl
    {
        Relatorio relatorio = new Relatorio();
        public CU_Relatorios()
        {
            InitializeComponent();
            //this.bindingSource1.Fill(this.pizzariaDataSet.DataTable1);
            dgvRelatorio.DataSource = relatorio.Listar();
            dgvRelatorioCancelados.DataSource = relatorio.ListarCancelados();
            CalculaTotais();
        }

        private void btnAdicionarFornecedor_Click(object sender, EventArgs e)
        {
            using (Formularios.frmAddDespesa ae = new Formularios.frmAddDespesa()) 
            {
                ae.ShowDialog();
            }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            
            relatorio.DataVendasI = DateTime.Parse(dtpDataI.Text);
            relatorio.DataVendasF = DateTime.Parse(dtpDataF.Text);
            dgvRelatorio.DataSource = relatorio.PesquisaData();
            dgvRelatorioCancelados.DataSource = relatorio.PesquisaData();
            
         

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CalculaTotais()
        {
            float b1 = 0f;
            float b2 = 0f;
            float resultado = 0f;
            for (int i = 0; i < dgvRelatorio.Rows.Count; i++)
            {
                b1 += Convert.ToInt32(dgvRelatorio.Rows[i].Cells[3].Value);

            } 
            for (int i = 0; i < dgvRelatorioCancelados.Rows.Count; i++)
            {
                b2 += Convert.ToInt32(dgvRelatorioCancelados.Rows[i].Cells[4].Value);

            }
            lblTotalCancelado.Text = b2.ToString();
            lblTotalRecebido.Text = b1.ToString();
            
            resultado = b1 - b2;
            lblTotalLiquido.Text = resultado.ToString();
            

           
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
