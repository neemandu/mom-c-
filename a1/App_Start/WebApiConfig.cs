using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using a1.Repositories;
using a1.TestsTypes;
using Contracts;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Services;
using Unity;

namespace a1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IToni, Toni>();
            container.RegisterType<IIvhunimRepository, IvhunimRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IIvhunimService, IvhunimService>();
            container.RegisterType<IPdfService, PdfService>();
            config.DependencyResolver = new UnityResolver(container);
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
