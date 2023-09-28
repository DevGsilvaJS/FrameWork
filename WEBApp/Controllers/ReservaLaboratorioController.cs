using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.WEB.Model;
using UI.WEB.WorkFlow;

namespace WEBApp.Controllers
{
    public class ReservaLaboratorioController : Controller
    {
        // GET: ReservaLaboratorio
        ReservaLaboratorioWorkFlow wf = new ReservaLaboratorioWorkFlow();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult RetornaObjInclusao()
        {
            return Json(new
            {
                ObjInclusao = wf.RetornaObjInclusao()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listaLaboratorios()
        {

            return Json(new
            {
                lista = wf.listaLaboratorios()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GravarReservaLaboratorio(ReservaLaboratorioEntity _ReservaLaboratorio)
        {
            string sRetorno = wf.GravarReservaLaboratorio(_ReservaLaboratorio);

            return Json(new
            {
                retorno = sRetorno
            }, JsonRequestBehavior.AllowGet);
        }


    }
}