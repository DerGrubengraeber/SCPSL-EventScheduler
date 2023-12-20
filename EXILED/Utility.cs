using System;
using System.Collections.Generic;
using CedMod.Addons.Events.Interfaces;
using CedMod.Addons.Events;
using Exiled.API.Features;

namespace EventScheduler
{

    public class Utility
    {
        private static List<IEvent> TEvents;
        private static Config config => EventScheduler.Instance.Config;

        public static IEvent PrefixMatcher(String Prefix)
        {
            foreach(IEvent Event in EventManager.AvailableEvents)
            {
                if(Prefix == Event.EventPrefix)
                {
                    return Event;
                }                  
            }
            return null;
        }

        public static List<IEvent> EventListBuilder()
        {

            if (!config.EnableExclusiveEvents)
            {
                foreach (IEvent @event in EventManager.AvailableEvents)
                {
                    if (!config.EnableBlacklist || !config.Blacklist.Contains(@event.EventPrefix))
                    {
                        TEvents.Add(@event);
                    }
                }
                
            }
            else
            {
                TEvents = new List<IEvent>();
                foreach (string prefix in config.ExclusiveEvents)
                {
                    if (Utility.PrefixMatcher(prefix) != null)
                    {
                        if (!config.EnableBlacklist || !config.Blacklist.Contains(prefix))
                        {
                            TEvents.Add(Utility.PrefixMatcher(prefix));
                        } 

                        
                    }
                    else
                    {
                        Log.Error("ERROR no event with the Prefix " + prefix + " Please resolve this issue to avoid issues with the event scheduling");
                    }
                }
            }

            return TEvents;
        }

    }
}
