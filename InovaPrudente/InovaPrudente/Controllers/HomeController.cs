using InovaPrudente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InovaPrudente.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TrocarEndereco()
        {
            TrocarEnderecoViewModel vm = new TrocarEnderecoViewModel();
            vm.EnderecoAtual = "Coronel José Soares Marcondes, 2000, Presidente Prudente";

            return PartialView("_TrocarEndereco", vm);
        }

        [HttpPost]
        public ActionResult CalcularValorPrecoDistancia(double distancia)
        {

            return Json(new { valor = 52 });

        }
    }
}