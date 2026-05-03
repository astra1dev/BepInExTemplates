using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using UnityEngine;
using HarmonyLib;

namespace Bep6.Unity.Il2Cpp.IMGUI;

[BepInAutoPlugin]
[BepInProcess("{game}.exe")]
public partial class Plugin : BasePlugin
{
    private Harmony Harmony { get; } = new(Id);
    public new static ManualLogSource Log;

    public override void Load()
    {
        // Plugin startup logic
        Log = base.Log;

        Harmony.PatchAll();

        AddComponent<Menu>();

        Log.LogInfo($"Plugin {Id} is loaded!");
    }
}

public class Menu : MonoBehaviour
{
    // For how to create GUIs, see https://docs.unity3d.com/ScriptReference/GUILayout.html

    // Create a rect for the window
    public Rect windowRect = new(10f, 10f, 200f, 300f);
    public bool showWindow = true;
    public static bool IsToggleEnabled;
    public static float SliderValue;
    public static string TextFieldString = "Text Field";
    public static string TextAreaString = "Text Area";

    // Override OnGUI to draw the window
    public void OnGUI()
    {
        if (!showWindow) return;
        // Set the ID to something unique because it can cause incompatibility with other mods
        // if two mods (plugins) are trying to use the same ID
        windowRect = GUILayout.Window(123, windowRect, (GUI.WindowFunction)WindowFunction, "Window Title");
    }

    // Start is called before the first frame update
    public void Start()
    {
        ImGui.Log.LogInfo("Start() was invoked!");
    }

    // Update is called once per frame
    public void Update()
    {
        // Toggle the window with F1
        if (Input.GetKeyDown(KeyCode.F1))
        {
            showWindow = !showWindow;
        }
    }

    // Window function
    public void WindowFunction(int id)
    {
        // Add a label using GUILayout.Label
        GUILayout.Label($"Window ID: {id}");
        // Add a button using GUILayout.Button
        if (GUILayout.Button("Example Button"))
        {
            ImGui.Log.LogInfo($"Example Button was pressed!");
        }

        // Add a toggle using GUILayout.Toggle
        IsToggleEnabled = GUILayout.Toggle(IsToggleEnabled, "Example Toggle");

        if (IsToggleEnabled)
        {
            // Add your logic here for when the toggle is enabled
            // Ideally you want to create a separate method to handle the toggle state
            // For example, you can log a message like below, but it will spam the console
            // ImGui.Log.LogInfo($"Example Toggle is enabled!");
        }
        else
        {
            // ImGui.Log.LogInfo($"Example Toggle is disabled!");
        }

        // Add a slider using GUILayout.HorizontalSlider
        SliderValue = GUILayout.HorizontalSlider(SliderValue, 0f, 5f);
        GUILayout.Label($"Slider Value: {SliderValue}");
        //ImGui.Log.LogInfo($"Slider value: {SliderValue}");

        // Add a text field using GUILayout.TextField
        //TextFieldString = GUILayout.TextField(TextFieldString);
        //ImGui.Log.LogInfo($"Text field value: {TextFieldString}");

        // Add a text area using GUILayout.TextArea
        //TextAreaString = GUILayout.TextArea(TextAreaString);
        //ImGui.Log.LogInfo($"Text area value: {TextAreaString}");

        // Make the window draggable
        GUI.DragWindow();
    }
}
