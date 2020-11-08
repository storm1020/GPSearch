using GpsCommom.Classes;
using GPSCore;
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
                GPSCore.Service.DbFactory conn = new GPSCore.Service.DbFactory();
                conn.SalvarEmpresa(emVM);
            }
            catch (Exception ex)
            {
                emVM.Resultado.Erro = true;
                emVM.Resultado.Mensagem = ex.Message;
            }

            return Json(emVM, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PesquisarApi(EmpresaVM emVM)
        {
            try
            {
                //criar metodo no core
                var teste = emVM;
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