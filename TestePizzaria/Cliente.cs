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
    class Cliente

    {
        private string nome;
        private string endereco;
        private string telefone;
        private string cpf;
        private int numero;
        private int id;



        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        public string CPF
        {
            get { return cpf; }
            set { cpf = value; }
        }
        dbConc conexao = new dbConc();
        MySqlCommand comando;

        private DataGridView dados;



        public DataGridView Dados
        {
            get { return dados; }
            set { dados = value; }
        }


     
        public void Cadastrar()
        {
            string strSql = "INSERT INTO Cliente (nomeCliente, enderecoCliente, numeroCliente ,telefoneCliente, cpfCliente) " +
                   "VALUES ('" + Nome + "','" + Endereco + "','" + Numero + "' ,'" + Telefone + "' , '" + CPF + "')";

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

            string strSql = "UPDATE Cliente SET nomeCliente='" + nome +
                "', enderecoCliente= '" + endereco + "', numeroCliente= '" + numero + "' , telefoneCliente= '" + telefone + "', cpfCliente= '" + cpf + "' where idCliente= '" + id + "'";

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

          
            string strSql = "select idCliente as 'Id Cliente', nomeCliente as Nome, enderecoCliente as 'Endereço', numeroCliente as Numero, telefoneCliente as Telefone, cpfCliente as CPF  from Cliente";


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
        public DataTable PesquisarCodigo(string codigo)
        {

            try
            {


                comando = new MySqlCommand("select idCliente as 'Id Cliente', nomeCliente as Nome, enderecoCliente as 'Endereço', numeroCliente as Numero, telefoneCliente as Telefone, cpfCliente as CPF from Cliente where idCliente LIKE'%'  @cod_cliente '%' ORDER BY idCliente", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@cod_cliente", codigo);

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
        public bool VerificarCpf(string cpfCliente)
        {


            string vericadora = "select Count(1) from Cliente where cpfCliente='" + cpfCliente + "' ";
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
        public DataTable PesquisarCpf(string cpf)
        {

            try
            {


                comando = new MySqlCommand("select idCliente as 'Id Cliente', nomeCliente as Nome, enderecoCliente as 'Endereço', numeroCliente as Numero, telefoneCliente as Telefone, cpfCliente as CPF from Cliente where cpfCliente LIKE'%'  @cpf_cliente '%' ORDER BY cpfCliente", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@cpf_cliente", cpf);

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
        public DataTable PesquisarNome(string nome)
        {

            try
            {


                comando = new MySqlCommand("select idCliente as 'Id Cliente', nomeCliente as Nome, enderecoCliente as 'Endereço', numeroCliente as Numero, telefoneCliente as Telefone, cpfCliente as CPF from Cliente where nomeCliente LIKE'%'  @nome_cliente '%' ORDER BY nomeCliente", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@nome_cliente", nome);

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