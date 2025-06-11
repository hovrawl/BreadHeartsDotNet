using System;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Layout;
using BreadHeartsLauncher.Config.Builders.Base;
using BreadHeartsLauncher.Config.Models;
using BreadHeartsLauncher.Helpers;
using CommunityToolkit.Mvvm.Input;

namespace BreadHeartsLauncher.Config.Builders;

public class DirectoryPickerControlBuilder : ControlBuilder<DirectoryPickerControlBuilder>
{
    public override object? Build(LauncherConfig context, PropertyInfo propertyInfo)
    {
        if (context.ConfigModel is not DirectoryPickerConfigModel pickerContext) return new TextBlock();
        var textBox = new TextBox
        {
            DataContext = context,
            Margin = new(0, 0, 37, 0),
            [!TextBox.TextProperty] = new Binding(nameof(context.Value)),
        };
        return new Grid {
            DataContext = context,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Top,
            Children = {
                textBox,
                new Button {
                    Content = "...",
                    DataContext = new {
                        RelayCommand = new RelayCommand(async () => {
                            BrowserDialog dialog = new(
                                pickerContext.BrowserMode,
                                pickerContext.Title,
                                pickerContext.Filter,
                                pickerContext.SuggestedFileName,
                                pickerContext.InstanceBrowserKey);
                            if (await dialog.ShowDialog() is string value) {
                                context.Value = value;
                            }
                        })
                    },
                    HorizontalAlignment = HorizontalAlignment.Right,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Width = 32,
                    [!Button.CommandProperty] = new Binding("RelayCommand")
                }
            }
        };
    }

    public override bool IsValid(Type type)
    {
        return type == typeof(DirectoryPickerConfigModel);
    }
}

    
