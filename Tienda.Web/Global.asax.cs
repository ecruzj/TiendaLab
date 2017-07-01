using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Tienda.Web.Api;
using Funq;
using ServiceStack.Text;
using Tienda.Web.AutoMapper;
using Tienda.Servicios.AppServices;
using ServiceStack.ContainerAdapter.Unity;
using Microsoft.Practices.Unity;

namespace Tienda.Web
{
    public class Global : System.Web.HttpApplication
    {
        public class AppHost : AppHostBase
        {
            public AppHost() : base("Tienda RestApi Services", typeof(ClientesRestService).Assembly) { }

            public override void Configure(Container container)
            {
                JsConfig.DateHandler = DateHandler.ISO8601;

                InitializeAutoMapper.InitializarAutomap();

                SetConfig(new HostConfig
                {
                    GlobalResponseHeaders =
                    {
                        {"Access-Control-Allow-Origin", "*"},
                        {"Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS"},
                    },
                });
                SetConfig(new HostConfig
                {
                    EnableFeatures = Feature.All.Remove(Feature.All).Add(Feature.Xml | Feature.Json | Feature.Html),
                });

                //register any dependencies your services use, e.g:
                IUnityContainer unityContainer = new UnityContainer();

                //App Services
                unityContainer.RegisterType<IClientesAppServices, ClientesAppServices>();

                var unityAdapter = new UnityContainerAdapter(unityContainer);
                container.Adapter = unityAdapter;
            }            
        }

        protected void Application_Start(object sender, EventArgs e)
        {

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