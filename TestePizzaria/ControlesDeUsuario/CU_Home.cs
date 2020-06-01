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
    public partial class CU_Home : UserControl
    {
        public CU_Home()
        {
            InitializeComponent();
            
            
        }

      
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss ");
            lblData.Text = DateTime.Now.ToLongDateString();
        }

      
    }
}
