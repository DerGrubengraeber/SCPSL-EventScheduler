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
        private static Config config => EventScheduler.Instance.Config;
        private int roundsPassed = 0;
        private int spacerRounds = config.RoundsBetween-1;
        private int eventMenge; //no i will not change the name of this :P
        private int eventsCurrent = 0;
        Random rnd = new Random();
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
            eventMenge = EventManager.AvailableEvents.Count;
            if (roundsPassed >= spacerRounds)
                {
                if (EventManager.AvailableEvents != null && EventManager.CurrentEvent == null)
                {
                    roundsPassed = 0;
                    if (!config.Randomize)
                    {
                        IEvent nextEvent = EventManager.AvailableEvents[eventsCurrent];
                        Server.ExecuteCommand("/Events enable " + nextEvent.EventPrefix + " false");
                        eventsCurrent++;
                        if (eventsCurrent >= eventMenge)
                        {
                            eventsCurrent = 0;
                        }
                    }
                    else 
                    {
                        Log.Info("Event Menge ist " + eventMenge);
                        int rndN = rnd.Next(0, eventMenge);
                        Log.Info("Random Number is " + rndN);
                        IEvent nextEvent = EventManager.AvailableEvents[rndN];
                        Server.ExecuteCommand("/Events enable " + nextEvent.EventPrefix + " false");
                        Log.Info("Next Event is " + nextEvent.EventName);
                    }
                }
                }
                else if(EventManager.CurrentEvent == null)
                {
                    roundsPassed++;
                }
        }
    }
}
