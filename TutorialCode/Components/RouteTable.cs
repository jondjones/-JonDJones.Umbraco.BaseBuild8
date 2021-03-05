﻿using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace JDJ.Core.Composer
{
    public class RouteTableComponent : IComponent
    {
        public void Initialize()
        {
            RouteTable.Routes.MapRoute(
               "DI",
               "DI",
               new
               {
                   controller = "Di",
                   action = "Index",
                   id = UrlParameter.Optional
               });

            RouteTable.Routes.MapRoute(
               "NoCachePartial",
               "Caching/Partial",
               new
               {
                   controller = "Caching",
                   action = "Partial",
                   id = UrlParameter.Optional
               });

            RouteTable.Routes.MapRoute(
               "NoCacheCaching",
               "Caching/OutputCache",
               new
               {
                   controller = "Caching",
                   action = "OutputCache",
                   id = UrlParameter.Optional
               });

            RouteTable.Routes.MapRoute(
               "SharedPartial",
               "Partial/{action}/{id}",
               new
               {
                   controller = "SharedPartial",
                   action = "Index",
                   id = UrlParameter.Optional
               });

            RouteTable.Routes.MapRoute(
                "BlockController",
                "Block/{action}/{item}/{alias}",
                new
                {
                    controller = "Block",
                    action = "Index",
                    item = UrlParameter.Optional,
                    alias = UrlParameter.Optional,
                });
        }

        public void Terminate()
        {
        }
    }
}