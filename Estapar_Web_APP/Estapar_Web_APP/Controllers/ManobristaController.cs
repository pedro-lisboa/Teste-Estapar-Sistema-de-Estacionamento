using Estapar_Web_BLL;
using Estapar_Web_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estapar_Web_APP.Controllers
{
    public class ManobristaController : Controller
    {
        // GET: Manobrista
        public ActionResult Index(Mensagem retorno, string searchStringNome, string searchStringCPF)
        {
            if(retorno.msg != null)
            {
                ViewBag.Alerta = retorno.msg;
            }
            else
            {
                ViewBag.Alerta = string.Empty;
            }
            Manobrista manobrista = new Manobrista();
            if (!String.IsNullOrEmpty(searchStringNome))
            {
                manobrista.nome = searchStringNome.ToUpper();
            }
            if (!String.IsNullOrEmpty(searchStringCPF))
            {
                if (!IsCpf(searchStringCPF))
                {
                    ViewBag.Alerta = "CPF invalido, favor preenche-lo conforme o modelo XXX.XXX.XXX-XX e com uma combinacao valida!";
                    return View();
                }
                manobrista.cpf = searchStringCPF;
            }
            return View(Listar(manobrista));
        }

        public ActionResult Create()
        {
            ViewBag.Alerta = string.Empty;
            return View();
        }

        public ActionResult Details(string cpf)
        {
            Manobrista manobrista = new Manobrista();
            manobrista.cpf = cpf;
            return View(ListarPorCPF(manobrista));
        }

        public ActionResult Delete(string cpf)
        {
            Manobrista manobrista = new Manobrista();
            manobrista.cpf = cpf;
            ViewBag.Alerta = string.Empty;
            return View(ListarPorCPF(manobrista));
        }

        public ActionResult Edit(string cpf)
        {
            Manobrista manobrista = new Manobrista();
            manobrista.cpf = cpf;
            ViewBag.Alerta = string.Empty;
            return View(ListarPorCPF(manobrista));
        }

        public IEnumerable<Manobrista> Listar(Manobrista manobrista)
        {
            return  ManobristaBLL.Listar(manobrista);
        }
        public Manobrista ListarPorCPF(Manobrista manobrista)
        {
            return ManobristaBLL.ListarPorCPF(manobrista);
        }

        [HttpPost]
        public ActionResult Create(Manobrista manobrista)
        {
            try
            {
                ViewBag.Alerta = string.Empty;
                if (manobrista.cpf.Length != 14)
                {
                    ViewBag.Alerta = "CPF incorreto, favor preenche-lo conforme o modelo XXX.XXX.XXX-XX!";
                }
                if (!IsCpf(manobrista.cpf))
                {
                    ViewBag.Alerta = "CPF invalido, favor preenche-lo conforme o modelo XXX.XXX.XXX-XX e com uma combinacao valida!";
                }
                if (manobrista.nome.Length <= 3 || manobrista.nome.Length > 200)
                {
                    ViewBag.Alerta = "O Nome deve ter no minimo 3 caracteres e no maximo de 200!";
                }
                if(manobrista.dataNasc.Length != 10)
                {
                    ViewBag.Alerta = "A data deve estar no formato DD/MM/YYYY!";
                }
                if (ViewBag.Alerta == string.Empty)
                {
                    Mensagem retorno = new Mensagem();
                    manobrista.nome = manobrista.nome.ToUpper();
                    retorno.msg = ManobristaBLL.Inserir(manobrista);
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
        public ActionResult Edit(Manobrista manobrista)
        {
            try
            {
                ViewBag.Alerta = string.Empty;
                if (manobrista.cpf.Length != 14)
                {
                    ViewBag.Alerta = "CPF incorreto, favor preenche-lo conforme o modelo XXX.XXX.XXX-XX!";
                }
                if (!IsCpf(manobrista.cpf))
                {
                    ViewBag.Alerta = "CPF invalido, favor preenche-lo conforme o modelo XXX.XXX.XXX-XX e com uma combinacao valida!";
                }
                if (manobrista.nome.Length <= 3 || manobrista.nome.Length > 200)
                {
                    ViewBag.Alerta = "O Nome deve ter no minimo 3 caracteres e no maximo de 200!";
                }
                if (manobrista.dataNasc.Length != 10)
                {
                    ViewBag.Alerta = "A data deve estar no formato DD/MM/YYYY!";
                }
                if (ViewBag.Alerta == string.Empty)
                {
                    Mensagem retorno = new Mensagem();
                    manobrista.nome = manobrista.nome.ToUpper();
                    retorno.msg =  ManobristaBLL.Editar(manobrista); 
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
        public ActionResult Delete(Manobrista manobrista)
        {
            try
            {
                Mensagem retorno = new Mensagem();
                retorno.msg = ManobristaBLL.Excluir(manobrista);
                return RedirectToAction("Index", retorno);
            }
            catch
            {
                return View();
            }
        }


        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
