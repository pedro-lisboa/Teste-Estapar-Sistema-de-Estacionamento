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
    public class ManobraDAL
    {
        public static List<Manobra> Listar(Manobra manobra)
        {
            try
            {
                String strQuery = "SELECT MV.ID_MANOBRST_VEICULO, MV.NM_CPF, MV.NM_PLACA, MV.DT_MANOBRA, M.NM_NOME, M.DT_NASC, V.NM_MARCA, V.NM_MODELO, MV.DT_TERMINO_MANOBRA"
                + " FROM T_MANOBRISTA_VEICULO MV "
                + " INNER JOIN T_MANOBRISTA M ON MV.NM_CPF = M.NM_CPF"
                + " INNER JOIN T_VEICULO V ON MV.NM_PLACA = V.NM_PLACA"
                + " WHERE (M.NM_NOME LIKE"
                + " '%" + manobra.manobrista.nome + "%' OR"
                + " '" + manobra.manobrista.nome + "' = '' OR"
                + " '" + manobra.manobrista.nome + "' = null)"
                + " AND (V.NM_PLACA like "
                + " '%" + manobra.veiculo.placa + "%' OR"
                + " '" + manobra.veiculo.placa + "' = '' OR"
                + " '" + manobra.veiculo.placa + "' = null) "
                + " AND (V.NM_MARCA like "
                + " '%" + manobra.veiculo.marca + "%' OR"
                + " '" + manobra.veiculo.marca + "' = '' OR"
                + " '" + manobra.veiculo.marca + "' = null) "
                + " AND (V.NM_MODELO like "
                + " '%" + manobra.veiculo.modelo + "%' OR"
                + " '" + manobra.veiculo.modelo + "' = '' OR"
                + " '" + manobra.veiculo.modelo + "' = null) "
                + " ORDER BY MV.DT_MANOBRA DESC, MV.DT_TERMINO_MANOBRA,  MV.NM_PLACA ";

                Conexao Dados = new Conexao();
                SqlDataReader retornoReader = Dados.RetornoReader(strQuery);

                Manobra obj = null;
                List<Manobra> listmanobra = new List<Manobra>();

                while (retornoReader.Read())
                {
                    obj = new Manobra();
                    obj.veiculo = new Veiculo();
                    obj.manobrista = new Manobrista();

                    obj.veiculo.marca = retornoReader["NM_MARCA"].ToString();
                    obj.veiculo.modelo = retornoReader["NM_MODELO"].ToString();
                    obj.veiculo.placa = retornoReader["NM_PLACA"].ToString();
                    obj.manobrista.nome = retornoReader["NM_NOME"].ToString();
                    obj.manobrista.cpf = retornoReader["NM_CPF"].ToString();
                    obj.manobrista.dataNasc = retornoReader["DT_NASC"].ToString(); 
                    obj.data = retornoReader["DT_MANOBRA"].ToString(); 
                    obj.dataTerm = retornoReader["DT_TERMINO_MANOBRA"].ToString();
                    obj.id = int.Parse(retornoReader["ID_MANOBRST_VEICULO"].ToString());

                    listmanobra.Add(obj);
                }
                return listmanobra;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Manobrista> ListarAllManobristas()
        {
            try
            {
                String strQuery = "SELECT M.NM_CPF, M.NM_NOME, M.DT_NASC"
                + " FROM T_MANOBRISTA M "
                + " WHERE M.FL_EXCLUIDO = 0 ";

                Conexao Dados = new Conexao();
                SqlDataReader retornoReader = Dados.RetornoReader(strQuery);

                Manobrista obj = null;
                List<Manobrista> listmanobrista = new List<Manobrista>();

                while (retornoReader.Read())
                {
                    obj = new Manobrista();

                    obj.nome = retornoReader["NM_NOME"].ToString();
                    obj.cpf = retornoReader["NM_CPF"].ToString();
                    obj.dataNasc = retornoReader["DT_NASC"].ToString();

                    listmanobrista.Add(obj);
                }
                return listmanobrista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Veiculo> ListarAllVeiculos()
        {
            try
            {
                //query comentada pois não funciona no sql server 2008
                //String strQuery = "SELECT V.NM_PLACA,  CONCAT(V.NM_PLACA ,' - ' , V.NM_MARCA , ' - ' , V.NM_MODELO) AS NM_MODELO"
                String strQuery = "SELECT V.NM_PLACA,  { fn CONCAT({ fn CONCAT({ fn CONCAT({ fn CONCAT(V.NM_PLACA ,' - ' )},V.NM_MARCA)},' - ')}, V.NM_MODELO)} AS NM_MODELO"
                + " FROM T_VEICULO V "
                + " WHERE (V.FL_EXCLUIDO = 0) ";

                Conexao Dados = new Conexao();
                SqlDataReader retornoReader = Dados.RetornoReader(strQuery);

                Veiculo obj = null;
                List<Veiculo> listveiculos = new List<Veiculo>();

                while (retornoReader.Read())
                {
                    obj = new Veiculo();

                    obj.placa = retornoReader["NM_PLACA"].ToString();
                    obj.modelo = retornoReader["NM_MODELO"].ToString();

                    listveiculos.Add(obj);
                }
                return listveiculos;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static Manobra ListarPorId(Manobra manobra)
        {
            try
            {
                String strQuery = "SELECT MV.ID_MANOBRST_VEICULO, MV.DT_TERMINO_MANOBRA, MV.NM_CPF, MV.NM_PLACA, MV.DT_MANOBRA, M.NM_NOME, M.DT_NASC, V.NM_MARCA, V.NM_MODELO"
                + " FROM T_MANOBRISTA_VEICULO MV "
                + " INNER JOIN T_MANOBRISTA M ON MV.NM_CPF = M.NM_CPF"
                + " INNER JOIN T_VEICULO V ON MV.NM_PLACA = V.NM_PLACA"
                + " WHERE (MV.ID_MANOBRST_VEICULO = "
                + " '" + manobra.id + "')";

                Conexao Dados = new Conexao();
                SqlDataReader retornoReader = Dados.RetornoReader(strQuery);

                Manobra obj = null;

                while (retornoReader.Read())
                {
                    obj = new Manobra();
                    obj.veiculo = new Veiculo();
                    obj.manobrista = new Manobrista();
                    obj.veiculo.marca = retornoReader["NM_MARCA"].ToString();
                    obj.veiculo.modelo = retornoReader["NM_MODELO"].ToString();
                    obj.veiculo.placa = retornoReader["NM_PLACA"].ToString();
                    obj.manobrista.nome = retornoReader["NM_NOME"].ToString();
                    obj.manobrista.cpf = retornoReader["NM_CPF"].ToString();
                    obj.manobrista.dataNasc = retornoReader["DT_NASC"].ToString();
                    obj.data = retornoReader["DT_MANOBRA"].ToString();
                    obj.dataTerm = retornoReader["DT_TERMINO_MANOBRA"].ToString();
                    obj.id = int.Parse(retornoReader["ID_MANOBRST_VEICULO"].ToString());
                }
                return obj;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static string Inserir(Manobra manobra)
        {
            try
            {
                Conexao dados = new Conexao();
                string retorno = string.Empty;
                String strQueryCheck = "SELECT COUNT(*) AS RETORNO"
                + " FROM T_MANOBRISTA_VEICULO "
                + " WHERE (NM_PLACA ="
                + " '" + manobra.veiculo.placa + "' )"
                + " AND (DT_TERMINO_MANOBRA  IS NULL)";

                SqlDataReader retornoReader = dados.RetornoReader(strQueryCheck);
                while (retornoReader.Read())
                {
                    retorno = retornoReader["RETORNO"].ToString();
                    if (retorno != "0")
                    {
                        return "Existe uma Manobra nao terminada para este Veiculo!";
                    }
                }
                manobra.data = System.DateTime.Now.ToString();
                StringBuilder strQuery = new StringBuilder();
                strQuery.Append("INSERT INTO T_MANOBRISTA_VEICULO ");
                strQuery.Append("(");
                strQuery.Append(" NM_PLACA, ");
                strQuery.Append(" NM_CPF,");
                strQuery.Append(" DT_MANOBRA ) Values (");
                strQuery.Append("'" + manobra.veiculo.placa + "',");
                strQuery.Append("'" + manobra.manobrista.cpf + "',");
                strQuery.Append("CONVERT(datetime,'" + manobra.data + "',103))");

                dados.ExecutarComando(strQuery);
                return "Manobra cadastrada com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Editar(Manobra manobra)
        {
            try
            {
                Conexao dados = new Conexao();

                StringBuilder strQuery = new StringBuilder();
                strQuery.Append("UPDATE T_MANOBRISTA_VEICULO ");
                strQuery.Append("SET ");
                strQuery.Append(" NM_CPF = ");
                strQuery.Append("'" + manobra.manobrista.cpf + "',");
                strQuery.Append(" NM_PLACA = ");
                strQuery.Append("'" + manobra.veiculo.placa + "'");
                strQuery.Append(" WHERE ID_MANOBRST_VEICULO = ");
                strQuery.Append("'" + manobra.id + "'");

                dados.ExecutarComando(strQuery);
                return "Registro de manobra atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Excluir(Manobra manobra)
        {
            try
            {
                Conexao dados = new Conexao();
                String strQueryCheck = "SELECT MV.NM_CPF, M.NM_NOME, MV.DT_MANOBRA, MV.DT_TERMINO_MANOBRA, MV.NM_PLACA, V.NM_MARCA, V.NM_MODELO"
                + " FROM T_MANOBRISTA_VEICULO MV "
                + " INNER JOIN T_MANOBRISTA M ON MV.NM_CPF = M.NM_CPF"
                + " INNER JOIN T_VEICULO V ON MV.NM_PLACA = V.NM_PLACA"
                + " WHERE MV.ID_MANOBRST_VEICULO ="
                + " '" + manobra.id + "'";

                SqlDataReader retornoReader = dados.RetornoReader(strQueryCheck);
                string retorno = string.Empty;
                while (retornoReader.Read())
                {
                    retorno = "Manobra feita pelo CPF " + retornoReader["NM_CPF"].ToString()
                        + " de Nome " + retornoReader["NM_NOME"].ToString()
                        + " para o veiculo Modelo " + retornoReader["NM_MODELO"].ToString()
                        + " e Marca " + retornoReader["NM_MARCA"].ToString()
                        + " e Placa " + retornoReader["NM_PLACA"].ToString()
                        + " no dia " + retornoReader["DT_MANOBRA"].ToString();
                    if(retornoReader["DT_TERMINO_MANOBRA"].ToString() != "")
                    {
                        retorno = retorno + " com termino no dia " + retornoReader["DT_TERMINO_MANOBRA"].ToString();
                    }
                    retorno = retorno + " foi EXCLUIDA! ";
                }
                StringBuilder strQuery = new StringBuilder();
                strQuery.Append("DELETE FROM T_MANOBRISTA_VEICULO ");
                strQuery.Append(" WHERE ID_MANOBRST_VEICULO = ");
                strQuery.Append("'" + manobra.id + "'");

                dados.ExecutarComando(strQuery);

                strQuery = new StringBuilder();
                strQuery.Append("INSERT INTO T_LOG ");
                strQuery.Append(" VALUES(");
                strQuery.Append("CONVERT(datetime, '" + System.DateTime.Now.ToString() + "', 103),");
                strQuery.Append("'" + retorno + "')");

                dados.ExecutarComando(strQuery);
                return "Manobra excluida com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string Terminar(Manobra manobra)
        {
            try
            {
                Conexao dados = new Conexao();

                StringBuilder strQuery = new StringBuilder();
                strQuery.Append("UPDATE T_MANOBRISTA_VEICULO SET DT_TERMINO_MANOBRA = ");
                strQuery.Append(" CONVERT(datetime, '" + System.DateTime.Now.ToString() + "', 103)");
                strQuery.Append(" WHERE ID_MANOBRST_VEICULO = ");
                strQuery.Append("'" + manobra.id + "'");

                dados.ExecutarComando(strQuery);
                return "Manobra Terminada com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
