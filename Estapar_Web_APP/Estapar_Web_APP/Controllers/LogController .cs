using Estapar_Web_BLL;
using Estapar_Web_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estapar_Web_APP.Controllers
{
    public class LogController : Controller
    {
        // GET: Veiculo
        public ActionResult Index(Mensagem retorno, string searchStringData)
        {
            if (retorno.msg != null)
            {
                ViewBag.Alerta = retorno.msg;
            }
            else
            {
                ViewBag.Alerta = string.Empty;
            }
            Log log = new Log();
            if (!String.IsNullOrEmpty(searchStringData)) {
                if (searchStringData.Length != 10)
                {
                    ViewBag.Alerta = "A data deve estar no formato DD/MM/YYYY!";
                }
                else
                {
                    log.data = searchStringData.Substring(8, 2) + "/" + searchStringData.Substring(5, 2) + "/" + searchStringData.Substring(0, 4);
                }
            }
            return View(Listar(log));
        }


        public IEnumerable<Log> Listar(Log log)
        {
            return  LogBLL.Listar(log);
        }
    }
}