using Estapar_Web_BLL;
using Estapar_Web_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estapar_Web_APP.Controllers
{
    public class ManobraController : Controller
    {
        // GET: Manobra
        public ActionResult Index(Mensagem retorno)
        {
            if (retorno.msg != null)
            {
                ViewBag.Alerta = retorno.msg;
            }
            else
            {
                ViewBag.Alerta = string.Empty;
            }
            Manobra manobra = new Manobra();
            manobra.manobrista = new Manobrista();
            manobra.veiculo = new Veiculo();
            TempData["Veiculos"] = ListarAllVeiculos();
            TempData["Manobristas"] = ListarAllManobristas();

            return View(Listar(manobra));
        }

        public ActionResult Create()
        {
            ViewBag.Alerta = string.Empty;
            ViewBag.Manobristas = new SelectList(ListarAllManobristas(), "cpf", "nome");
            ViewBag.Veiculos = new SelectList(ListarAllVeiculos(), "placa", "modelo");

            return View();
        }

        public ActionResult Details(string id)
        {
            Manobra manobra = new Manobra();
            manobra.id = Int32.Parse(id);
            return View(ListarPorId(manobra));
        }

        public ActionResult Delete(string id)
        {
            ViewBag.Alerta = string.Empty;
            Manobra manobra = new Manobra();
            manobra.id = Int32.Parse(id);
            return View(ListarPorId(manobra));
        }

        public ActionResult Edit(string id)
        {
            ViewBag.Alerta = string.Empty;
            ViewBag.Manobristas = new SelectList(ListarAllManobristas(), "cpf", "nome");
            ViewBag.Veiculos = new SelectList(ListarAllVeiculos(), "placa", "modelo");
            Manobra manobra = new Manobra();
            manobra.id = Int32.Parse(id);
            return View(ListarPorId(manobra));
        }
        public ActionResult Terminate(string id)
        {
            ViewBag.Alerta = string.Empty;
            Manobra manobra = new Manobra();
            manobra.id = Int32.Parse(id);
            return View(ListarPorId(manobra));
        }

        [HttpGet]
        public IEnumerable<Manobra> Listar(Manobra manobra)
        {
            return ManobraBLL.Listar(manobra);
        }
        public List<Manobrista> ListarAllManobristas()
        {
            return ManobraBLL.ListarAllManobristas();
        }
        public List<Veiculo> ListarAllVeiculos()
        {
            return ManobraBLL.ListarAllVeiculos();
        }
        public Manobra ListarPorId(Manobra manobra)
        {
            return ManobraBLL.ListarPorId(manobra);
        }

        [HttpPost]
        public ActionResult Create(Manobra manobra)
        {
            try
            {
                ViewBag.Alerta = string.Empty;
                if (manobra.manobrista == new Manobrista())
                {
                    ViewBag.Alerta = "Selecione um Manobrista!";
                }
                if (manobra.veiculo == new Veiculo())
                {
                    ViewBag.Alerta = "Selecione um Veiculo!";
                } 
                if (ViewBag.Alerta == string.Empty)
                {
                    Mensagem retorno = new Mensagem();
                    retorno.msg = ManobraBLL.Inserir(manobra);
                    return RedirectToAction("Index", retorno);
                }
                else
                {
                    Mensagem retorno = new Mensagem();
                    retorno.msg = ManobraBLL.Inserir(manobra);
                    return RedirectToAction("Index", retorno);
                    //return View();
                }
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(Manobra manobra)
        {
            try
            {
                ViewBag.Alerta = string.Empty;
                if (manobra.manobrista != new Manobrista())
                {
                    ViewBag.Alerta = "Selecione um Manobrista!";
                }
                if (manobra.veiculo != new Veiculo())
                {
                    ViewBag.Alerta = "Selecione um Veiculo!";
                }
                if (ViewBag.Alerta == string.Empty)
                {
                    Mensagem retorno = new Mensagem();
                    retorno.msg = ManobraBLL.Editar(manobra);
                    return RedirectToAction("Index", retorno);
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Delete(Manobra manobra)
        {
            try
            {
                Mensagem retorno = new Mensagem();
                retorno.msg = ManobraBLL.Excluir(manobra);
                return RedirectToAction("Index", retorno);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Terminate(Manobra manobra)
        {
            try
            {
                Mensagem retorno = new Mensagem();
                retorno.msg = ManobraBLL.Terminar(manobra);
                return RedirectToAction("Index", retorno);
            }
            catch
            {
                return View();
            }
        }

    }
}