using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Models
{
    public  class Estados
    {        
        public string Uf { get; set; }
        public string Descicao { get; set; }

        public List<Estados> ListaEstados { get; set; }
        public Estados()
        {
            HidratarObjeto();
        }
        public void HidratarObjeto()
        {
            ListaEstados.Add(new Estados() { Uf = "AC", Descicao = "Acre" });
            ListaEstados.Add(new Estados() { Uf = "AL", Descicao = "Alagoas" });
            ListaEstados.Add(new Estados() { Uf = "AP", Descicao = "Amapa" });
            ListaEstados.Add(new Estados() { Uf = "AM", Descicao = "Amazonas" });
            ListaEstados.Add(new Estados() { Uf = "BA", Descicao = "Bahia" });
            ListaEstados.Add(new Estados() { Uf = "CE", Descicao = "Ceara" });
            ListaEstados.Add(new Estados() { Uf = "DF", Descicao = "Distrito Federal" });
            ListaEstados.Add(new Estados() { Uf = "ES", Descicao = "Espirito Santo" });
            ListaEstados.Add(new Estados() { Uf = "GO", Descicao = "Goias" });
            ListaEstados.Add(new Estados() { Uf = "MA", Descicao = "Maranhao" });
            ListaEstados.Add(new Estados() { Uf = "MT", Descicao = "Mato Grosso" });
            ListaEstados.Add(new Estados() { Uf = "MS", Descicao = "Mato Grosso do Sul" });
            ListaEstados.Add(new Estados() { Uf = "MG", Descicao = "Minas Gerais" });
            ListaEstados.Add(new Estados() { Uf = "PA", Descicao = "Para" });
            ListaEstados.Add(new Estados() { Uf = "PB", Descicao = "Paraiba" });
            ListaEstados.Add(new Estados() { Uf = "PR", Descicao = "Parana" });
            ListaEstados.Add(new Estados() { Uf = "PE", Descicao = "Pernambuco" });
            ListaEstados.Add(new Estados() { Uf = "RJ", Descicao = "Rio de Janeiro" });
            ListaEstados.Add(new Estados() { Uf = "RN", Descicao = "Rio Grande do Norte" });
            ListaEstados.Add(new Estados() { Uf = "RS", Descicao = "Rio Grande do Sul" });
            ListaEstados.Add(new Estados() { Uf = "RO", Descicao = "Rondonia" });
            ListaEstados.Add(new Estados() { Uf = "RR", Descicao = "Roraima" });
            ListaEstados.Add(new Estados() { Uf = "SC", Descicao = "Santa Catarina" });
            ListaEstados.Add(new Estados() { Uf = "SP", Descicao = "São Paulo" });
            ListaEstados.Add(new Estados() { Uf = "SE", Descicao = "Sergipe" });
            ListaEstados.Add(new Estados() { Uf = "TO", Descicao = "Tocantins" });
        }

      


    }
}