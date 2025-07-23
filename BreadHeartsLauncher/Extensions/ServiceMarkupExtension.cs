using System;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace BreadHeartsLauncher.Extensions;

public class ServiceMarkupExtension : MarkupExtension
{
    public Type? ServiceType { get; set; }

    public ServiceMarkupExtension() { }

    public ServiceMarkupExtension(Type serviceType)
    {
        ServiceType = serviceType;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        if (ServiceType == null)
            throw new InvalidOperationException("ServiceType must be specified");

        return App.Services.GetRequiredService(ServiceType);
    }
}