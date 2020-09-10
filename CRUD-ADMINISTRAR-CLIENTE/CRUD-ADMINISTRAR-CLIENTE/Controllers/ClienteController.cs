using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business;

namespace CRUD_ADMINISTRAR_CLIENTE.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        ClienteBS clienteBS = new ClienteBS();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListadoCliente()
        {
            return Json(clienteBS.ListadoCliente(), JsonRequestBehavior.AllowGet);

        }
        public JsonResult RegistrarCliente(ClienteE clienteE)
        {
            return Json(clienteBS.RegistrarCliente(clienteE), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ActualizarCliente(ClienteE clienteE)
        {
            return Json(clienteBS.ActualizarCliente(clienteE), JsonRequestBehavior.AllowGet);
        }
        public JsonResult EliminarCliente(int ID)
        {
            return Json(clienteBS.EliminarCliente(ID), JsonRequestBehavior.AllowGet);

        }
        public JsonResult ObtenerCliente(int ID)
        {
            var clienteE = clienteBS.ListadoCliente().Find(x => x.id_Cliente.Equals(ID));
            return Json(clienteE, JsonRequestBehavior.AllowGet);
        }
    }
}