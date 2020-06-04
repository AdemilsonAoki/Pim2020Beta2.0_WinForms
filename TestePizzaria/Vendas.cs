using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Globalization;


namespace PizzariaWinForm
{
    class Vendas
    {
        private float total;
        private DateTime dataVenda;
        private int quantidade;
        private int quantidadeAdd;
        private int produto;
        private int idCliente;
        private float preco;
        private int idVenda;
        private int idProdutoVendido;
        private string tipoPizza;
        private float totalVendas;
        private string reclamacoesElogios;
        private string statusVenda;






        public int Produto
        {
            get { return produto; }
            set { produto = value; }
        }
        public string TipoPizza
        {
            get { return tipoPizza; }
            set { tipoPizza = value; }
        }
        public string reclamcoesElogios
        {
            get { return reclamacoesElogios; }
            set { reclamacoesElogios = value; }
        }
        public string StatusVenda
        {
            get { return statusVenda; }
            set { statusVenda = value; }
        }
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        public float Preco
        {
            get { return preco; }
            set { preco = value; }
        }
        public float TotalVendas
        {
            get { return totalVendas; }
            set { totalVendas = value; }
        }
        public float Total
        {
            get { return total; }
            set { total = value; }
        }
        public DateTime DataVenda
        {
            get { return dataVenda; }
            set { dataVenda = value; }
        }
        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }
        public int QuantidadeAdd
        {
            get { return quantidadeAdd; }
            set { quantidadeAdd = value; }
        }
        public int IdVenda
        {
            get { return idVenda; }
            set { idVenda = value; }
        }
        public int IdProdutoVendido
        {
            get { return idProdutoVendido; }
            set { idProdutoVendido = value; }
        }



        MySqlCommand comando;
        MySqlDataAdapter da;
        dbConc conexao = new dbConc();

        private DataGridView dados;



        public DataGridView Dados
        {
            get { return dados; }
            set { dados = value; }
        }


