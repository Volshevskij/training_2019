﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Totalizer.Startup))]

namespace Totalizer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}