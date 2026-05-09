using UnityEngine;

namespace Bep6.Unity.Il2Cpp.IMGUI.UI.Tabs;

/// <summary>
/// A tab that displays information about the plugin, contributors, and changelog.
/// </summary>
public class AboutTab : ITab
{
    public string Name => "About";
    public Texture2D Icon => Assets.TabIcons.About;

    private static Vector2 _scrollPosition;

    public void Draw()
    {
        GUILayout.Label("Welcome to", GUIStylePreset.Title);
        GUILayout.Label("Bep6.Unity.Il2Cpp.IMGUI", GUIStylePreset.Title);
        GUILayout.Space(25);
        GUILayout.Label("My first plugin");
        GUILayout.Space(20);
        GUILayout.Label("Contributors", new GUIStyle(GUI.skin.label) { fontStyle = FontStyle.Bold, fontSize = 16 });

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Your name", GUILayout.Width(80)))
        {
            Application.OpenURL("https://github.com/your_profile");
        }
        GUILayout.Label("(Owner & Main developer)");
        GUILayout.EndHorizontal();

        GUILayout.Space(15);
        GUILayout.Label("Changelog", new GUIStyle(GUI.skin.label) { fontStyle = FontStyle.Bold, fontSize = 16 });
        _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, false, true);
        GUILayout.Label("v{version}\n• Initial release");
        GUILayout.EndScrollView();
    }
}
