using UnityEngine;

namespace Bep6.Unity.Il2Cpp.IMGUI.UI;

/// <summary>
/// Static class to hold preset GUIStyles for easy reuse and consistent styling across the UI.
/// </summary>
public abstract class GUIStylePreset
{
    public static GUIStyle TabButton;
    public static GUIStyle Title;
    public static GUIStyle Button;
    public static GUIStyle Separator;
    public static GUIStyle Label;
    public static GUIStyle SectionLabel;
    public static GUIStyle SectionLabelCentered;

    public static void Initialize()
    {
        Title = new GUIStyle(GUI.skin.label)
        {
            fontSize = 20,
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleCenter
        };

        Button = new GUIStyle(GUI.skin.button)
        {
            //fontSize = 14,
        };

        TabButton = new GUIStyle(GUI.skin.button)
        {
            fontSize = 18,
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleLeft
        };

        Separator = new GUIStyle(GUI.skin.box)
        {
            normal = { background = Texture2D.grayTexture },
            margin = new RectOffset { top = 4, bottom = 4 },
            padding = new RectOffset(),
            border = new RectOffset()
        };

        Label = new GUIStyle(GUI.skin.label)
        {
            //fontSize = 14,
        };

        SectionLabel = new GUIStyle(GUI.skin.label)
        {
            fontSize = 15,
            //alignment = TextAnchor.MiddleCenter,
            fontStyle = FontStyle.Bold
        };

        SectionLabelCentered = new GUIStyle(GUI.skin.label)
        {
            fontSize = 16,
            alignment = TextAnchor.MiddleCenter,
            fontStyle = FontStyle.Bold
        };
    }
}
