using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace PizzariaWinForm
{
    class Produto
    {
        dbConc conexao = new dbConc();
        MySqlCommand comando;
        MySqlDataAdapter da;

        private string descricao;
        private double preco;
        private double precoVenda;
        private double porcentagem;
        private int quantidade;
        private string fabricante;
        private int id;
        private DataGridView dados;


        private string categoria;




        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }
        public string Fabricante
        {
            get { return fabricante; }
            set { fabricante = value; }
        }
        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }
        public double PrecoVenda
        {
            get { return precoVenda; }
            set { precoVenda = value; }
        }
        public double Porcentagem
        {
            get { return porcentagem; }
            set { porcentagem = value; }
        }

        public DataGridView Dados
        {

            get { return dados; }
            set { dados = value; }
        }
        bool cad = false;
        public void Cadastrar()
        {




            try
            {

                string strSql = "INSERT INTO Produto (descricaoProduto, precoProduto, porcentagemProduto, precoVendaProduto, categoriaProduto, quantidadeProduto, fornecedor) " +
                "VALUES ('" + descricao + "','" + preco.ToString(CultureInfo.InvariantCulture) + "','" + porcentagem + "' , '" + precoVenda.ToString(CultureInfo.InvariantCulture) + "', '" + categoria + "', '" + quantidade + "', '" + fabricante + "')";
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
        public void Alterar()
        {
            try
            {


                string strSql = "UPDATE Produto SET descricaoProduto='" + descricao + "', precoProduto= '" + preco + "', porcentagemProduto= '" + porcentagem + "', precoVendaProduto= '" + precoVenda + "' , categoriaProduto= '" + categoria + "', quantidadeProduto= '" + quantidade + "', fornecedor= '" + fabricante + "' where idProduto='" + id + "'";

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
        public void Excluir()
        {
            try
            {

                string strSql = "DELETE FROM Produto where idProduto='" + id + "' ";

                comando = new MySqlCommand(strSql, conexao.AbrirBanco());
                comando.ExecuteNonQuery();
                cad = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cad = false;
            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());
                //conexao = null;
                //comando = null;
            }
            if (cad == true)
            {
                MessageBox.Show("excluido com sucesso!", MessageBoxButtons.OK.ToString());
            }


        }
        public DataTable Listar()

        {
            string strSql = "select descricaoProduto as 'Descrição', precoProduto as 'Preço', porcentagemProduto as 'Porcentagem', precoVendaProduto as 'Preço Venda', categoriaProduto as 'Categoria' , quantidadeProduto ' Quantidade ' , fornecedor as Fornecedor from Produto";


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
        public void PesquisarCodigo(string codigo)
        {

            try
            {


                comando = new MySqlCommand("select *from Produto where idProduto LIKE'%'  @id_produto '%' ORDER BY idProduto", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@id_produto", codigo);

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
        public void PesquisarFornecedor(string fornecedor)
        {

            try
            {


                comando = new MySqlCommand("select *from Produto where fornecedor LIKE'%'  @fornecedor '%' ORDER BY fornecedor", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@fornecedor", fornecedor);

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
        public void PesquisarCategoria(string categoria)
        {

            try
            {


                comando = new MySqlCommand("select *from Produto where categoriaProduto LIKE'%'  @categoria '%' ORDER BY categoriaProduto", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@categoria", categoria);

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
        public void PesquisarNome(string nome)
        {

            try
            {


                comando = new MySqlCommand("select *from Produto where descricaoProduto LIKE'%'  @descricao '%' ORDER BY descricaoProduto", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@descricao", nome);

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

        public void PreencherFornecedor(ComboBox comboBox)
        {


            try
            {
                string tbFornecedor = "select *from Fornecedor";
                comando = new MySqlCommand(tbFornecedor, conexao.AbrirBanco());
                DataSet ds = new DataSet();
                da = new MySqlDataAdapter(comando);
                da.Fill(ds);
                comboBox.DataSource = ds.Tables[0];
                comboBox.DisplayMember = "nomeFantasia";
                comboBox.ValueMember = "cnpj";



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


    }
}
