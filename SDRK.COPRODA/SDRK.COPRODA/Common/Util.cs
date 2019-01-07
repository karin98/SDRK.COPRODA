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
        LNProducto lnProducto = new LNProducto();

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

        public List<SelectListItem> DropDownListaTipoEntrega()
        {
            List<SelectListItem> listItemsResultado = new List<SelectListItem>();

            SelectListItem itemDomicilio = new SelectListItem();
            itemDomicilio.Text = "Domicilio";
            itemDomicilio.Value = "Domicilio";

            SelectListItem itemOficina = new SelectListItem();
            itemOficina.Text = "Oficina";
            itemOficina.Value = "Oficina";

            listItemsResultado.Add(itemDomicilio);
            listItemsResultado.Add(itemOficina);

            return listItemsResultado;
        }

        public List<SelectListItem> DropDownListaEstadoPedido()
        {
            List<SelectListItem> listItemsResultado = new List<SelectListItem>();

            SelectListItem itemBorrador = new SelectListItem();
            itemBorrador.Text = "Borrador";
            itemBorrador.Value = "Borrador";

            SelectListItem itemEntregado = new SelectListItem();
            itemEntregado.Text = "Entregado";
            itemEntregado.Value = "Entregado";

            SelectListItem itemSolicitado = new SelectListItem();
            itemSolicitado.Text = "Solicitado";
            itemSolicitado.Value = "Solicitado";

            listItemsResultado.Add(itemBorrador);
            listItemsResultado.Add(itemEntregado);
            listItemsResultado.Add(itemSolicitado);

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

        public List<SelectListItem> DropDownListaCliente()
        {
            List<Cliente> origenDatos = lnCliente.ClienteLeer(0);
            List<SelectListItem> listItemsResultado = new List<SelectListItem>();

            foreach (Cliente cliente in origenDatos)
            {
                SelectListItem item = new SelectListItem();
                item.Text = cliente.Apellido + " " + cliente.Nombre;
                item.Value = cliente.IdCliente.ToString();
                listItemsResultado.Add(item);
            }
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

        public List<SelectListItem> DropDownDireccion(int idDireccion, int idCliente)
        {
            List<Direccion> origenDatos = lnCliente.DireccionLeer(idDireccion, idCliente);
            List<SelectListItem> listItemsResultado = new List<SelectListItem>();

            foreach (Direccion direccion in origenDatos)
            {
                SelectListItem item = new SelectListItem();
                item.Text = direccion.NombreDireccion;
                item.Value = direccion.IdDireccion.ToString();
                listItemsResultado.Add(item);
            }
            return listItemsResultado;
        }

        public List<SelectListItem> DropDownTipoCliente()
        {
            List<TipoCliente> origenDatos = lnCliente.TipoClienteLeer();
            List<SelectListItem> listItemsResultado = new List<SelectListItem>();

            foreach (TipoCliente tipoCliente in origenDatos)
            {
                SelectListItem item = new SelectListItem();
                item.Text = tipoCliente.TipoClienteValor;
                item.Value = tipoCliente.IdTipoCliente;
                listItemsResultado.Add(item);
            }
            return listItemsResultado;
        }

        public List<SelectListItem> DropDownProducto()
        {
            List<Producto> origenDatos = lnProducto.ProductoLeer(0);
            List<SelectListItem> listItemsResultado = new List<SelectListItem>();

            foreach (Producto producto in origenDatos)
            {
                SelectListItem item = new SelectListItem();
                item.Text = producto.Nombre;
                item.Value = producto.IdProducto.ToString();
                listItemsResultado.Add(item);
            }
            return listItemsResultado;
        }
    }
}