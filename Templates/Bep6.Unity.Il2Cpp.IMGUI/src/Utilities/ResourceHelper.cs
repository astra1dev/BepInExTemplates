using UnityEngine;
using System;
using System.Reflection;
using System.IO;

namespace Bep6.Unity.Il2Cpp.IMGUI.Utilities;

public class ResourceHelper
{
    /// <summary>
    /// Loads and returns a texture from a resource path.
    /// </summary>
    /// <param name="path">The path to the resource.</param>
    /// <returns>A <see cref="Texture2D"/> object loaded from the specified resource path.</returns>
    /// <exception cref="ArgumentException">Thrown when the resource cannot be found.</exception>
    public static Texture2D LoadTextureFromResources(string path)
    {
        var texture = new Texture2D(1, 1, TextureFormat.ARGB32, false); // wrapMode = TextureWrapMode.Clamp
        var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
        if (stream != null)
        {
            using MemoryStream ms = new();

            stream.CopyTo(ms);
            texture.LoadImage(ms.ToArray(), false);
        }
        else
        {
            throw new ArgumentException($"Could not find resource {path}");
        }

        //texture.name = path;
        return texture;
    }
}
