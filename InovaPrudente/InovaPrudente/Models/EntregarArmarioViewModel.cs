using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InovaPrudente.Models
{
    public class EntregarArmarioViewModel
    {
        public string EnderecoAtual { get; set; }
        public List<LocalViewModel> Locais { get; set; }
    }
}