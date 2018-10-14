using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models.Entrega
{
    public class TipoEntrega
    {
        public int IdTipoEntrega { get; set; }
        public string DescricaoTipoEntrega { get; set; }

        public TipoEntrega()
        {

        }
        public TipoEntrega(int idTipoEntrega, string descricaoTipoEntrega)
        {
            this.IdTipoEntrega = IdTipoEntrega;
            this.DescricaoTipoEntrega = descricaoTipoEntrega;
        }
    }
}