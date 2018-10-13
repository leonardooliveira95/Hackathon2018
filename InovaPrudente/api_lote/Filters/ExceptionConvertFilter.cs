using apiInovaPP.Excecao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace apiInovaPP.Filters
{
    public class ExceptionConvertFilter : ExceptionFilterAttribute
    {
        public IDictionary<Type, HttpStatusCode> Excecoes { get; private set; }

         public ExceptionConvertFilter()
        {
            this.Excecoes = new Dictionary<Type, HttpStatusCode>();
            this.Excecoes.Add(typeof(ParametroInvalidoException), HttpStatusCode.Conflict);
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var message = actionExecutedContext.Exception.Message;
            var statusCode = HttpStatusCode.InternalServerError;
            if (this.Excecoes.ContainsKey(actionExecutedContext.Exception.GetType()))
            {
                statusCode = this.Excecoes[actionExecutedContext.Exception.GetType()];
            }
            actionExecutedContext.Response = new HttpResponseMessage
            {
                Content = new StringContent(message),
                StatusCode = statusCode,
                RequestMessage = actionExecutedContext.Request
            };
            base.OnException(actionExecutedContext);
        }

    }
}