using System.Collections.Generic;
using UnityEngine;
using Bep6.Unity.Il2Cpp.IMGUI.UI.Tabs;

namespace Bep6.Unity.Il2Cpp.IMGUI.UI.Windows;

/// <summary>
/// The main Unity IMGUI window of the plugin.
/// </summary>
public class MainWindow : MonoBehaviour
{
    private readonly List<ITab> _tabs = [new AboutTab(), new DebugTab()];
    private static int _selectedTab;

    public Rect windowRect = new(10f, 10f, 450f, 390f);
    public static bool ShowWindow = true;

    // Override OnGUI to draw the window
    public void OnGUI()
    {
        if (!ShowWindow) return;
        if (GUIStylePreset.Button == null) GUIStylePreset.Initialize();
        // Set the ID to something unique because it can cause incompatibility with other mods
        // if two mods (plugins) are trying to use the same ID
        windowRect = GUILayout.Window(1, windowRect, (GUI.WindowFunction)WindowFunction, "Bep6.Unity.Il2Cpp.IMGUI v{version}");
    }

    // Start is called before the first frame update
    public void Start()
    {
        Plugin.Log.LogInfo("Start() was invoked!");
    }

    // Window function
    public void WindowFunction(int id)
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical(GUILayout.Width(90f) /*, GUILayout.ExpandHeight(true)*/);

        // Draw the tab selector buttons
        for (var i = 0; i < _tabs.Count; i++)
        {
            Color backgroundColor = GUI.backgroundColor;

            // The selected tab is highlighted by changing the button's background color
            if (_selectedTab == i)
            {
                GUI.backgroundColor = Color.grey;
            }

            if (GUILayout.Button(new GUIContent($" {_tabs[i].Name}", _tabs[i].Icon, null), GUIStylePreset.TabButton,
                GUILayout.Height(27)))
            {
                _selectedTab = i;
            }

            GUI.backgroundColor = backgroundColor;
        }

        GUILayout.EndVertical();

        // Vertical separator line + invisible space to create gap between the tab selector and the content
        GUILayout.Box("", GUIStylePreset.Separator, GUILayout.Width(1f), GUILayout.Height(340));
        GUILayout.Space(10f);

        GUILayout.BeginVertical();

        _tabs[_selectedTab].Draw();

        GUILayout.EndVertical();

        GUILayout.EndHorizontal();

        // Make the window draggable
        GUI.DragWindow();
    }
}
