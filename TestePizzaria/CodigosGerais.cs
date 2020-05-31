using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzariaWinForm
{
    class CodigosGerais
    {
        public  void Moeda( TextBox txt)
        {
            string m = string.Empty;
            double v = 0;
            try
            {
                m = txt.Text.Replace(",", "").Replace(".", "");
                if (m.Equals(""))
                    m = "";
                m = m.PadLeft(3, '0');
                if (m.Length > 3 & m.Substring(0, 1) == "0")
                    m = m.Substring(1, m.Length - 1);
                v = Convert.ToDouble(m) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception)
            {

            }
        }
    }
}
