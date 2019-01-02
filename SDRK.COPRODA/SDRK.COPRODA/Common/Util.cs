using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDRK.COPRODA.Common
{
    public class Util
    {
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
    }
}