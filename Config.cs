using Exiled.API.Interfaces;
using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace EventScheduler
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("The number of normal rounds in between event rounds. Default 5")]
        public int RoundsBetween { get; set; } = 5;
        [Description("Set to true to make the scheduler choose the next event randomly. Default False")]
        public bool Randomize { get; set; } = false;

        [Description("Set to true to allow the same event to happen twice in a row (only applies when Randomize is enabled). Default true. Do not set to false when only one event is installed. ")]
        public bool TwoInARow { get; set; } = true;

        [Description("The minimum amount of players on the Server to enable Events. Default 1")]
        public int MinPlayers { get; set; } = 1;
        [Description("Set to true to enable ExclusiveEvents. Default False. (If this is set to true but no events are given then none will be run")]
        public bool EnableExclusiveEvents { get; set; } = false;
        [Description("Enter the Prefixes of the events that should be run, leave empty if you want to run all installed events. Default empty.")]
        public List<string> ExclusiveEvents { get; set; } = new List<string>();
    }
}
