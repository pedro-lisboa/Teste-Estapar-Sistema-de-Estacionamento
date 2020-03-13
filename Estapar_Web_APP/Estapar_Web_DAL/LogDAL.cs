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
    public class LogDAL
    {
        public static List<Log> Listar(Log log)
        {
            try
            {
                String strQuery = "SELECT DT_LOG, NM_MSG"
                + " FROM T_LOG "
                + " WHERE (CONVERT(date,DT_LOG,103) = "
                + "CONVERT(date,'" + log.data + "',103) OR '" 
                + log.data + "' = '' OR '" 
                + log.data + "' IS NULL)"
                + " ORDER BY DT_LOG DESC";

                Conexao Dados = new Conexao();
                SqlDataReader retornoReader = Dados.RetornoReader(strQuery);

                Log obj = null;
                List<Log> listlog = new List<Log>();

                while (retornoReader.Read())
                {
                    obj = new Log();

                    obj.data = retornoReader["DT_LOG"].ToString();
                    obj.msg = retornoReader["NM_MSG"].ToString();

                    listlog.Add(obj);
                }
                return listlog;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
