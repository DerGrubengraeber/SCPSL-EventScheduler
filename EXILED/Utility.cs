using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CedMod;
using CedMod.Addons.Events.Interfaces;
using CedMod.Addons.Events;

namespace EventScheduler
{
    public class Utility
    {
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
    }
}
