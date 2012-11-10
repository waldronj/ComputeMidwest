using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputeMidwest.Entity;

namespace ComputeMidwest.Model
{
    class HuntNotifier
    {
        public void NotifyHunterJoined(Hunter hunter)
        {
            // TODO: use pusher to notify 
            // TODO: objective.Hunter.HuntInstance.Hunters
        }

        public void NotifyHunterLeft(Hunter hunter)
        {
            // TODO: use pusher to notify 
            // TODO: objective.Hunter.HuntInstance.Hunters            
        }

        public void NotifyObjectiveFound(FoundObjective objective)
        {
            // TODO: use pusher to notify 
            // TODO: objective.Hunter.HuntInstance.Admin 
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
