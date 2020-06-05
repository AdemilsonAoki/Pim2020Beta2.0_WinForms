
using MySql.Data.MySqlClient;
using System.Data;


namespace PizzariaWinForm
{
    class dbConc

    {
        private string unidade;
        public string Unidade
        {
            get { return unidade; }
            set { unidade = value; }
        }
        public string test { get; set; }

        string conexao = "";
        string conexao1 = "Server=pim-2020.cj2olk5t1tbe.sa-east-1.rds.amazonaws.com;Database=pizzaria;Uid=Master;Pwd=Brasileiro55";
        string conexao2 = "Server=pim-2020.cj2olk5t1tbe.sa-east-1.rds.amazonaws.com;Database=pizzaria;Uid=Master;Pwd=Brasileiro56";
        string conexao3 = "Server=pim-2020.cj2olk5t1tbe.sa-east-1.rds.amazonaws.com;Database=pizzaria;Uid=Master;Pwd=Brasileiro55";






        public MySqlConnection AbrirBanco()
        {

            MySqlConnection cn = new MySqlConnection(conexao1);
            cn.Open();


            return cn;

        }
        public void FecharBanco(MySqlConnection cn)
        {
            if (cn.State == ConnectionState.Open)
                cn.Close();

        }
     }
}

