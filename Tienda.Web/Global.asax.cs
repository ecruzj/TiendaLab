using System;
using Tienda.Web.Api;
using Funq;
using Tienda.Web.AutoMapper;
using Tienda.Servicios.AppServices;
using ServiceStack.ContainerAdapter.Unity;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.ServiceHost;
using ServiceStack.Common;
using ServiceStack.Text;
using Microsoft.Practices.Unity;

namespace Tienda.Web
{
    public class Global : System.Web.HttpApplication
    {
        public class AppHost : AppHostBase
        {
            public AppHost() : base("Tienda RestApi Services", typeof(CategoriasRestService).Assembly) { }

            public override void Configure(Container container)
            {
                JsConfig.DateHandler = JsonDateHandler.ISO8601;

                InitializeAutoMapper.InitializarAutomap();

                SetConfig(new EndpointHostConfig
                {
                    GlobalResponseHeaders =
                    {
                        {"Access-Control-Allow-Origin", "*"},
                        {"Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS"},
                    },
                });
                SetConfig(new EndpointHostConfig
                {
                    EnableFeatures = Feature.All.Remove(Feature.All).Add(Feature.Xml | Feature.Json | Feature.Html),
                });

                //register any dependencies your services use, e.g:
                IUnityContainer unityContainer = new UnityContainer();

                //App Services
                unityContainer.RegisterType<IClientesAppServices, ClientesAppServices>();
                unityContainer.RegisterType<ICategoriasAppServices, CategoriasAppServices>();

                var unityAdapter = new UnityContainerAdapter(unityContainer);
                container.Adapter = unityAdapter;
            }            
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}