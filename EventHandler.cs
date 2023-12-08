using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CedMod.Addons.Events;
using CedMod.Commands;
using CedMod.Addons.Events.Interfaces;
using Exiled.API.Features;


namespace EventScheduler
{
    class EventHandler
    {
       
        private int roundsPassed = 0; //Make this a config option
        private int spacerRounds = 4; //Make this a config option
        private int eventMenge = EventManager.AvailableEvents.Count;
        private int eventsCurrent = 0;
   


        public EventHandler()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers += PlayerWaiting;
        }

         ~EventHandler()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= PlayerWaiting;
        }

        public void PlayerWaiting()
        {
            
            if(roundsPassed >= spacerRounds)
            {
                if(EventManager.AvailableEvents != null && EventManager.CurrentEvent == null)
                {
                    roundsPassed = 0;                
                    IEvent nextEvent = EventManager.AvailableEvents[eventsCurrent];
                    Server.ExecuteCommand("/Events enable " + nextEvent.EventPrefix + " false");
                    eventsCurrent++;
                    
                    if(eventsCurrent > eventMenge)
                    {
                        eventsCurrent = 0;
                    }

                }

            }
            else
            {
                roundsPassed++;
            }
        }
        
            
        

    }
}
