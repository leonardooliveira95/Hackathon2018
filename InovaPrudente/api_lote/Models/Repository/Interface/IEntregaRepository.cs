using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apiInovaPP.Models.Entrega;

namespace apiInovaPP.Models.Repository.Interface
{
    public interface IEntregaRepository
    {
        Entrega.Entrega Get(int idEntrega);
        Entrega.Entrega Get(string codigoRastreio);
        string GetCalcularTrocaEndereco(int idCidade, decimal distancia);
        bool PostTrocarEnderecoEntrega(Entrega.Entrega entrega, int idCidade, int distancia, string Logradouro2);
        bool Add(Entrega.Entrega entrega);
        bool Update(Entrega.Entrega entrega);
    }
}