using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputeMidwest.Entity;

namespace ComputeMidwest.Test
{
    class DummyHuntFactory
    {
        public static HuntInstance CreateDummyHuntInstance()
        {
            var theObjective = new Objective()
                {
                    Id = new Guid("{81573EBA-C5AA-4423-B308-BCB3026AE771}"),
                    Name = "Find a fountain!",
                    Description = "It must be green.",
                    Score = 100
                };

            var theAdmin = new Account()
                {
                    Id = new Guid("{714DC8D9-42EA-43F2-8148-DDFAC1E585C5}"),
                    Name = "SuperTom"
                };

            var britAccount = new Account()
                {
                    Id = new Guid("{614DC8D9-42EA-43F2-8148-DDFAC1E585C6}"),
                    Name = "Brit"
                };

           
            var theHunt = new Hunt()
                {
                    Id = new Guid("{741BB781-531D-4354-A840-777E267A809E}"),
                    Name = "DummyHunt",
                    Description = "A dummy hunt!",
                    Creator = theAdmin,
                    
                };

            var theInstance = new HuntInstance()
                {
                    Id = new Guid("{E41BB781-531D-4354-A840-777E267A809E}"),
                    Admin = theAdmin,
                    StartTime = new DateTime(2012, 12, 1, 12, 0, 0, 0),
                    EndTime = new DateTime(2012, 12, 2, 12, 0, 0, 0),
                    Hunt = theHunt
                };

            var britHunter = new Hunter()
                {
                    Id = new Guid("{F41BB781-531D-4354-A840-777E267A809E}"),
                    Account = britAccount,
                    HuntInstance = theInstance
                };

            theInstance.Hunters.Add(britHunter);
            theHunt.Objectives.Add(theObjective);
            theObjective.Hunt = theHunt;

            return theInstance;
        }
    }
}
