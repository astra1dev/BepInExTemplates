using Bep6.Unity.Il2Cpp.IMGUI.Utilities;
using UnityEngine;

namespace Bep6.Unity.Il2Cpp.IMGUI.UI.Windows;

/// <summary>
/// A window that displays various system information such as hardware and software details.
/// </summary>
public class SystemInformationWindow : MonoBehaviour
{
    public Rect windowRect = new(
        Screen.width / 2f - 200,
        Screen.height / 2f - 150,
        400,
        300
    );

    public static bool ShowWindow;

    private void OnGUI()
    {
        if (!ShowWindow) return;
        windowRect = GUILayout.Window(2, windowRect, (GUI.WindowFunction)WindowFunction, "System Information");
    }

    public void WindowFunction(int id)
    {
        GUILayout.Label("Hardware", GUIStylePreset.SectionLabelCentered);

        IMGUIExtensions.DrawIconTextRow(Assets.Icons.DeviceType, $"<b>Device Type</b>: {SystemInfo.GetDeviceType()}");
        IMGUIExtensions.DrawIconTextRow(Assets.Icons.DeviceModel, $"<b>Device Model</b>: {SystemInfo.GetDeviceModel()}");
        IMGUIExtensions.DrawIconTextRow(Assets.Icons.CPU, $"<b>CPU</b>: {SystemInfo.GetProcessorType()} (Cores: {SystemInfo.GetProcessorCount()}) @ {SystemInfo.GetProcessorFrequencyMHz() / 1000f} GHz");
        IMGUIExtensions.DrawIconTextRow(Assets.Icons.RAM, $"<b>RAM</b>: {SystemInfo.GetPhysicalMemoryMB()} MB");
        IMGUIExtensions.DrawIconTextRow(Assets.Icons.GPU, $"<b>GPU</b>: {SystemInfo.GetGraphicsDeviceName()} (VRAM: {SystemInfo.GetGraphicsMemorySize()} MB, Supports Ray Tracing: {SystemInfo.SupportsRayTracing()})");
        IMGUIExtensions.DrawIconTextRow(Assets.Icons.Battery, $"<b>Battery Level</b>: {SystemInfo.GetBatteryLevel() * 100f}%");

        GUILayout.Label("Software", GUIStylePreset.SectionLabelCentered);

        IMGUIExtensions.DrawIconTextRow(Assets.Icons.OS, $"<b>OS</b>: {SystemInfo.GetOperatingSystem()} ({SystemInfo.GetOperatingSystemFamily()})");
        IMGUIExtensions.DrawIconTextRow(Assets.Icons.DeviceName, $"<b>Device Name</b>: {SystemInfo.GetDeviceName()}");

        GUI.DragWindow();
    }
}
