using System;
using System.Collections.Generic;
using CedMod.Addons.Events.Interfaces;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace EventScheduler_NWAPI
{
    class EventHandler
    {
        

        private int roundsPassed = 0;
        private int eventMenge; //no i will not change the name of this :P
        private int eventsCurrent = 0;
        private IEvent lastEvent;
        private Random rnd = new Random();
        private static List<IEvent> AEvents;
        private bool enoughPlayers = true; //this is horrible but i don't have another fix rn

       
        
        [PluginEvent(ServerEventType.RoundRestart)]
        public void RoundRestart()
        {
            if (Server.ConnectionsCount >= Plugin.Singleton.Config.MinPlayers)
            {

                enoughPlayers = true;
            }
            else
            {
                enoughPlayers = false;
            }
        }


        [PluginEvent(ServerEventType.WaitingForPlayers)]
        public void PlayerWaiting()
        {
            if (!Plugin.Singleton.Config.EnableExclusiveEvents)
            {
                AEvents = new List<IEvent>(CedMod.Addons.Events.EventManager.AvailableEvents);
            }
            else
            {
                AEvents = new List<IEvent>();
                foreach (string prefix in Plugin.Singleton.Config.ExclusiveEvents)
                {
                    if (Utility.PrefixMatcher(prefix) != null)
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
            if (roundsPassed >= Plugin.Singleton.Config.RoundsBetween)
            {
                if (CedMod.Addons.Events.EventManager.AvailableEvents != null && CedMod.Addons.Events.EventManager.CurrentEvent == null && enoughPlayers)
                {

                    roundsPassed = 0;
                    if (!Plugin.Singleton.Config.Randomize)
                    {
                        IEvent nextEvent = AEvents[eventsCurrent];
                        Server.RunCommand("/Events enable " + nextEvent.EventPrefix + " false");
                        eventsCurrent++;
                        if (eventsCurrent >= eventMenge)
                        {
                            eventsCurrent = 0;
                        }
                    }
                    else
                    {
                        int rndN = rnd.Next(0, eventMenge);
                        if (!Plugin.Singleton.Config.TwoInARow)
                        {
                            IEvent nextEvent = AEvents[rndN];
                            while (nextEvent.Equals(lastEvent))
                            {
                                nextEvent = AEvents[rndN];
                            }
                            Server.RunCommand("/Events enable " + nextEvent.EventPrefix + " false");
                            lastEvent = nextEvent;
                        }
                        else
                        {

                            IEvent nextEvent = AEvents[rndN];
                            Server.RunCommand("/Events enable " + nextEvent.EventPrefix + " false");

                        }
                    }
                }
            }
            else if (CedMod.Addons.Events.EventManager.CurrentEvent == null)
            {
                roundsPassed++;
            }
        }
    }
}
