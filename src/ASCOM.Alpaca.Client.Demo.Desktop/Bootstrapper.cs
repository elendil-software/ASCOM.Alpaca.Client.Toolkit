﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using ASCOM.Alpaca.Client.Demo.Desktop.IoC;
using ASCOM.Alpaca.Client.Demo.Desktop.ViewModels;
using ASCOM.Alpaca.Client.Devices;
using Caliburn.Micro;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.AspNetCore;
using System.Windows.Controls;
using ASCOM.Alpaca.Client.Demo.Desktop.Converters;

namespace ASCOM.Alpaca.Client.Demo.Desktop
{
    public class Bootstrapper : BootstrapperBase
    {
        private Container _container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            ConfigureConverters();
            
            var registry = new ServiceRegistry();
            
            registry.Policies.Add<SingletonInstancePolicy>();
            
            registry.Scan(s =>
            {
                s.AssemblyContainingType(typeof(Bootstrapper));
                s.AssemblyContainingType(typeof(DeviceBase));
                s.AssemblyContainingType(typeof(BootstrapperBase));
                s.AssemblyContainingType(typeof(EventAggregator));

                s.Convention<ViewModelConventionScanner>();
                s.WithDefaultConventions();    
            });
            
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("Log-.json", rollingInterval:RollingInterval.Day)
                .CreateLogger();
            registry.AddSingleton<ILoggerFactory>(s => new SerilogLoggerFactory(Log.Logger, true));
            registry.For(typeof(ILogger<>)).Use(typeof(Logger<>));
            
            _container = new Container(registry);
            
            #if DEBUG
            Debug.Write(_container.WhatDidIScan());
            Debug.Write(_container.WhatDoIHave());
            #endif
        }

        protected override object GetInstance(Type service, string key)
        {
            return string.IsNullOrEmpty(key) ? _container.GetInstance(service) : _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return (IEnumerable<object>) _container.GetAllInstances(service);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
        
        public static void ConfigureConverters()
        {
            var oldApplyConverterFunc = ConventionManager.ApplyValueConverter;
            ConventionManager.ApplyValueConverter = (binding, bindableProperty, property) =>
            {
                if (property.Name.EndsWith("RightAscension") && (bindableProperty == TextBox.TextProperty || bindableProperty == TextBlock.TextProperty || bindableProperty == Label.ContentProperty))
                {
                    binding.Converter = new RightAscensionConverter();
                }
                else if (property.Name.EndsWith("Declination") && (bindableProperty == TextBox.TextProperty || bindableProperty == TextBlock.TextProperty || bindableProperty == Label.ContentProperty))
                {
                    binding.Converter = new AngleConverter();
                }
                else if (property.Name.EndsWith("Azimuth") && (bindableProperty == TextBox.TextProperty || bindableProperty == TextBlock.TextProperty || bindableProperty == Label.ContentProperty))
                {
                    binding.Converter = new AngleConverter();
                }
                else if (property.Name.EndsWith("Altitude") && (bindableProperty == TextBox.TextProperty || bindableProperty == TextBlock.TextProperty || bindableProperty == Label.ContentProperty))
                {
                    binding.Converter = new AngleConverter();
                }
                else
                {
                    oldApplyConverterFunc(binding, bindableProperty, property);
                }
            };
        }
    }
}