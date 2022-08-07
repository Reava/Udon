# Udon UwUtils
Reava makes Udon stuff.
You'll find all sorts of niche scripts made in U# by myself for different projects, revisited & cleaned for everyone's use.

**WARNING**: Those are currently not tested for U#1.0, I'll make another release for it in the future, when more widly used.

- **iTP**:
Literally just TPs you on interact, that's it.
- **iState**:
Switches the state of an array of GameObjects. Can receive events to either invert the state, toggle all on, or toggle all off. (_InvertState,_Disable,_Enable)
- **InteractSwitch**:
On interact, enables an array of gameObjects, and disables a second array. Does NOT revert once pressed again, it SETS the state and is NOT synced.
- **PlayerListManager**:
Not ready for public use yet, this will be part of a prefab once ready.
- **TagAssigner**:
Functions as a whitelist with functions, assigns a Tag to anyone who matches their username to the user Array of the behavior on world join. Local, also behaves like the InteractSwitch if your username matches. has a toggle to TP the whitelisted user on Join (currently not functionning).
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
- **ActionRelay**:
Wanna use a button to push another button ? Do the same as UI can do ? Yup, just type the event name (like "\_interact"), if you want a delay or not & for how many seconds.... and you're good to go! You can also check the state of another object to ignore the delay if that object is on / off. Will support UdonBehavior Arrays on for the UdonSharp1.0 update soon
- **UdonKeybinds**:
Send an event call to 6 different udon behaviors based on keybinds, serves either for RollTheRed's Camera System or as a code template. Press CTRL + 1 to 6 to trigger changes. CTRL + 0 to toggle keybinds ON/OFF, defaults to ON unless changed. Will support UdonBehavior Arrays on for the UdonSharp1.0 update soon
- **AnimatorDriver**:
Inverts a boolean on an animator on interact... and that's it
- **TriggerRelay**:
Assign trigger colliders, and assign an Udon Behavior to send an event to either on Enter or Exit, super simple stuff! Will support UdonBehavior Arrays on for the UdonSharp1.0 update soon
- **PlayercountToAnimator**:
Enables driving an Animator's parameter (one parameter per Behavior, multiple Animators at once supported) between two values (Min/Max) depending on the player count in the instance. Can set the player count cap to reach max value.
- **InstanceTimeActions**: > NOT READY <
Enables performing actions based on Instance Time (segmented), synced for late joiners.
- **JoinBell**:
Pretty straightforward, just tap in an AudioSource & a clip for Join/Leave and enjoy
- **ToggleCanvas**:
Same as iState, but for Canvas components
- **MeshRendererSwapper**:
Enables swapping between two Groups of Mesh Renderers at runtime, setting between 1 & 2 as default, and which group by default on Quest. practical for optimization toggles. Supports events (_switchGroup, _enableOne, _enableTwo)

## **Requirements**
Check updates before reporting issues.

- **[Unity](https://docs.vrchat.com/docs/current-unity-version)** (Tested: v2019.4.31f1)
- **[VRChat Worlds SDK3](https://vrchat.com/home/download)** (Tested: v2022.07.26.21.44)
- **[UdonSharp](https://github.com/MerlinVR/UdonSharp/)** (Tested: v0.20.3)
- **Text Mesh Pro** is required for AxisGuides, and can be required to use some scripts, can be imported anytime.

## **Extras**
- **UwUtils_AxisGuides**
A package containing a Blender & Unity Axis model for debugging or display, <1kb texture & 1 Meter scale (bounds)

## **Links**
Get support & support me here:
- https://discord.gg/TxYwUFKbUS
- https://patreon.com/Reava

Some tutorials might be posted on my Youtube: https://www.youtube.com/channel/UCm3RYWUql-2yGt8K2u9eFEg/
