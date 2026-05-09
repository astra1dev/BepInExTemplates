using UnityEngine;
using Bep6.Unity.Il2Cpp.IMGUI.UI.Windows;

namespace Bep6.Unity.Il2Cpp.IMGUI.Components;

/// <summary>
/// Listens for keybinds and performs actions when they are pressed.
/// </summary>
public class KeybindListener : MonoBehaviour
{
    public void Update()
    {
        // Toggle the visibility of the main window when F1 is pressed
        if (Input.GetKeyDown(KeyCode.F1))
        {
            MainWindow.ShowWindow = !MainWindow.ShowWindow;
        }
    }
}
