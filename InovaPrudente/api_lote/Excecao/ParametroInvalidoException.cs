using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiInovaPP.Excecao
{
    public class ParametroInvalidoException:Exception
    {
        public static string ParametroNaoInformado { get { return "Parâmetro {0} não informado."; } }
        public static string ParametroInvalido { get { return "Parâmetro {0} : {1} inválido."; } }         
        public ParametroInvalidoException()
        {

        }
        public ParametroInvalidoException(string message):base(message)
        {
        }

        public ParametroInvalidoException(string message, Exception inner)
        : base(message, inner)
        {
        }


    }
}