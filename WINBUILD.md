## Getting Started

In order to get started with TerrariaOGC on Windows, you will need:

- [Git](https://git-scm.com/downloads)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) that is capable of building .NET Framework 4.0 projects.
- Visual Studio's **Desktop development with C++** workload
- [Terraria Content Conversion Suite](https://github.com/PPrism/TCCS)

### Directory Preparation

First, clone the repository with submodules:

```bash
git clone --recursive https://github.com/PPrism/TerrariaOGC
```

If you already cloned the repository without `--recursive`, run this inside the repository folder:

```bash
git submodule update --init --recursive
```

### Visual Studio / .NET Framework Notes

TerrariaOGC targets .NET Framework 4.0 by default. Visual Studio 2022 and newer do not support .NET Framework 4.0 projects by default, leaving you with a few options:

- Use Visual Studio 2019 or older.
- Retarget the project to .NET Framework 4.5.1 or newer and make any required dependency adjustments.
- Install/copy the .NET Framework 4.0 reference assemblies from the [Microsoft.NETFramework.ReferenceAssemblies.net40 NuGet package](https://www.nuget.org/packages/microsoft.netframework.referenceassemblies.net40).

The reference assemblies are often located at:

```text
C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework
```

Visual Studio also needs the C++ desktop workload installed because the solution builds the native FNA runtime libraries.

### Opening the Solution

```text
TerrariaOGC.sln
```

### Building TerrariaOGC

In Visual Studio, select the desired configuration from the configuration dropdown, such as:

- `Debug`
- `Initial Release`
- `Patched Release`
- `Version 1.01 (1.1.2+)`
- `Version 1.03 (1.2.1.2)`
- `Version 1.09 (1.2.4.1)`
- `XDK Release`

Then build the solution normally.

The selected configuration will be built into the appropriate folder under:

```text
TerrariaOGC/bin/
```

### The 'Content' Folder
Now it is time to setup your 'Content' folder so that the executable can run.

To make things simple, I have developed a conversion program that can setup one's 'Content' folder for TerrariaOGC.
Once the Terraria Content Conversion Suite (TCCS) is downloaded, place the executable and the required 'Prerequisites' folder in the same directory as the 'Content' folder. 
You can then open the executable and follow the instructions to begin conversion. You can find out more about TCCS [here](https://github.com/PPrism/TCCS).

Now your 'Content' folder is ready to go, drag it into the directory where you built your specified version of TerrariaOGC and then you can start the executable without issue. A settings file will be generated after the first run which you can modify afterwards.
