using UnityEngine;
using Bep6.Unity.Il2Cpp.IMGUI.Utilities;

namespace Bep6.Unity.Il2Cpp.IMGUI;

/// <summary>
/// Lazy-loaded Texture2D asset.
/// </summary>
public class TextureAsset(string path, HideFlags hideFlags = HideFlags.HideAndDontSave)
{
    private Texture2D LoadedAsset { get; set; }

    private Texture2D LoadAsset()
    {
        if (LoadedAsset != null)
        {
            return LoadedAsset;
        }

        LoadedAsset = ResourceHelper.LoadTextureFromResources(path);
        LoadedAsset.hideFlags = hideFlags;
        return LoadedAsset;
    }

    public static implicit operator Texture2D(TextureAsset asset)
    {
        return asset.LoadAsset();
    }
}

public abstract class Assets
{
    private const string BasePath = "Bep6.Unity.Il2Cpp.IMGUI.Resources";

    /// <summary>
    /// Icons used for the tab selector buttons in the main window.
    /// </summary>
    public abstract class TabIcons
    {
        public static readonly Texture2D About = new TextureAsset($"{BasePath}.info.png");
        public static readonly Texture2D Debug = new TextureAsset($"{BasePath}.bug.png");
    }

    public abstract class Icons
    {
        public static readonly Texture2D CPU = new TextureAsset($"{BasePath}.cpu.png");
        public static readonly Texture2D GPU = new TextureAsset($"{BasePath}.gpu.png");
        public static readonly Texture2D RAM = new TextureAsset($"{BasePath}.memory-stick.png");
        public static readonly Texture2D Battery = new TextureAsset($"{BasePath}.battery-charging.png");
        public static readonly Texture2D OS = new TextureAsset($"{BasePath}.monitor-cog.png");
        public static readonly Texture2D DeviceName = new TextureAsset($"{BasePath}.monitor.png");
        public static readonly Texture2D DeviceType = new TextureAsset($"{BasePath}.monitor-speaker.png");
        public static readonly Texture2D DeviceModel = new TextureAsset($"{BasePath}.pc-case.png");
    }
}
