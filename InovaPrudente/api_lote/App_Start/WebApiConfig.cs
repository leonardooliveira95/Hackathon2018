using apiInovaPP.Excecao;
using apiInovaPP.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;


namespace apiInovaPP
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApiWithId", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            //config.Routes.MapHttpRoute("DefaultApiWithActionWithId", "api/{controller}/{action}/{id}", new {  id = RouteParameter.Optional });
            config.Routes.MapHttpRoute("DefaultApiWithAcionWithDescricao", "api/{controller}/{action}/{descricao}", new { descricao = RouteParameter.Optional });
            config.Routes.MapHttpRoute("DefaultApiWithAction", "api/{controller}/{action}");
            config.Routes.MapHttpRoute("DefaultApiGet", "api/{controller}", new { action = "Get" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });
            config.Routes.MapHttpRoute("DefaultApiPostWithAction", "api/{controller}/{action}", new { action = "Post" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });
            config.Routes.MapHttpRoute("DefaultApiPost", "api/{controller}", new { action = "Post" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });            
            config.Routes.MapHttpRoute("DefaultApiPut", "api/{controller}", new { action = "Put" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) });
            config.Routes.MapHttpRoute("DefaultApiDelete", "api/{controller}", new { action = "Delete" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) });

            
            //config.Routes.MapHttpRoute("DefaultApiDeleteWithId", "api/{controller}/{id}", new { action = "Delete" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) });


            var corsAttr = new EnableCorsAttribute("http://www.machadoincorporadora.com.br,http://machadoincorporadora.com.br,http://localhost:11033,http://localhost:8931,http://localhost,http://www.99codgo.com.br,http://99codgo.com.br,http://rti.99codgo.com.br,https://rti.99codgo.com.br", "*", "*");
            //var corsAttr = new EnableCorsAttribute("http://localhost:11033", "*", "*");
            config.EnableCors(corsAttr);

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));
            config.Filters.Add(new ExceptionConvertFilter());

            //config.Filters.Add(new ParametroInvalidoException());
            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            //config.EnableSystemDiagnosticsTracing();
        }
    }
}
