﻿using System;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Layout;
using BreadHeartsLauncher.Config.Builders.Base;
using BreadHeartsLauncher.Config.Models;

namespace BreadHeartsLauncher.Config.Builders;

public class BooleanControlBuilder : ControlBuilder<BooleanControlBuilder>
{
    public override object? Build(LauncherConfig context, PropertyInfo propertyInfo)
    {
        return new ToggleSwitch {
            DataContext = context,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalAlignment = HorizontalAlignment.Right,
            OnContent = string.Empty,
            OffContent = string.Empty,
            [!ToggleButton.IsCheckedProperty] = new Binding(propertyInfo.Name)
        };
    }

    public override bool IsValid(Type type)
    {
        return type == typeof(bool) || type == typeof(BoolConfigModel);
    }
}
