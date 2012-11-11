using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComputeMidwest.Entity;
using RestSharp;
using StructureMap;

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
                    registry.For<EntityModelContainer>().Use(x => new EntityModelContainer());
                }
            );
        }
    }
}