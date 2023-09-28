using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.WEB.Model;
using WorkFlow.Utilitarios;

namespace WEBApp.Controllers
{
    public class UsuarioController : Controller
    {

        UsuarioWorkFlow wf = new UsuarioWorkFlow();
        // GET: Usuario
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
        public JsonResult GravarUsuario(UsuarioEntity _Usuario)
        {
            string sRetorno = wf.GravarUsuario(_Usuario);

            return Json(new
            {
                retorno = sRetorno
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListaDados()
        {
            List<UsuarioEntity> lsUsuario = new List<UsuarioEntity>();

            lsUsuario = wf.ListaDados();

            return Json(new
            {
                lsUsuario = lsUsuario
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExcluirUsuario(int pesid)
        {
            string sRetorno = wf.ExcluirUsuario(pesid);

            return Json(new
            {
                retorno = sRetorno
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUsuarioByID(int pesid)
        {
            UsuarioEntity _Usuario = new UsuarioEntity();
            _Usuario = wf.GetUsuarioByID(pesid);

            return Json(new
            {
                retorno = _Usuario
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult VerificaDocumentoCadastrado(string pesdocfederal)
        {
            
            string retorno = wf.VerificaDocumentoCadastrado(pesdocfederal);

            return Json(new
            {
                retorno = retorno
            }, JsonRequestBehavior.AllowGet);
        }
    }
}