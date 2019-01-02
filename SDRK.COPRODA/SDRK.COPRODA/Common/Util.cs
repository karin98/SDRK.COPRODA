using SDRK.COPRODA.Logica;
using SDRK.COPRODA.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDRK.COPRODA.Common
{
    public class Util
    {
        LNPedido lnPedido = new LNPedido();
        LNCliente lnCliente = new LNCliente();

        public List<SelectListItem> DropDownListaEstados()
        {
            List<SelectListItem> listItemsResultado = new List<SelectListItem>();

            SelectListItem itemActivo = new SelectListItem();
            itemActivo.Text = "Activo";
            itemActivo.Value = "Activo";

            SelectListItem itemInactivo = new SelectListItem();
            itemInactivo.Text = "Inactivo";
            itemInactivo.Value = "Inactivo";

            listItemsResultado.Add(itemActivo);
            listItemsResultado.Add(itemInactivo);

            return listItemsResultado;
        }

        public List<SelectListItem> DropDownTipoUsuario()
        {
            List<SelectListItem> listItemsResultado = new List<SelectListItem>();

            SelectListItem itemAdministrador = new SelectListItem();
            itemAdministrador.Text = "Administrador";
            itemAdministrador.Value = "Administrador";

            SelectListItem itemVendedor = new SelectListItem();
            itemVendedor.Text = "Vendedor";
            itemVendedor.Value = "Vendedor";

            listItemsResultado.Add(itemAdministrador);
            listItemsResultado.Add(itemVendedor);

            return listItemsResultado;
        }

        public List<SelectListItem> DropDownTipoTransaccion()
        {
            List<TipoTransaccion> origenDatos = lnPedido.TipoTransaccionLeer();
            List<SelectListItem> listItemsResultado = new List<SelectListItem>();

            foreach (TipoTransaccion tipoTransaccion in origenDatos)
            {
                SelectListItem item = new SelectListItem();
                item.Text = tipoTransaccion.TipoTransaccionValor;
                item.Value = tipoTransaccion.IdTipoTransaccion;
                listItemsResultado.Add(item);
            }
            return listItemsResultado;
        }

        public List<SelectListItem> DropDownTipoDocumento()
        {
            List<TipoDocumento> origenDatos = lnCliente.TipoDocumentoLeer();
            List<SelectListItem> listItemsResultado = new List<SelectListItem>();

            foreach (TipoDocumento tipoDocumento in origenDatos)
            {
                SelectListItem item = new SelectListItem();
                item.Text = tipoDocumento.TipoDocumentoValor;
                item.Value = tipoDocumento.IdTipoDocumento;
                listItemsResultado.Add(item);
            }
            return listItemsResultado;
        }
    }
}