        public void CadastrarVenda()
        {
            string strSql = "INSERT INTO Venda(idVenda ,clienteVenda, dataVenda, totalVenda,reclamacoesElogiosVenda) " +
                    "VALUES ('" + idVenda + "','" + idCliente + "','" + dataVenda.ToString("yyyy-MM-dd HH:mm:ss") + "','" + totalVendas + "','" + reclamacoesElogios +  "')";

            try
            {

                comando = new MySqlCommand(strSql, conexao.AbrirBanco());
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());
                // conexao = null;
                // comando = null;
            }


        }

      
        public bool CadastrarProdutoVendido()
        {
            string strSql = "INSERT INTO ProdutoVenda(idVenda, idProduto, qtProdutoVenda, tipoProdutoVenda , totalProdutoVenda) " +
                   "VALUES ('" + idVenda + "','" + produto + "','" + quantidade + "','" + tipoPizza + "','" + total.ToString(CultureInfo.InvariantCulture) + "')";
            string strPtext = "select *from Produto where idProduto='" + produto + "'";
            comando = new MySqlCommand(strPtext, conexao.AbrirBanco());
            comando.ExecuteNonQuery();
            MySqlDataReader dr;
            dr = comando.ExecuteReader();
            while (dr.Read())
            {
                string quantia = (string)dr["quantidadeProduto"].ToString();
                int temp = int.Parse(quantia);

                if(quantidade > temp)
                {
                    return false;
                }
                else
                {
                    try
                    {

                        comando = new MySqlCommand(strSql, conexao.AbrirBanco());
                        comando.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        throw;
                       

                    }
                    finally
                    {
                        conexao.FecharBanco(conexao.AbrirBanco());
                        // conexao = null;
                        // comando = null;
                    }
                    return true;
                }

            }



            return true;


        }
        public void Alterar()
        {

            string strSql = "UPDATE Cliente SET nomeCliente='";

            try
            {

                comando = new MySqlCommand(strSql, conexao.AbrirBanco());
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());

                //conexao = null;
                //comando = null;
            }


        }
        public void RetirarEstoque()
        {

            string strSql = "update Produto set quantidadeProduto = quantidadeProduto - '" + quantidade + "' where idProduto = '" + produto + "'";

            try
            {

                comando = new MySqlCommand(strSql, conexao.AbrirBanco());
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());

                //conexao = null;
                //comando = null;
            }


        }
        public void LimpandoProdutoVendido()
        {
            string strSql = "DELETE FROM ProdutoVenda where idVenda='" + idVenda + "' ";
            try
            {

                comando = new MySqlCommand(strSql, conexao.AbrirBanco());
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());
                //conexao = null;
                //comando = null;
            }
        }
        public void InserindoElogioReclamacao()
        {
            string strSql = "update Venda set reclamacoesElogiosVenda = '" + reclamacoesElogios + "' where idVenda = '" + idVenda + "'";
            try
            {

                comando = new MySqlCommand(strSql, conexao.AbrirBanco());
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());
                //conexao = null;
                //comando = null;
            }
        }

        public void AdicionarEstoque()
        {

            string strSql = "update Produto set quantidadeProduto = quantidadeProduto + '" + quantidadeAdd + "' where idProduto = '" + produto + "'";

            try
            {

                comando = new MySqlCommand(strSql, conexao.AbrirBanco());
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());

                //conexao = null;
                //comando = null;
            }


        }
        public void ExcluirCarrinho()
        {
            string strSql = "DELETE FROM ProdutoVenda where idProdutoVenda='" + IdProdutoVendido + "' ";
            try
            {

                comando = new MySqlCommand(strSql, conexao.AbrirBanco());
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());
                //conexao = null;
                //comando = null;
            }



        }
        public void ExcluirVEnda()
        {
            string strSql = "DELETE FROM Venda where idVenda='" + idVenda + "' ";
            try
            {

                comando = new MySqlCommand(strSql, conexao.AbrirBanco());
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());
                //conexao = null;
                //comando = null;
            }



        }

        public DataTable ListarCarrinho()

        {
            idProdutoVendido = idVenda;
            string strSql = "select v.idVenda as 'Id Venda', c.nomeCliente as 'Nome Cliente',p.idProduto as 'Id produto', p.descricaoProduto as 'Descrição', pv.qtProdutoVenda as' Quantidade ', p.precoProduto as 'Preço', pv.totalProdutoVenda as 'Total', pv.idProdutoVenda from Produto p join ProdutoVenda pv on p.idProduto = pv.idProduto join Venda v on pv.idVenda = v.idVenda join Cliente c on v.clienteVenda = c.idCliente where pv.idVenda = '" + idVenda + "'";


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
        public DataTable ListarVendas()
        {
            idProdutoVendido = idVenda;
            string strSql = "select v.idVenda as 'Id Venda',c.idCliente as 'id Cliente', c.nomeCliente as 'Nome' ,  sum(pv.qtProdutoVenda) 'Qt Total', v.totalVenda as 'Total Venda', v.reclamacoesElogiosVenda as 'Reclamações/Elogios' , v.dataVenda as 'Data Venda'from Produto p join ProdutoVenda pv on p.idProduto = pv.idProduto join Venda v on pv.idVenda = v.idVenda join Cliente c on v.clienteVenda = c.idCliente  group by c.idCliente, v.idVenda";


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
        public void AtualizaTotal()
        {
            idProdutoVendido = idVenda;
            string strSql = "UPDATE Venda SET totalVenda='" + totalVendas +
                 "' where idVenda= '" + idVenda + "'";


            try
            {

                comando = new MySqlCommand(strSql, conexao.AbrirBanco());
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());

                //conexao = null;
                //comando = null;
            }
        }

        public void PreencherProduto(ComboBox box)
        {

            try
            {
                string tbFornecedor = "select * from Produto";
                comando = new MySqlCommand(tbFornecedor, conexao.AbrirBanco());
                DataSet ds = new DataSet();
                da = new MySqlDataAdapter(comando);
                da.Fill(ds);
                box.DataSource = ds.Tables[0];
                box.DisplayMember = "descricaoProduto";
                box.ValueMember = "idProduto";


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());
            }

        }

        public void PreencherText(ComboBox cmbproduto, TextBox txtpreco, TextBox txttipo)
        {

            string strPtext = "select *from Produto where descricaoProduto='" + cmbproduto.Text + "'";
            comando = new MySqlCommand(strPtext, conexao.AbrirBanco());
            comando.ExecuteNonQuery();
            MySqlDataReader dr;
            dr = comando.ExecuteReader();
            while (dr.Read())
            {
                string preco = (string)dr["precoProduto"].ToString();
                txtpreco.Text = preco;
                string tipo = (string)dr["categoriaProduto"].ToString();
                txttipo.Text = tipo;

            }

        }
        public void PreencherId(TextBox txtNumVenda)
        {

            int fixo = 1;
            int precoI;
            int total;

            string strPtext = "select idVenda from Venda where idVenda= (select max(idVenda) from Venda)";
            comando = new MySqlCommand(strPtext, conexao.AbrirBanco());
            comando.ExecuteNonQuery();
            MySqlDataReader dr;
            dr = comando.ExecuteReader();
            while (dr.Read())
            {
                string preco = (string)dr["idVenda"].ToString();
                precoI = int.Parse(preco);
                total = precoI + fixo;
                txtNumVenda.Text = total.ToString();


            }
        }

        public void PreencherCliente(ComboBox comboBox)
        {


            try
            {
                string tbFornecedor = "select * from Cliente";
                comando = new MySqlCommand(tbFornecedor, conexao.AbrirBanco());
                DataSet ds = new DataSet();
                da = new MySqlDataAdapter(comando);
                da.Fill(ds);
                comboBox.DataSource = ds.Tables[0];
                comboBox.DisplayMember = "nomeCliente";
                comboBox.ValueMember = "idCliente";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());
            }

        }
        public void PreencherFornecedor(ComboBox comboBox)
        {


            try
            {
                string tbFornecedor = "select *from Produto";
                comando = new MySqlCommand(tbFornecedor, conexao.AbrirBanco());
                DataSet ds = new DataSet();
                da = new MySqlDataAdapter(comando);
                da.Fill(ds);
                comboBox.DataSource = ds.Tables[0];
                comboBox.DisplayMember = "descricaoProduto";
                comboBox.ValueMember = "idProduto";



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());
            }

        }
        public void CadastrarVendaCancelada()
        {
            string strSql = "INSERT INTO VendasCanceladas(clienteVenda, dataVenda, totalVendas, reclamacoesElogios) " +
                    "VALUES ('" + idCliente + "','" + dataVenda.ToString("yyyy-MM-dd HH:mm:ss") + "','" + totalVendas.ToString(CultureInfo.InvariantCulture) + "','" + reclamacoesElogios + "')";

            try
            {

                comando = new MySqlCommand(strSql, conexao.AbrirBanco());
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());
                // conexao = null;
                // comando = null;
            }


        }

        public void PesquisarCodigo(string codigo)
        {

            try
            {

                // "select *from Fornecedor where razao_social LIKE'%'  @razao_social '%' ORDER BY razao_social
                comando = new MySqlCommand("select *from Venda where idVenda LIKE'%'  @idVendas '%' ORDER BY idVenda", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@idVendas", codigo);

                MySqlDataAdapter da = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();


                da.Fill(dtLista);
                dados.DataSource = dtLista;



            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
