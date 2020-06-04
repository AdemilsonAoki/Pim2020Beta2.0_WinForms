using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace PizzariaWinForm
{



    class Fornecedor
    {
        private string razao_social;
        private string cnpj;
        private string nome;
        private string telefone;
        private string endereco;
        private string obs;
        private int numero;
        private DataGridView dados;


        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        } 
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public string Razao_social
        {
            get { return razao_social; }
            set { razao_social = value; }
        }  
        public string Obs
        {
            get { return obs; }
            set { obs = value; }
        }
        public DataGridView Dados
        {
            get { return dados; }
            set { dados = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        dbConc conexao = new dbConc();
        MySqlCommand comando;


        public void Cadastrar()
        {
            string strSql = "INSERT INTO Fornecedor (razaoSocial, cnpj, nomeFantasia ,enderecoFornecedor, numeroFornecedor, telefoneFornecedor, observacoesFornecedor) " +
                   "VALUES ('" + razao_social + "','" + cnpj + "','" + nome + "' ,'" + endereco + "' , '" + numero + "', '" + telefone + "', '" + obs + "')";

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
        public void Alterar()
        {
            
            string strSql =  "UPDATE Fornecedor SET razaoSocial = '" + razao_social +
                "', nomeFantasia= '" + nome + "' , enderecoFornecedor= '" + endereco + "', numeroFornecedor= '" + numero + "' , telefoneFornecedor= '" + telefone + "', observacoesFornecedor= '" + obs + "' where cnpj= '" + cnpj + "'";
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
        public void Excluir()
        {
            string strSql = "a";
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
        public DataTable Listar()
           
        {
            string strSql = "select razaoSocial as 'Razão Social', cnpj as CNPJ, nomeFantasia as 'Nome Fantasia' , enderecoFornecedor as 'Endereço', numeroFornecedor as Numero, telefoneFornecedor as Telefone, observacoesFornecedor as 'Observaçòes'  from Fornecedor"; 
            

            try
            {
                comando = new MySqlCommand(strSql, conexao.AbrirBanco());

                MySqlDataAdapter da = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();
                
                da.Fill(dtLista);

                return dtLista;

            }
            catch (Exception )
            {
                throw;
            }
        }

        public DataTable PesquisarNome(string nome )
        {
           
            try
            {
                
                
                comando = new MySqlCommand("select razaoSocial as 'Razão Social', cnpj as CNPJ, nomeFantasia as 'Nome Fantasia' , enderecoFornecedor as 'Endereço', numeroFornecedor as Numero, telefoneFornecedor as Telefone, observacoesFornecedor as 'Observaçòes'  from Fornecedor where nomeFantasia LIKE'%'  @nome '%' ORDER BY nomeFantasia", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@nome", nome);
               
                MySqlDataAdapter da = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();
               
               
                da.Fill(dtLista);
                return dtLista;

               

            }
            catch (Exception )
            {
                throw;
            }
        }  
        public DataTable PesquisarCnpj(string cnpj )
        {
           
            try
            {
                
                
                comando = new MySqlCommand("select razaoSocial as 'Razão Social', cnpj as CNPJ, nomeFantasia as 'Nome Fantasia' , enderecoFornecedor as 'Endereço', numeroFornecedor as Numero, telefoneFornecedor as Telefone, observacoesFornecedor as 'Observaçòes'  from Fornecedor where cnpj LIKE'%'  @cnpj '%' ORDER BY cnpj", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@cnpj", cnpj);
               
                MySqlDataAdapter da = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();
               
               
                da.Fill(dtLista);
                return dtLista;

               

            }
            catch (Exception )
            {
                throw;
            }
        }
        public DataTable PesquisarRazaoSocial(string razaoSocial )
        {
           
            try
            {
                
                
                comando = new MySqlCommand("select razaoSocial as 'Razão Social', cnpj as CNPJ, nomeFantasia as 'Nome Fantasia' , enderecoFornecedor as 'Endereço', numeroFornecedor as Numero, telefoneFornecedor as Telefone, observacoesFornecedor as 'Observaçòes'  from Fornecedor where razaoSocial LIKE'%'  @razao_social '%' ORDER BY razaoSocial", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@razao_social", razaoSocial);
               
                MySqlDataAdapter da = new MySqlDataAdapter(comando);

                DataTable dtLista = new DataTable();
               
               
                da.Fill(dtLista);
                return dtLista;

               

            }
            catch (Exception )
            {
                throw;
            }
        }
        public bool VerificarCnpj(string cnpj)
        {


            string vericadora = "select Count(1) from Fornecedor where cnpj='" + cnpj + "' ";
            try
            {

                comando = new MySqlCommand(vericadora, conexao.AbrirBanco());
                var resultado = comando.ExecuteScalar();
                if (resultado.ToString() != "0")
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conexao.FecharBanco(conexao.AbrirBanco());
                // conexao = null;
                // comando = null;
            }


        }
    }
}
