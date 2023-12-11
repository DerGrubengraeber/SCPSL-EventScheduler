using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Enums;
using CedMod;




namespace EventScheduler
{
    public class EventScheduler : Plugin<Config>
    {
        public override string Name => "Event Scheduler";
        public override string Prefix => "EventScheduler";
        public override string Author => "@DerGrubengraeber";

        private EventHandler eventHandler { get; set; }
        public static EventScheduler Instance { get; private set; }
        public override void OnEnabled()
        {
            Instance = this;
            eventHandler = new EventHandler();
            base.OnEnabled();
        }
        public override void OnDisabled() //TODO
        {
            //eventHandler = null!;

            //Instance = null!;
            base.OnDisabled();
        }

    }
}
