using UnityEngine;

namespace Bep6.Unity.Il2Cpp.IMGUI.UI;

/// <summary>
/// Interface for tabs in the main window. Each tab should implement this interface to be displayed in the main window.
/// </summary>
public interface ITab
{
    public string Name { get; }
    public Texture2D Icon { get; }
    public void Draw();
}
