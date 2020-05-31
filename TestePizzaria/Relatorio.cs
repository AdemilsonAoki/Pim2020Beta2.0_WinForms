using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;



namespace PizzariaWinForm
{

   class Relatorio
    {
        private DateTime dataVendaI;
        private DateTime dataVendaF;

        public DateTime DataVendasI
        {
            get { return dataVendaI; }
            set { dataVendaI = value; }
        } 
        public DateTime DataVendasF
        {
            get { return dataVendaF; }
            set { dataVendaF = value; }
        }
        MySqlCommand comando;
        dbConc conexao = new dbConc();
        public DataTable PesquisaData()
        {
            
            
            try
            {
                
                string strMysql = " select vc.idVenda as 'Id Venda ',c.idCliente as 'id Cliente', c.nomeCliente as 'Nome' ,   vc.totalVenda as 'Total Venda', vc.reclamacoesElogiosVenda as 'Reclamações/Elogios' , vc.dataVenda as 'Data Venda' from Produto p join ProdutoVenda pv on p.idProduto = pv.idProduto join Venda vc on pv.idVenda = vc.idVenda join Cliente c on vc.clienteVenda = c.idCliente   where DATE_FORMAT(dataVenda, '%Y-%m-%d') BETWEEN '" + dataVendaI.ToString("yyyy-MM-dd") + "'AND '" + dataVendaF.ToString("yyyy-MM-dd") + "'";
                comando = new MySqlCommand(strMysql, conexao.AbrirBanco()); ;
     
                MySqlDataAdapter da = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();


                da.Fill(dtLista);
                
                
                return (dtLista);


            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable PesquisaDataCancelados()
        {
            
            
            try
            {
                
                string strMysql = " select vc.idVendasCancelada as 'Id Vendas Canceladas', c.nomeCliente as 'Nome', vc.dataVenda as 'Data Venda' , vc.reclamacoesElogios as 'Reclamações/Elogios', vc.totalVendas as 'Total' from VendasCanceladas vc join Cliente c on  vc.clienteVenda = c.idCliente where DATE_FORMAT(dataVenda, '%Y-%m-%d') BETWEEN '" + dataVendaI.ToString("yyyy-MM-dd") + "'AND '" + dataVendaF.ToString("yyyy-MM-dd") + "'";
                comando = new MySqlCommand(strMysql, conexao.AbrirBanco()); ;
     
                MySqlDataAdapter da = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();


                da.Fill(dtLista);
                
                
                return (dtLista);


            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable Listar()

        {
            string strSql = "select vc.idVenda as 'Id Venda ',c.idCliente as 'id Cliente', c.nomeCliente as 'Nome' ,   vc.totalVenda as 'Total Venda', vc.reclamacoesElogiosVenda as 'Reclamações/Elogios' , vc.dataVenda as 'Data Venda' from Produto p join ProdutoVenda pv on p.idProduto = pv.idProduto join Venda vc on pv.idVenda = vc.idVenda join Cliente c on vc.clienteVenda = c.idCliente  group by c.idCliente, vc.idVenda  ";


            try
            {
                comando = new MySqlCommand(strSql, conexao.AbrirBanco());

                MySqlDataAdapter da = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                da.Fill(dtLista);

                return dtLista;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable ListarCancelados()

        {
            string strSql = "select vc.idVendasCancelada as 'Id Vendas Canceladas', c.nomeCliente as 'Nome', vc.dataVenda as 'Data Venda' , vc.reclamacoesElogios as 'Reclamações/Elogios', vc.totalVendas as 'Total' from VendasCanceladas vc join Cliente c on  vc.clienteVenda = c.idCliente  ";


            try
            {
                comando = new MySqlCommand(strSql, conexao.AbrirBanco());

                MySqlDataAdapter da = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();

                da.Fill(dtLista);

                return dtLista;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
