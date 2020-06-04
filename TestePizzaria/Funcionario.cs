using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace PizzariaWinForm
{
    class Funcionario
    {
        private string usuario;
        private string senha;
        private string nomeFuncionario;
        private string enderecoFuncionario;
        private int numeroFuncionario;
        private string cpfFuncionario;
        private string cargoFuncionario;
        private string telefoneFuncionario;
        private int codFuncionario;
        private DataGridView dados;
        private string armazenaUsuario;
        private Label lblTotoal;
        public Label Lbltotal
        {
            get { return lblTotoal; }
            set { lblTotoal = value; }
        }
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        public string NomeFuncionario
        {
            get { return nomeFuncionario; }
            set { nomeFuncionario = value; }
        }
        public string CpfFuncionario
        {
            get { return cpfFuncionario; }
            set { cpfFuncionario = value; }
        }
        public string CargoFuncionario
        {
            get { return cargoFuncionario; }
            set { cargoFuncionario = value; }
        }
        public string TelefoneFuncionario
        {
            get { return telefoneFuncionario; }
            set { telefoneFuncionario = value; }
        }
        public string EnderecoFuncionario
        {
            get { return enderecoFuncionario; }
            set { enderecoFuncionario = value; }
        }
        public int CodFuncionario
        {
            get { return codFuncionario; }
            set { codFuncionario = value; }
        }
        public int NumeroFuncionario
        {
            get { return numeroFuncionario; }
            set { numeroFuncionario = value; }
        }
        public DataGridView Dados
        {

            get { return dados; }
            set { dados = value; }
        }
        public string ArmzenaUsuario
        {
            get { return armazenaUsuario; }
            set { armazenaUsuario = value; }
        }

        MySqlCommand comando = new MySqlCommand();
        dbConc conexao = new dbConc();
        



        public bool VerificaoFuncioanrio(string login, string password )
        {
            dbConc conex = new dbConc();
            try
            {

              

                comando.Connection = conex.AbrirBanco();
                comando.CommandText = "select *from Funcionario where loginFuncionario= '" + login + "' and senhaFuncionario= '" + password + "' ";
                comando.CommandType = CommandType.Text;

                MySqlDataReader leitura = comando.ExecuteReader();

                if (leitura.HasRows)
                {
                    while (leitura.Read())
                    {

                        string resultado = (string)leitura["cargoFuncionario"].ToString();
                        string resultado1 = (string)leitura["nomeFuncionario"].ToString();
                        frmMenu menu = new frmMenu();
                        menu.RecebendoValorLogin(resultado1, resultado);
                        menu.Show();
                        
                        
                    }
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
                conex.FecharBanco(conex.AbrirBanco());
                conex = null;
            }

        }
      


        public void PreencherText(string cargo, string usuario, string nome)
        {


            //string strPtext = "select *from Funcionario where loginFuncionario='" + "aoki" + "'";

            string strPtext = "select *from Funcionario where loginFuncionario='" + usuario + "'";
            try
            {

                comando = new MySqlCommand(strPtext, conexao.AbrirBanco());
                comando.ExecuteNonQuery();
                MySqlDataReader dr;
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string resultado = (string)dr["cargoFuncionario"].ToString();
                    cargo = resultado;


                }
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
        public void Excluir()
        {
            string strSql = "DELETE FROM Funcionario where codFuncionario='" + codFuncionario + "' ";
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
        public void Cadastrar()
        {


            string strSql = "INSERT INTO Funcionario (nomeFuncionario, enderecoFuncionario, numeroFuncionario ,loginFuncionario, senhaFuncionario, cpfFuncionario, cargoFuncionario, telefoneFuncionario) " +
                   "VALUES ('" + nomeFuncionario + "','" + enderecoFuncionario + "','" + numeroFuncionario + "' ,'" + usuario + "' , '" + senha + "', '" + cpfFuncionario + "','" + cargoFuncionario + "','" + telefoneFuncionario + "')";

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
        public bool VerificarUsuario( string usuario)
        {


            string vericadora = "select Count(1) from Funcionario where loginFuncionario='" + usuario + "' ";
            try
            {

                comando = new MySqlCommand(vericadora, conexao.AbrirBanco());
                var resultado = comando.ExecuteScalar();
                if (resultado.ToString() != "0" )
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
        public void Alterar()
        {

            string strSql = "UPDATE Funcionario SET nomeFuncionario='" + nomeFuncionario +
                "', enderecoFuncionario= '" + enderecoFuncionario + "', numeroFuncionario= '" + numeroFuncionario + "' , loginFuncionario= '" + usuario + "', senhaFuncionario= '" + senha + "', cpfFuncionario= '" + cpfFuncionario + "', cargoFuncionario= '" + cargoFuncionario + "', telefoneFuncionario= '" + telefoneFuncionario + "' where codFuncionario= '" + codFuncionario + "'";

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
            string strSql = "select codFuncionario as 'Id Funcionario',  nomeFuncionario as 'Nome' , enderecoFuncionario as 'Endereço', numeroFuncionario as 'Numero'  ,loginFuncionario as 'Login', senhaFuncionario as 'senha', cpfFuncionario as 'CPF', cargoFuncionario as 'Cargo', telefoneFuncionario as 'Telefone' from Funcionario";


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


                comando = new MySqlCommand("select codFuncionario as 'Id Funcionario',  nomeFuncionario as 'Nome' , enderecoFuncionario as 'Endereço', numeroFuncionario as 'Numero'  ,loginFuncionario as 'Login', senhaFuncionario as 'senha', cpfFuncionario as 'CPF', cargoFuncionario as 'Cargo', telefoneFuncionario as 'Telefone' from Funcionario where codFuncionario LIKE'%'  @codFuncionario '%' ORDER BY codFuncionario", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@codFuncionario", codigo);

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
        public DataTable PesquisarCpf(string cpf)
        {

            try
            {


                comando = new MySqlCommand("select codFuncionario as 'Id Funcionario',  nomeFuncionario as 'Nome' , enderecoFuncionario as 'Endereço', numeroFuncionario as 'Numero'  ,loginFuncionario as 'Login', senhaFuncionario as 'senha', cpfFuncionario as 'CPF', cargoFuncionario as 'Cargo', telefoneFuncionario as 'Telefone' from Funcionario where cpfFuncionario LIKE'%'  @cpf '%' ORDER BY cpfFuncionario", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@cpf", cpf);

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


                comando = new MySqlCommand("select codFuncionario as 'Id Funcionario',  nomeFuncionario as 'Nome' , enderecoFuncionario as 'Endereço', numeroFuncionario as 'Numero'  ,loginFuncionario as 'Login', senhaFuncionario as 'senha', cpfFuncionario as 'CPF', cargoFuncionario as 'Cargo', telefoneFuncionario as 'Telefone' from Funcionario Funcionario where nomeFuncionario LIKE'%'  @nomeFuncionario '%' ORDER BY nomeFuncionario", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@nomeFuncionario", nome);

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
        public DataTable PesquisarCargo(string cargo)
        {

            try
            {


                comando = new MySqlCommand("select codFuncionario as 'Id Funcionario',  nomeFuncionario as 'Nome' , enderecoFuncionario as 'Endereço', numeroFuncionario as 'Numero'  ,loginFuncionario as 'Login', senhaFuncionario as 'senha', cpfFuncionario as 'CPF', cargoFuncionario as 'Cargo', telefoneFuncionario as 'Telefone' from Funcionario Funcionario where cargoFuncionario LIKE'%'  @cargo '%' ORDER BY cargoFuncionario", conexao.AbrirBanco());
                comando.Parameters.AddWithValue("@cargo", cargo);

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
