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
        private int spacerRounds = config.RoundsBetween - 1;
        private int eventMenge; //no i will not change the name of this :P
        private int eventsCurrent = 0;
        private IEvent lastEvent;
        private Random rnd = new Random();
        private static List<IEvent> AEvents;
        private bool enoughPlayers = true; //this is horrible but i don't have another fix rn
        public EventHandler()
        {
            Exiled.Events.Handlers.Server.RestartingRound += RoundRestart;
            Exiled.Events.Handlers.Server.WaitingForPlayers += PlayerWaiting;    
        }
        ~EventHandler()
        {
            Exiled.Events.Handlers.Server.RestartingRound -= RoundRestart;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= PlayerWaiting;
        }

        public void RoundRestart()
        {
            if(Player.List.Count >= config.MinPlayers)
            {
                
                enoughPlayers = true;
            }
            else
            {
                enoughPlayers = false;
            }
        }

        public void PlayerWaiting()
        {
            if (!config.EnableExclusiveEvents)
            {
                AEvents = new List<IEvent>(EventManager.AvailableEvents);
            }
            else
            {
                AEvents = new List<IEvent>();
                foreach (string prefix in config.ExclusiveEvents)
                {
                   if(Utility.PrefixMatcher(prefix) != null)
                    {                      
                        AEvents.Add(Utility.PrefixMatcher(prefix));
                    } 
                    else
                    {
                        Log.Error("ERROR no event with the Prefix " + prefix + " Please resolve this issue to avoid issues with the event scheduling");
                    }
                }
            }
            eventMenge = AEvents.Count;
            if (roundsPassed >= spacerRounds) 
                {
                if (EventManager.AvailableEvents != null && EventManager.CurrentEvent == null && enoughPlayers) 
                {
                  
                    roundsPassed = 0;
                    if (!config.Randomize)
                    {
                        IEvent nextEvent = AEvents[eventsCurrent];
                        Server.ExecuteCommand("/Events enable " + nextEvent.EventPrefix + " false");
                        eventsCurrent++;
                        if (eventsCurrent >= eventMenge)
                        {
                            eventsCurrent = 0;
                        } 
                    }
                    else 
                    {
                        int rndN = rnd.Next(0, eventMenge);
                        if (!config.TwoInARow) 
                        {
                            IEvent nextEvent = AEvents[rndN];
                            while (nextEvent.Equals(lastEvent))
                            {
                                nextEvent = AEvents[rndN];
                            }
                            Server.ExecuteCommand("/Events enable " + nextEvent.EventPrefix + " false");
                            lastEvent = nextEvent;
                        }
                        else
                        {
                            
                            IEvent nextEvent = AEvents[rndN];
                            Server.ExecuteCommand("/Events enable " + nextEvent.EventPrefix + " false");
                           
                        }
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
