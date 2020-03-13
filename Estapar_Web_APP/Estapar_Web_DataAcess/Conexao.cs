using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;


namespace Estapar_Web_DataAcess

{
    public class Conexao
    {
        string StrConexao = ConfigurationManager.ConnectionStrings["SQLServer2008"].ConnectionString;
        private SqlConnection AbrirBanco()
        {
            SqlConnection cn = new SqlConnection(StrConexao);
            cn.Open();
            return cn;
        }


        public void ExecutarComando(StringBuilder strQuery)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn = AbrirBanco();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strQuery.ToString();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SqlDataReader RetornoReader(string strQuery)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn = AbrirBanco();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = strQuery.ToString();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;
                return cmd.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
