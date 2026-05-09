using UnityEngine;

namespace Bep6.Unity.Il2Cpp.IMGUI.Utilities;

public class IMGUIExtensions
{
    /// <summary>
    /// Draw a horizontal row with an icon and text.
    /// </summary>
    /// <param name="icon">The icon to display. It will be resized to fit the inlineIconSize.</param>
    /// <param name="text">The text to display next to the icon.</param>
    /// <param name="inlineIconSize">The size of the icon in pixels. Default is 24.</param>
    public static void DrawIconTextRow(Texture2D icon, string text, float inlineIconSize = 24f)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(icon, GUILayout.Width(inlineIconSize), GUILayout.Height(inlineIconSize));
        GUILayout.Label(text);
        GUILayout.EndHorizontal();
    }
}
