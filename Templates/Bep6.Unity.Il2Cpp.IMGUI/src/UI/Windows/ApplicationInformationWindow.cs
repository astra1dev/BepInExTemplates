using UnityEngine;

namespace Bep6.Unity.Il2Cpp.IMGUI.UI.Windows;

/// <summary>
/// A window that displays various application information such as build details, platform, and version.
/// </summary>
public class ApplicationInformationWindow : MonoBehaviour
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
        windowRect = GUILayout.Window(3, windowRect, (GUI.WindowFunction)WindowFunction, "Application Information");
    }

    public void WindowFunction(int id)
    {
        GUILayout.Label($"buildGUID: {Application.buildGUID}");
        GUILayout.Label($"cloudProjectId: {Application.cloudProjectId}");
        GUILayout.Label($"companyName: {Application.companyName}");
        GUILayout.Label($"dataPath: {Application.dataPath}");
        GUILayout.Label($"genuine: {Application.genuine}");
        GUILayout.Label($"identifier: {Application.identifier}");
        GUILayout.Label($"installerName: {Application.installerName}");
        GUILayout.Label($"installMode: {Application.installMode}");
        GUILayout.Label($"internetReachability: {Application.internetReachability}");
        GUILayout.Label($"isFocused: {Application.isFocused}");
        GUILayout.Label($"persistentDataPath: {Application.persistentDataPath}");
        GUILayout.Label($"platform: {Application.platform}");
        GUILayout.Label($"productName: {Application.productName}");
        GUILayout.Label($"runInBackground: {Application.runInBackground}");
        GUILayout.Label($"streamingAssetsPath: {Application.streamingAssetsPath}");
        GUILayout.Label($"systemLanguage: {Application.systemLanguage}");
        GUILayout.Label($"targetFrameRate: {Application.targetFrameRate}");
        GUILayout.Label($"unityVersion: {Application.unityVersion}");
        GUILayout.Label($"version: {Application.version}");
        GUILayout.Label($"HasProLicense: {Application.HasProLicense()}");

        GUI.DragWindow();
    }
}
