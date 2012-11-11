using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using ComputeMidwest.Entity;

namespace ComputeMidwest.Model
{
    class HuntModel
    {
        private readonly EntityModelContainer _container;
        private readonly HuntNotifier _notifier;

        public HuntModel(EntityModelContainer container, HuntNotifier notifier)
        {
            _container = container;
            _notifier = notifier;
        }

        public Hunt CreateHunt(Account user, Hunt huntTemplate)
        {
            if ((from hunt in _container.Hunts where hunt.Name == huntTemplate.Name select hunt).FirstOrDefault() != null)
                throw new HuntAlreadyExistsException();

            _container.Hunts.AddObject(huntTemplate);
            _container.SaveChanges();

            return huntTemplate;
        }

        public IQueryable<Hunt> ListHunts(Account user)
        {            
            return (from hunt in _container.Hunts where hunt.Creator == user select hunt);
        }

        public IQueryable<Hunt> ListActiveHunts()
        {
            return (from hunt in _container.Hunts where hunt.HuntInstances.Count > 0 select hunt);
        }

        public void JoinHunt(Account user, HuntInstance instance)
        {
            if (instance.EndTime < DateTime.Now)
                throw new HuntEndedException();

            if (instance.Hunters.Any(x => x.Account == user))            
                throw new HuntAlreadyJoinedException();
                        
            var hunter = new Hunter()
                {
                    Account = user,
                    Score = 0
                };

            instance.Hunters.Add(hunter);            
            _container.SaveChanges();
            _notifier.NotifyHunterJoined(hunter);
        }

        public void FoundObjective(Hunter hunter, Objective objective, string locationAndImage)
        {
            if (hunter.HuntInstance.EndTime < DateTime.Now)
                throw new HuntEndedException();

            var foundObjective = new FoundObjective()
                {
                    Objective = objective,
                    TimeFound = DateTime.Now
                    // todo: location and image
                };

            hunter.FoundObjectives.Add(foundObjective);

            _container.SaveChanges();
            _notifier.NotifyObjectiveFound(foundObjective);
        }

        public void ApproveObjective(Account admin, FoundObjective foundObjective)
        {
            if (foundObjective.Hunter.HuntInstance.EndTime < DateTime.Now)
                throw new HuntEndedException();

            if (foundObjective.Hunter.HuntInstance.Admin != admin)
                throw new SecurityException();

            foundObjective.Approved = true;
            _container.SaveChanges();
            _notifier.NotifyObjectiveApproved(foundObjective);
        }

        public void DenyObjective(Account admin, FoundObjective foundObjective)
        {
            if (foundObjective.Hunter.HuntInstance.EndTime < DateTime.Now)
                throw new HuntEndedException();

            if (foundObjective.Hunter.HuntInstance.Admin != admin)
                throw new SecurityException();

            foundObjective.Hunter.FoundObjectives.Remove(foundObjective);
            _container.SaveChanges();
            _notifier.NotifyObjectiveDenied(foundObjective);
        }

        public HuntInstance StartHunt(Account user, Hunt hunt)
        {
            return new HuntInstance();

        }

        public void LeaveHunt(Account user, HuntInstance instance)
        {
            
        }        

    }

    internal class HuntAlreadyExistsException : Exception
    {
    }

    internal class HuntEndedException : Exception
    {
    }

    internal class HuntAlreadyJoinedException : Exception
    {
    }
}
