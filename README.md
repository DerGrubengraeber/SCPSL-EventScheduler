# SCPSL-EventScheduler
An EXILED based Plugin for SCP:SL using CedMod.

# Installation:
Download the .dll and place it in the EXILED plugins folder (~/.config/EXILED/Plugins).
Needs Cedmod installed.


# Configuration 
The Config is currently still in the default EXILED config file (~/.config/EXILED/Configs/"portnumber"-config.yml).
- Edit the "rounds_between" option to configure how many normal rounds you want between event rounds.
- Set the "randomize" value to true to enable the scheduler to pick a random Event instead of running them in a preset order.
- Set the "TwoInARow" value to false to prevent the same event from happening twice in a row.
- Edit the "MinPlayers" option to configure how many players should be on the server to enable events.
- Set the "EnableExclusiveEvents" to true to prevent all events from being run except for those in the "ExclusiveEvents" List.
- Add Event Prefixes to the "ExclusiveEvents" List to specify the exclusive Events.

# Future Plans
- An option to assign each event a minimum player count seperately.
- An option to give an event a "chance / weight" to be selected by the randomize option.
- An option to select a "cooldown" for each event so you can specify how many other events should be in between the same event wehn the randomize option is enabled.
- A NWAPI version.
