# SCPSL-EventScheduler
An EXILED based Plugin for SCP:SL using CedMod.

# Installation:
Download the .dll and place it in the EXILED plugins folder (~/.config/EXILED/Plugins).
Needs Cedmod installed.


# Configuration 
The Config is currently still in the default EXILED config file (~/.config/EXILED/Configs/"portnumber"-config.yml).
- Edit the "rounds_between" option to configure how many normal rounds you want between event rounds
- Set the "randomize" value to true to enable the scheduler to pick a random Event instead of running them in a preset order.

# Future Plans
- An option to only run a set of user specified events, even tho more are installed.
- An option to give an event a "chance / weight" to be selected by the randomize option.
- A NWAPI version.
