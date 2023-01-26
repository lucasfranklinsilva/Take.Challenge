﻿using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GithubIntegration
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel()
                .Build();
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
