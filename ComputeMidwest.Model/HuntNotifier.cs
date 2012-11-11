using ComputeMidwest.Entity;
using PusherRESTDotNet;

namespace ComputeMidwest.Model
{
    public enum EventTypes
    {
        HunterJoined,
        HunterLeft,
        ObjectiveFound,
        ObjectiveApproved,
        ObjectiveDenied,
        HuntStarting,
        HuntEnding,
        HuntMessage
    }

    public class HuntNotifier
    {
        private readonly IPusherProvider _provider;

        public HuntNotifier(IPusherProvider provider)
        {
            _provider = provider;
        }

        public void NotifyHunterJoined(Hunter hunter)
        {
            var request =
                new ObjectPusherRequest(hunter.HuntInstance.Id.ToString("D"),
                                        EventTypes.HunterJoined.ToString(),
                                        new
                                            {
                                                id = hunter.Id.ToString("D"),
                                                name = hunter.Account.Name,
                                                profileImageUrl = hunter.Account.ProfileImageUrl
                                            });
            _provider.Trigger(request);
        }

        public void NotifyHunterLeft(Hunter hunter)
        {
            var request =
                new ObjectPusherRequest(hunter.HuntInstance.Id.ToString("D"),
                                        EventTypes.HunterLeft.ToString(),
                                        new
                                            {
                                                id = hunter.Id.ToString("D"),
                                                name = hunter.Account.Name,
                                                profileImageUrl = hunter.Account.ProfileImageUrl
                                            });
            _provider.Trigger(request);
        }

        public void NotifyObjectiveFound(FoundObjective objective)
        {
            var request =
                new ObjectPusherRequest(
                    objective.Hunter.HuntInstance.Id.ToString("D") + "_" +
                    objective.Hunter.HuntInstance.Admin.Id.ToString("D"),
                    EventTypes.ObjectiveFound.ToString(),
                    new
                        {
                            hunter = new
                                {
                                    id = objective.Hunter.Id.ToString("D"),
                                    name = objective.Hunter.Account.Name,
                                    profileImageUrl = objective.Hunter.Account.ProfileImageUrl
                                },
                            objective = new
                                {
                                    id = objective.Objective.Id.ToString("D"),
                                    name = objective.Objective.Name,
                                    imgUrl = objective.ImageUrl
                                }
                        });
            _provider.Trigger(request);
        }

        public void NotifyObjectiveDenied(FoundObjective objective)
        {
            // TODO: use pusher to notify 
            // TODO: objective.Hunter            
        }

        public void NotifyObjectiveApproved(FoundObjective objective)
        {
            // TODO: use pusher to notify 
            // TODO: objective.Hunter.HuntInstance.Hunters
        }

        public void NotifyHuntEnding(HuntInstance instance)
        {
            // TODO: use pusher to notify 
            // TODO: instance.Hunters            
            // TODO: instance.Admin  
        }

        public void SendHuntMessage(HuntInstance instance)
        {
            // TODO: use pusher to notify 
            // TODO: instance.Hunters            
            // TODO: instance.Admin  
        }
    }
}