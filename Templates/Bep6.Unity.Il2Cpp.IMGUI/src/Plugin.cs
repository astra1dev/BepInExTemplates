using System;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using UnityEngine.SceneManagement;
using HarmonyLib;
using Bep6.Unity.Il2Cpp.IMGUI.Components;
using Bep6.Unity.Il2Cpp.IMGUI.UI.Windows;

namespace Bep6.Unity.Il2Cpp.IMGUI;

[BepInAutoPlugin]
[BepInProcess("{game}.exe")]
public partial class Plugin : BasePlugin
{
    private Harmony Harmony { get; } = new(Id);
    public new static ManualLogSource Log;

    public static bool LogSceneChanges;

    public override void Load()
    {
        // Plugin startup logic
        Log = base.Log;

        Harmony.PatchAll();

        AddComponent<MainWindow>();
        AddComponent<SystemInformationWindow>();
        AddComponent<ApplicationInformationWindow>();
        AddComponent<KeybindListener>();

        SceneManager.add_sceneLoaded((Action<Scene, LoadSceneMode>)((scene, _) =>
        {
            if (LogSceneChanges)
            {
                Log.LogInfo($"Scene loaded: {scene.name}");
            }
        }));

        Log.LogInfo($"Plugin {Id} is loaded!");
    }
}
