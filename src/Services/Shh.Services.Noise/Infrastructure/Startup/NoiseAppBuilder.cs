using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shh.Services.Noise.Application.Hubs;
using Shh.Services.Noise.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shh.Services.Noise.Infrastructure.Startup
{
    public static class NoiseAppBuilder
    {
        public static IApplicationBuilder UseNoiseService(this IApplicationBuilder app)
        {
            var noiseDatabase = app.ApplicationServices.GetRequiredService<NoiseDatabase>();
            noiseDatabase.SetupIndexes();

            app.UseSignalR(routes => 
            {
                routes.MapHub<NoiseHub>("/hub/noise");
            });

            return app;
        }
    }
}
