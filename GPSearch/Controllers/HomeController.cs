using GpsCommom.Classes;
using GPSCore;
using GPSCore.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPSearch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public JsonResult Empresa(EmpresaVM emVM)
        {
            try
            {
                DbFactory conn = new DbFactory();
                conn.SalvarEmpresa(emVM);
            }
            catch (Exception ex)
            {
                emVM.Resultado.Erro = true;
                emVM.Resultado.Mensagem = ex.Message;
            }

            return Json(emVM, JsonRequestBehavior.AllowGet);
        }
        public string TrataCnpj(string cnpj)
        {
            if (!string.IsNullOrEmpty(cnpj))
            {
                cnpj = cnpj.Replace("/", "");
                cnpj = cnpj.Replace("-", "");
                cnpj = cnpj.Replace(".", "");
            }

            return cnpj;
        }
        public JsonResult PesquisarApi(string cnpj)
        {
            EmpresaVM emVM = new EmpresaVM();

            try
            {
                DbFactory conn = new DbFactory();
                cnpj = TrataCnpj(cnpj);
                emVM = conn.BuscarPorCnpj(cnpj);
            }
            catch (Exception ex)
            {
                emVM.Resultado.Erro = true;
                emVM.Resultado.Mensagem = ex.Message;
            }

            return Json(emVM, JsonRequestBehavior.AllowGet);
        }
    }
}