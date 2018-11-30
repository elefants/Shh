using Microsoft.AspNetCore.Builder;
using Shh.Services.Noise.Application.Hubs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shh.Services.Noise.Infrastructure.Startup
{
    public static class NoiseAppBuilder
    {
        public static IApplicationBuilder UseNoiseService(this IApplicationBuilder app)
        {
            app.UseSignalR(routes => 
            {
                routes.MapHub<NoiseHub>("/hub/noise");
            });

            return app;
        }
    }
}
