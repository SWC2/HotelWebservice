﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WSRestHotels
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{action}",
                defaults: new
                {
                    id = RouteParameter.Optional, action = "DefaultAction"
                
                }
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultNoArgApi",
            //    routeTemplate: "api/{controller}/{action}",
            //    defaults: null
            //);
        }
    }
}