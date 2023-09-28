using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.WEB.Model;
using UI.WEB.WorkFlow;
using WorkFlow.Utilitarios;

namespace WEBApp.Controllers
{
    public class LaboratorioController : Controller
    {
        // GET: Laboratorio

        LaboratorioWorkFlow wf = new LaboratorioWorkFlow();
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
        public JsonResult GravarLaboratorio(LaboratorioEntity _Laboratorio)
        {
            string sRetorno = wf.GravarLaboratorio(_Laboratorio);

            return Json(new
            {
                retorno = sRetorno
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaDados()
        {
            List<LaboratorioEntity> lsLaboratorio = new List<LaboratorioEntity>();

            lsLaboratorio = wf.ListaDados();

            return Json(new
            {
                lsLaboratorio = lsLaboratorio
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExcluirLaboratorio(int labid)
        {
            string sRetorno = wf.ExcluirLaboratorio(labid);

            return Json(new
            {
                retorno = sRetorno
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLaboratorioByID(int labid)
        {
            LaboratorioEntity _Laboratorio = new LaboratorioEntity();
            _Laboratorio = wf.GetLaboratorioByID(labid);

            return Json(new
            {
                retorno = _Laboratorio
            }, JsonRequestBehavior.AllowGet);
        }
    }
}