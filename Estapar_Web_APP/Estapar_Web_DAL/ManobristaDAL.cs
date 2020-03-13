using Estapar_Web_DataAcess;
using Estapar_Web_DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Estapar_Web_DAL
{
    public class ManobristaDAL
    {
        public static List<Manobrista> Listar(Manobrista manobrista)
        {
            try
            {
                String strQuery = "SELECT NM_NOME, NM_CPF, DT_NASC"
                + " FROM T_MANOBRISTA "
                + " WHERE (NM_NOME LIKE"
                + " '%" + manobrista.nome + "%' OR"
                + " '" + manobrista.nome + "' = '' OR"
                + " '" + manobrista.nome + "' = null)"
                + " AND (NM_CPF ="
                + " '" + manobrista.cpf + "' OR"
                + " '" + manobrista.cpf + "' = '' OR"
                + " '" + manobrista.cpf + "' = null) AND FL_EXCLUIDO = 0"
                + "ORDER BY NM_NOME, NM_CPF, DT_NASC";

                Conexao Dados = new Conexao();
                SqlDataReader retornoReader = Dados.RetornoReader(strQuery);

                Manobrista obj = null;
                List<Manobrista> listmanobrista = new List<Manobrista>();

                while (retornoReader.Read())
                {
                    obj = new Manobrista();

                    obj.nome = retornoReader["NM_NOME"].ToString();
                    obj.dataNasc = String.Format("{0:d}", (DateTime.Parse(retornoReader["DT_NASC"].ToString())));
                    obj.cpf = retornoReader["NM_CPF"].ToString();

                    listmanobrista.Add(obj);
                }
                return listmanobrista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Manobrista ListarPorCPF(Manobrista manobrista)
        {
            try
            {
                String strQuery = "SELECT NM_NOME, NM_CPF, DT_NASC"
                + " FROM T_MANOBRISTA "
                + " WHERE (NM_CPF ="
                + " '" + manobrista.cpf + "')";

                Conexao Dados = new Conexao();
                SqlDataReader retornoReader = Dados.RetornoReader(strQuery);

                Manobrista obj = null;

                while (retornoReader.Read())
                {
                    obj = new Manobrista();

                    obj.nome = retornoReader["NM_NOME"].ToString();
                    obj.dataNasc = String.Format("{0:d}", (DateTime.Parse(retornoReader["DT_NASC"].ToString())));
                    obj.cpf = retornoReader["NM_CPF"].ToString();
                }
                return obj;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static string Inserir(Manobrista manobrista)
        {
            try
            {
                Conexao dados = new Conexao();
                string retorno = string.Empty;
                String strQueryCheck = "SELECT NM_CPF, FL_EXCLUIDO"
                + " FROM T_MANOBRISTA "
                + " WHERE (NM_CPF ="
                + " '" + manobrista.cpf + "' )";

                SqlDataReader retornoReader = dados.RetornoReader(strQueryCheck);
                Manobrista obj = null;
                while (retornoReader.Read())
                {
                    obj = new Manobrista();
                    obj.cpf = retornoReader["NM_CPF"].ToString();
                    obj.nome = retornoReader["FL_EXCLUIDO"].ToString();
                    if(obj.nome == "1")
                    {
                        retorno = "CPF ja cadastrado, perfil com o CPF atualizado e reativado.";
                    }
                    else
                    {
                        retorno = "CPF ja cadastrado, perfil com o CPF atualizado.";
                    }
                }
                if (obj == null)
                {
                    StringBuilder strQuery = new StringBuilder();
                    strQuery.Append("INSERT INTO T_MANOBRISTA");
                    strQuery.Append("(");
                    strQuery.Append(" NM_CPF, ");
                    strQuery.Append(" NM_NOME,");
                    strQuery.Append(" DT_NASC ) Values (");
                    strQuery.Append("'" + manobrista.cpf + "',");
                    strQuery.Append("'" + manobrista.nome + "',");
                    strQuery.Append("CONVERT(date,'" + manobrista.dataNasc + "',103))");

                    dados.ExecutarComando(strQuery);
                    retorno = "Registro cadastrado com sucesso!";
                }
                else
                {
                    StringBuilder strQuery = new StringBuilder();
                    strQuery.Append("UPDATE T_MANOBRISTA");
                    strQuery.Append(" SET ");
                    strQuery.Append(" NM_NOME = ");
                    strQuery.Append("'" + manobrista.nome + "', ");
                    strQuery.Append(" DT_NASC = ");
                    strQuery.Append("CONVERT(date,'" + manobrista.dataNasc + "',103), ");
                    strQuery.Append(" FL_EXCLUIDO = ");
                    strQuery.Append("'0' ");
                    strQuery.Append(" WHERE NM_CPF = ");
                    strQuery.Append("'" + manobrista.cpf + "'");

                    dados.ExecutarComando(strQuery);

                }
                return retorno;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Editar(Manobrista manobrista)
        {
            try
            {
                Conexao dados = new Conexao();

                StringBuilder strQuery = new StringBuilder();
                strQuery.Append("UPDATE T_MANOBRISTA ");
                strQuery.Append(" SET ");
                strQuery.Append(" NM_NOME = ");
                strQuery.Append("'" + manobrista.nome + "',");
                strQuery.Append(" DT_NASC = ");
                strQuery.Append("CONVERT(date,'" + manobrista.dataNasc + "',103)");
                strQuery.Append(" WHERE NM_CPF = ");
                strQuery.Append("'" + manobrista.cpf + "'");

                dados.ExecutarComando(strQuery);
                return "Registro editado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Excluir(Manobrista manobrista)
        {
            try
            {
                Conexao dados = new Conexao();

                StringBuilder strQuery = new StringBuilder();
                strQuery.Append("UPDATE T_MANOBRISTA ");
                strQuery.Append(" SET ");
                strQuery.Append(" FL_EXCLUIDO = 1 ");
                strQuery.Append(" WHERE NM_CPF = ");
                strQuery.Append("'" + manobrista.cpf + "'");

                dados.ExecutarComando(strQuery);
                return "Registro excluido com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
