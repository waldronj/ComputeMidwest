using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComputeMidwest.Entity;
using RestSharp;
using StructureMap;
using PusherRESTDotNet;

namespace ComputeMidwest.App_Start
{
    public static class StructureMapConfig
    {
        public static void RegisterStructureMap()
        {
            // configure structuremap
            ObjectFactory.Initialize(registry =>
                {
                    registry.Scan(scanner =>
                        {
                            scanner.TheCallingAssembly();
                            scanner.WithDefaultConventions();

                        });
                    registry.For<EntityModelContainer>().HttpContextScoped().Use(x => new EntityModelContainer());
                    registry.For<IPusherProvider>().Use(x => new PusherProvider("31452", "04af48f0bd881f9f9737", "0bbb6f45596775fa5d2d"));
                }
            );
        }
    }
}