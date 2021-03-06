﻿using SDRK.COPRODA.Common;
using SDRK.COPRODA.Logica;
using SDRK.COPRODA.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDRK.COPRODA.Controllers
{
    public class UsuarioController : Controller
    {
        Util util = new Util();
        LNUsuario lnUsuario = new LNUsuario();
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CrearUsuario()
        {
            if (Session["TipoUsuario"].ToString() == "Administrador")
            {
                ViewBag.ListaEstados = util.DropDownListaEstados();
                ViewBag.ListaTipoUsuario = util.DropDownTipoUsuario();
                ViewBag.ListaTipoDocumento = util.DropDownTipoDocumento();
                ViewBag.MensajeUsuarioCrear = "";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Inicio");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CrearUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                string Respuesta = "";
                usuario.CreadoPor = Session["Usuario"].ToString();
                usuario.FechaCreacion = DateTime.Now;

                Respuesta = lnUsuario.UsuarioCrear(usuario);

                if (Respuesta == "")
                    return RedirectToAction("Index", "Inicio");
                else
                {
                    ViewBag.MensajeUsuarioCrear = Respuesta;
                    ViewBag.ListaEstados = util.DropDownListaEstados();
                    ViewBag.ListaTipoUsuario = util.DropDownTipoUsuario();
                    ViewBag.ListaTipoDocumento = util.DropDownTipoDocumento();
                    return View();
                }
            }
            else
            {
                ViewBag.ListaEstados = util.DropDownListaEstados();
                ViewBag.ListaTipoUsuario = util.DropDownTipoUsuario();
                ViewBag.ListaTipoDocumento = util.DropDownTipoDocumento();
                return View();
            }
        }
    }
}