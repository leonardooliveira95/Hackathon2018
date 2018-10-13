using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models
{
    public class TipoEncomenda
    {
        public int IdTipoEncomenda { get; set; }
        public string DescricaoTipoEncomenda { get; set; }

        public TipoEncomenda()
        {

        }
        public TipoEncomenda(int idTipoEncomenda, string descricaoTipoEncomenda)
        {
            this.IdTipoEncomenda = idTipoEncomenda;
            this.DescricaoTipoEncomenda = descricaoTipoEncomenda;
        }
    }
}