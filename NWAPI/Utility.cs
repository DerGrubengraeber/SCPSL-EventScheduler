using System;
using CedMod.Addons.Events.Interfaces;
using CedMod.Addons.Events;

namespace EventScheduler_NWAPI
{
    public class Utility
    {
        public static IEvent PrefixMatcher(String Prefix)
        {
            foreach (IEvent Event in EventManager.AvailableEvents)
            {
                if (Prefix == Event.EventPrefix)
                {
                    return Event;
                }
            }
            return null;
        }
    }
}
