
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace EventScheduler_NWAPI
{
    public class Plugin
    {


        public static Plugin Singleton { get; private set; }

        [PluginConfig]
        public Config Config;

        [PluginPriority(LoadPriority.Low)]
        [PluginEntryPoint("EventScheduler", "1.0.3", "EventScheduler", "DerGrubengraeber")]
        void LoadPlugin()
        {
            if (!Config.IsEnabled)
                return;

            Singleton = this;


            EventManager.RegisterEvents<EventHandler>(this);
        }

    }
}
