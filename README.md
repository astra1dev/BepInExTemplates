# BepInExTemplates

collection of .NET project templates for BepInEx 6 plugins

# Installation

You will need [.NET 6 or newer](https://dotnet.microsoft.com/download) to use the templates.

Clone this repository, navigate to the root of the cloned repository in your terminal, then run:

```
dotnet new install .
```

This will install the following project templates:

| Templates                                | Short Name                    | Language | Tags                                        |
|------------------------------------------|-------------------------------|----------|---------------------------------------------|
| BepInEx 6 Unity Il2Cpp Plugin with IMGUI | bep6plugin_unity_il2cpp_imgui | [C#]     | BepInEx/BepInEx 6/Plugin/Unity/Il2Cpp/IMGUI |

# Using a template

To use a template, use `dotnet new`.  
If you use Rider or Visual Studio, you will be able to select the templates when creating a new solution.

Example:

```
dotnet new bep6plugin_unity_il2cpp_imgui -n MyPluginName
```

This will create a folder name MyPluginName with an example plugin project.

All templates have additional options. To view them, use `--help` switch. For example:

```
dotnet new bep6plugin_unity_il2cpp_imgui --help
```

will show additional options you can specify when creating a project:

```
Options:
  -T|--TargetFramework  The target framework for the project
                        text - Optional
                        Default: net35

  -D|--Description      Plugin description
                        text - Optional
                        Default: My first plugin

  -V|--Version          Plugin version
                        text - Optional
                        Default: 1.0.0
                        
  -G|--GameName         The name of the game this plugin is for
                        text - Optional
                        Default: MyGame
                        
```

After creating your project, you can open it in your IDE and start developing your plugin.

# Template Information

Currently, the repository contains one template:

## BepInEx 6 Unity Il2Cpp Plugin with IMGUI

This template is for creating a BepInEx 6 plugin for Unity Il2Cpp games. It includes:
- A basic plugin implementation
- A Harmony instance so you can start adding patches immediately
- An easily extendable Unity IMGUI window
- A post-build workflow for automatically copying the built plugin DLL to the BepInEx plugins folder for easy testing. No need to manually copy the DLL after every build!

Here's some steps to get you started:
1. Your project ***will not compile*** out of the box. You'll get an error like `The type or namespace name 'UnityEngine' could not be found (are you missing a using directive or an assembly reference?)`. 
   That's because you need to [reference the game libraries](https://docs.bepinex.dev/master/articles/dev_guide/plugin_tutorial/2_plugin_start.html?tabs=tabid-unityil2cpp#referencing-game-libraries) first.
2. Edit the `BepInProcess` attribute in `Plugin.cs` with the actual name of the game's executable.
3. Create an environment variable that points to your game folder (the folder that contains the game executable). 
   For example, you can create an environment variable named `AMONGUS_DIR` that points to `C:\Program Files (x86)\Steam\steamapps\common\Among Us`. 
   Then open your generated project's .csproj file and edit the post-build copy target to use your environment variable (for example, `AMONGUS_DIR`).
4. Build your project with `dotnet build` to create the plugin DLL and automatically copy it to the BepInEx plugins folder.
5. Run the game to see your plugin in action!
6. For more guides, refer to the official [BepInEx Docs](https://docs.bepinex.dev/master/articles/index.html).

# Credits

- [BepInEx.Templates](https://github.com/BepInEx/BepInEx.Templates) - main inspiration
