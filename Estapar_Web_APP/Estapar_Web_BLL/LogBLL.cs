using Estapar_Web_DAL;
using Estapar_Web_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estapar_Web_BLL
{
    public class LogBLL
    {
        public static List<Log> Listar(Log log)
        {
            try
            {
                return LogDAL.Listar(log);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
