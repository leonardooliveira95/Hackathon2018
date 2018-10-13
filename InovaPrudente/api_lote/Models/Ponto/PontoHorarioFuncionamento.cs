using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models.Ponto
{
    public class PontoHorarioFuncionamento
    {
        public int IdHorarioFuncionamento { get; set; }
        public string DiaSemana { get; set; }
        public DateTime HrCargaIni { get; set; }
        public DateTime HrCargaFin { get; set; }
        public DateTime HrDescargaIni { get; set; }
        public DateTime HrDescargaFin { get; set; }
    }
}