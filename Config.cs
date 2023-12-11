using Exiled.API.Interfaces;
using System.ComponentModel;

namespace EventScheduler
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("The number of normal rounds in between event rounds Default 5")]
        public int RoundsBetween { get; set; } = 5;
        [Description("Set to true to make the scheduler choose the next event randomly. Default False")]
        public bool Randomize { get; set; } = false;
    }
}
