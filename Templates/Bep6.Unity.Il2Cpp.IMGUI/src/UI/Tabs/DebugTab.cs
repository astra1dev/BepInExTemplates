using UnityEngine;
using Bep6.Unity.Il2Cpp.IMGUI.UI.Windows;

namespace Bep6.Unity.Il2Cpp.IMGUI.UI.Tabs;

/// <summary>
/// A tab that displays various Unity-related information.
/// </summary>
public class DebugTab : ITab
{
    public string Name => "Debug";
    public Texture2D Icon => Assets.TabIcons.Debug;

    public void Draw()
    {
        GUILayout.Label($"Mouse Position: {Input.mousePosition}");

        GUILayout.Label("Camera", GUIStylePreset.SectionLabel);
        GUILayout.BeginVertical(GUI.skin.box);
        GUILayout.Label($"Cameras in current scene: {Camera.allCamerasCount}");
        GUILayout.Label($"Camera.main.orthographicSize: {Camera.main?.orthographicSize}");
        GUILayout.EndVertical();

        GUILayout.Label("Scene", GUIStylePreset.SectionLabel);
        GUILayout.BeginVertical(GUI.skin.box);
        GUILayout.Label($"Current scene: {UnityEngine.SceneManagement.SceneManager.GetActiveScene().name}");
        GUILayout.Label($"Root transforms in current scene: {UnityEngine.SceneManagement.SceneManager.GetActiveScene().rootCount}");
        Plugin.LogSceneChanges = GUILayout.Toggle(Plugin.LogSceneChanges, "Log Scene Changes");
        GUILayout.EndVertical();

        GUILayout.Label($"Texture memory usage: {Texture.currentTextureMemory / 1024f / 1024f:0.00} MB");

        SystemInformationWindow.ShowWindow = GUILayout.Toggle(SystemInformationWindow.ShowWindow, "Show System Information");
        ApplicationInformationWindow.ShowWindow = GUILayout.Toggle(ApplicationInformationWindow.ShowWindow, "Show Application Information");

        if (GUILayout.Button("Log Il2Cpp Assemblies"))
        {
            Plugin.Log.LogDebug("\n---------- Assemblies: ----------\n");
            foreach (var assembly in Il2CppSystem.AppDomain.CurrentDomain.GetAssemblies())
            {
                Plugin.Log.LogDebug(assembly.FullName);
            }
            Plugin.Log.LogDebug("\n---------------------------------\n");
        }

        if (GUILayout.Button("Log net6 runtime Assemblies"))
        {
            Plugin.Log.LogDebug("\n---------- Assemblies: ----------\n");
            foreach (var assembly in System.AppDomain.CurrentDomain.GetAssemblies())
            {
                Plugin.Log.LogDebug(assembly.FullName);
            }
            Plugin.Log.LogDebug("\n---------------------------------\n");
        }

        if (GUILayout.Button("Quit Game"))
        {
            Application.Quit();
        }
    }
}
