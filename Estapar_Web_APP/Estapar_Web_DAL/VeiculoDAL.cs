using Estapar_Web_DataAcess;
using Estapar_Web_DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estapar_Web_DAL
{
    public class VeiculoDAL
    {
        public static List<Veiculo> Listar(Veiculo veiculo)
        {
            try
            {
                String strQuery = "SELECT NM_MARCA, NM_PLACA, NM_MODELO"
                + " FROM T_VEICULO "
                + " WHERE (NM_MARCA LIKE"
                + " '%" + veiculo.marca + "%' OR"
                + " '" + veiculo.marca + "' = '' OR"
                + " '" + veiculo.marca + "' = null)"
                + " AND (NM_PLACA like "
                + " '%" + veiculo.placa + "%' OR"
                + " '" + veiculo.placa + "' = '' OR"
                + " '" + veiculo.placa + "' = null) "
                + " AND (NM_MODELO like "
                + " '%" + veiculo.modelo + "%' OR"
                + " '" + veiculo.modelo + "' = '' OR"
                + " '" + veiculo.modelo + "' = null) AND FL_EXCLUIDO = 0"
                + " ORDER BY NM_MARCA,  NM_MODELO, NM_PLACA ";

                Conexao Dados = new Conexao();
                SqlDataReader retornoReader = Dados.RetornoReader(strQuery);

                Veiculo obj = null;
                List<Veiculo> listveiculo = new List<Veiculo>();

                while (retornoReader.Read())
                {
                    obj = new Veiculo();

                    obj.marca = retornoReader["NM_MARCA"].ToString();
                    obj.modelo = retornoReader["NM_MODELO"].ToString();
                    obj.placa = retornoReader["NM_PLACA"].ToString();

                    listveiculo.Add(obj);
                }
                return listveiculo;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Veiculo ListarPorPlaca(Veiculo veiculo)
        {
            try
            {
                String strQuery = "SELECT NM_MARCA, NM_PLACA, NM_MODELO"
                + " FROM T_VEICULO "
                + " WHERE (NM_PLACA ="
                + " '" + veiculo.placa + "')";

                Conexao Dados = new Conexao();
                SqlDataReader retornoReader = Dados.RetornoReader(strQuery);

                Veiculo obj = null;

                while (retornoReader.Read())
                {
                    obj = new Veiculo();

                    obj.marca = retornoReader["NM_MARCA"].ToString();
                    obj.modelo = retornoReader["NM_MODELO"].ToString();
                    obj.placa = retornoReader["NM_PLACA"].ToString();
                }
                return obj;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static string Inserir(Veiculo veiculo)
        {
            try
            {
                string retorno = string.Empty;
                Conexao dados = new Conexao();

                String strQueryCheck = "SELECT NM_PLACA, FL_EXCLUIDO"
                + " FROM T_VEICULO "
                + " WHERE (NM_PLACA ="
                + " '" + veiculo.placa + "' )";

                SqlDataReader retornoReader = dados.RetornoReader(strQueryCheck);
                Veiculo obj = null;
                while (retornoReader.Read())
                {
                    obj = new Veiculo();
                    obj.placa = retornoReader["NM_PLACA"].ToString(); 
                    obj.marca = retornoReader["FL_EXCLUIDO"].ToString();
                    if (obj.marca == "1")
                    {
                        retorno = "Placa ja cadastrada, veiculo atualizado e reativado.";
                    }
                    else
                    {
                        retorno = "Placa ja cadastrada, veiculo atualizado.";
                    }
                }
                if (obj == null)
                {
                    StringBuilder strQuery = new StringBuilder();
                    strQuery.Append("INSERT INTO T_VEICULO ");
                    strQuery.Append("(");
                    strQuery.Append(" NM_PLACA, ");
                    strQuery.Append(" NM_MARCA,");
                    strQuery.Append(" NM_MODELO ) Values (");
                    strQuery.Append("'" + veiculo.placa + "',");
                    strQuery.Append("'" + veiculo.marca + "',");
                    strQuery.Append("'" + veiculo.modelo + "')");

                    dados.ExecutarComando(strQuery);
                    retorno = "Veiculo cadastrado com sucesso.";
                }
                else
                {
                    StringBuilder strQuery = new StringBuilder();
                    strQuery.Append("UPDATE T_VEICULO");
                    strQuery.Append(" SET ");
                    strQuery.Append(" NM_MARCA = ");
                    strQuery.Append("'" + veiculo.marca + "', ");
                    strQuery.Append(" NM_MODELO = ");
                    strQuery.Append("'" + veiculo.modelo + "', ");
                    strQuery.Append(" FL_EXCLUIDO = ");
                    strQuery.Append("'0' ");
                    strQuery.Append(" WHERE NM_PLACA = ");
                    strQuery.Append("'" + veiculo.placa + "'");

                    dados.ExecutarComando(strQuery);
                }
                return retorno;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Editar(Veiculo veiculo)
        {
            try
            {
                Conexao dados = new Conexao();

                StringBuilder strQuery = new StringBuilder();
                strQuery.Append("UPDATE T_VEICULO ");
                strQuery.Append("SET ");
                strQuery.Append(" NM_MARCA = ");
                strQuery.Append("'" + veiculo.marca + "',");
                strQuery.Append(" NM_MODELO = ");
                strQuery.Append("'" + veiculo.modelo + "'");
                strQuery.Append(" WHERE NM_PLACA = ");
                strQuery.Append("'" + veiculo.placa + "'");

                dados.ExecutarComando(strQuery);
                return "Veiculo atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Excluir(Veiculo veiculo)
        {
            try
            {
                Conexao dados = new Conexao();

                StringBuilder strQuery = new StringBuilder();
                strQuery.Append("UPDATE T_VEICULO ");
                strQuery.Append(" SET ");
                strQuery.Append(" FL_EXCLUIDO = 1 ");
                strQuery.Append(" WHERE NM_PLACA = ");
                strQuery.Append("'" + veiculo.placa + "'");

                dados.ExecutarComando(strQuery);
                return "Veiculo excluido com sucesso";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
