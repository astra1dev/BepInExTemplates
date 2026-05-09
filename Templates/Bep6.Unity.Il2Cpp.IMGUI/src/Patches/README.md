Put your Harmony patch classes into this folder.

It's recommended to organize your patches into sub-folders according to their category if you're planning to add a lot of patches.

Ideally, each file contains patches for one game class, e.g. `LocalPlayerPatches.cs` contains the classes `LocalPlayer_FixedUpdate` and `LocalPlayer_MurderPlayer`, patching the original game functions `LocalPlayer.FixedUpdate` and `LocalPlayer.MurderPlayer` respectively. Then you have another file `GameManagerPatches.cs`, and so on.
