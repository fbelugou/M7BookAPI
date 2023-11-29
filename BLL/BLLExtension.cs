﻿using Microsoft.Extensions.DependencyInjection;

namespace BLL;

public class BLLOptions
{
    //Here you can add your custom options
}

public static class BLLExtension
{

    public static IServiceCollection AddBLL(this IServiceCollection services, Action<BLLOptions>? configure = null)
    {
        BLLOptions options = new();
        configure?.Invoke(options);

        
        //Register your services here

        return services;
    }
}