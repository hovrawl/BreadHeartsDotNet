using System;
using System.Reflection;
using BreadHeartsLauncher.Config.Models;

namespace BreadHeartsLauncher.Config.Builders.Base;

public abstract class ControlBuilder<T> : IControlBuilder where T : ControlBuilder<T>, new()
{
    public static T Shared { get; } = new();

    public abstract object? Build(LauncherConfig context, PropertyInfo propertyInfo);
    public abstract bool IsValid(Type type);
}
