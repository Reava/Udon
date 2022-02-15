# Udon UwUtils
Reava makes Udon stuff.
You'll find all sorts of niche scripts made in U# by myself for different projects, revisited & cleaned for everyone's use.

- **InteractSwitch**:
On interact, enables an array of gameOjbects, and disables a second array. Does NOT revert once pressed again, it SETS the state and is NOT synced.

- **PlayerListManager**:
Not ready for public use yet, this will be part of a prefab once ready.

- **TagAssigner**:
Functions as a whitelist with functions, assigns a Tag to anyone who matches their username to the user Array of the behavior on world join. Local, also behaves like the InteractSwitch if your username matches. has a toggle to TP the whitelisted user on Join.

- **TagTP**:
If you got the correct Tag to your name on interact with the behavior, teleports you to the target, if not, teleports you to the second target (or doesn't if empty / disabled)

- **reflectionprobeiscool**:
RelfectionProbes are cool! make them real time, scripted and add this script to change the frequency they refresh at !

- **Spinny**:
A script to rotate things on any axis, at any speed, and even at weird update speeds (like 30 degrees but only once a second)

- **UnityFogToggle**:
Just an interact toggle that toggles ON/OFF Unity's fog... that's it. Call it with a trigger or a UI button, it'll work.

- **SceneInitializer**:
Want to have things enabled for the first few seconds an user enters your world then disable ? the opposite ? both ? Just use that, ezpz

- **tagSetter**:
Set a pre determined tag to the local user on interact. that's it.

- **TagDebugger**:
Handy tool to display the local user's tag and output it to the debugLogs or text (Compatible with UnityUI, TMP & TMP GUI), updates on Interact & on Start.

- **TagArrayTP**:
Have a lot of tags & want each one to TP the user to a different spot ? Well... this does it all for ya! Even has a fallback target when the user doesn't have a tag (can be disabled to disallow TPing when no matching ranks are found)

## **Requirements**
Check updates before reporting issues.

- **[Unity](https://docs.vrchat.com/docs/current-unity-version)** (Tested: v2019.4.31f1)
- **[VRChat Worlds SDK3](https://vrchat.com/home/download)** (Tested: v2021.11.24.16.19)
- **[UdonSharp](https://github.com/MerlinVR/UdonSharp/)** (Tested: v0.20.3)

## **Extras**
- **UwUtils_AxisGuides**
A package containing a Blender & Unity Axis model for debugging or display, <1kb texture & 1 Meter scale (bounds)

My work is heavily inspired and i'm a begginer at U#, if you have any issues, feel free to DM me / Join this discord:
- https://discord.gg/TxYwUFKbUS

***Example world:*** https://vrchat.com/home/world/wrld_bd34e017-bdbd-4150-9577-660cd1ff29f7
*This world currently only shows Spinny & the varying Tag scripts and aims to show more in the future.*
