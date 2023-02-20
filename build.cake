var target = Argument("target", "CopyUpdater");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .WithCriteria(c => HasArgument("clean"))
    .Does(() =>
{
    CleanDirectory($"./Maui.ProjectToUpdate/bin");
    CleanDirectory($"./Maui.ProjectTo.Updater/bin");
});

Task("BuildMainProject")
    .IsDependentOn("BuildUpdater")
    .Does(() =>
{
    MSBuild("./Maui.ProjectToUpdate/Maui.ProjectToUpdate.csproj", settings =>
        settings.SetConfiguration("Release")
        .WithRestore()
        .UseToolVersion(MSBuildToolVersion.Default)
        .WithTarget("build")
        .SetPlatformTarget(PlatformTarget.x64)
        .WithProperty("WindowsAppSDKSelvContained", "true")
        .WithProperty("WindowsPackageType", "None")
        .WithProperty("TargetFramework", "net7.0-windows10.0.19041.0")
        .SetVerbosity(Verbosity.Verbose));
});

Task("BuildUpdater")
    .IsDependentOn("Clean")
    .Does(() =>
{
    MSBuild("./Maui.ProjectTo.Updater/Maui.ProjectTo.Updater.csproj", settings =>
        settings.SetConfiguration("Release")
        .WithRestore()
        .UseToolVersion(MSBuildToolVersion.Default)
        .WithTarget("build")
        .SetPlatformTarget(PlatformTarget.x64)
        .WithProperty("WindowsAppSDKSelvContained", "true")
        .WithProperty("WindowsPackageType", "None")
        .WithProperty("TargetFramework", "net7.0-windows10.0.19041.0")
        .SetVerbosity(Verbosity.Verbose));
});

Task("CopyUpdater")
    .IsDependentOn("BuildMainProject")
    .Does(() =>
{
    CopyDirectory($"./Maui.ProjectTo.Updater/bin/x64/{configuration}/net7.0-windows10.0.19041.0/win10-x64", $"./Maui.ProjectToUpdate/bin/x64/{configuration}/net7.0-windows10.0.19041.0/win10-x64/Updater");
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);