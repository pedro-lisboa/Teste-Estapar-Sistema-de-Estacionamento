using Estapar_Web_BLL;
using Estapar_Web_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estapar_Web_APP.Controllers
{
    public class VeiculoController : Controller
    {
        // GET: Veiculo
        public ActionResult Index(Mensagem retorno, string searchStringPlaca, string searchStringMarca, string searchStringModelo)
        {
            if (retorno.msg != null)
            {
                ViewBag.Alerta = retorno.msg;
            }
            else
            {
                ViewBag.Alerta = string.Empty;
            }
            Veiculo veiculo = new Veiculo();
            if (!String.IsNullOrEmpty(searchStringPlaca))
            {
                veiculo.placa = searchStringPlaca.ToUpper();
            }
            if (!String.IsNullOrEmpty(searchStringMarca))
            {
                veiculo.marca = searchStringMarca.ToUpper();
            }
            if (!String.IsNullOrEmpty(searchStringModelo))
            {
                veiculo.modelo = searchStringModelo.ToUpper();
            }
            return View(Listar(veiculo));
        }

        public ActionResult Create()
        {
            ViewBag.Alerta = string.Empty;
            return View();
        }

        public ActionResult Details(string placa)
        {
            Veiculo veiculo = new Veiculo();
            veiculo.placa = placa;
            return View(ListarPorPlaca(veiculo));
        }

        public ActionResult Delete(string placa)
        {
            ViewBag.Alerta = string.Empty;
            Veiculo veiculo = new Veiculo();
            veiculo.placa = placa;
            return View(ListarPorPlaca(veiculo));
        }

        public ActionResult Edit(string placa)
        {
            ViewBag.Alerta = string.Empty;
            Veiculo veiculo = new Veiculo();
            veiculo.placa = placa;
            return View(ListarPorPlaca(veiculo));
        }

        public IEnumerable<Veiculo> Listar(Veiculo veiculo)
        {
            return  VeiculoBLL.Listar(veiculo);
        }
        public Veiculo ListarPorPlaca(Veiculo veiculo)
        {
            return VeiculoBLL.ListarPorPlaca(veiculo);
        }

        [HttpPost]
        public ActionResult Create(Veiculo veiculo)
        {
            try
            {
                ViewBag.Alerta = string.Empty;
                if (veiculo.placa.Length != 7)
                {
                    ViewBag.Alerta = "Placa incorreta, a placa deve ter 7 digitos!";
                }
                if (veiculo.modelo.Length <= 2 || veiculo.modelo.Length > 200)
                {
                    ViewBag.Alerta = "O Modelo deve ter no minimo 2 caracteres e no maximo de 200!";
                }
                if (veiculo.marca.Length <= 2 || veiculo.marca.Length > 200)
                {
                    ViewBag.Alerta = "O Marca deve ter no minimo 2 caracteres e no maximo de 200!";
                }
                if (ViewBag.Alerta == string.Empty)
                {
                    Mensagem retorno = new Mensagem();
                    veiculo.placa = veiculo.placa.ToUpper();
                    veiculo.modelo = veiculo.modelo.ToUpper();
                    veiculo.marca = veiculo.marca.ToUpper();
                    retorno.msg = VeiculoBLL.Inserir(veiculo);
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
        public ActionResult Edit(Veiculo veiculo)
        {
            try
            {
                ViewBag.Alerta = string.Empty;
                if (veiculo.placa.Length != 7)
                {
                    ViewBag.Alerta = "Placa incorreta, a placa deve ter 7 digitos!";
                }
                if (veiculo.modelo.Length <= 2 || veiculo.modelo.Length > 200)
                {
                    ViewBag.Alerta = "O Modelo deve ter no minimo 2 caracteres e no maximo de 200!";
                }
                if (veiculo.marca.Length <= 2 || veiculo.marca.Length > 200)
                {
                    ViewBag.Alerta = "O Marca deve ter no minimo 2 caracteres e no maximo de 200!";
                }
                if (ViewBag.Alerta == string.Empty)
                {
                    Mensagem retorno = new Mensagem();
                    veiculo.modelo = veiculo.modelo.ToUpper();
                    veiculo.marca = veiculo.marca.ToUpper();
                    retorno.msg = VeiculoBLL.Editar(veiculo);
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
        public ActionResult Delete(Veiculo veiculo)
        {
            try
            {
                Mensagem retorno = new Mensagem();
                retorno.msg = VeiculoBLL.Excluir(veiculo);
                return RedirectToAction("Index", retorno);
            }
            catch
            {
                return View();
            }
        }        
    }
}