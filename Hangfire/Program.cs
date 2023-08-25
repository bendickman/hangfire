using Hangfire;
using Hangfire.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host
    .CreateDefaultBuilder()
    .ConfigureWebHostDefaults(builder =>
    {
        builder.Configure(app =>
        {
            app.UseHangfireDashboard("/job-dashboard");

            RecurringJob.AddOrUpdate<ProcessJobServiceA>("process-job-service-a", x => x.Process(), Cron.Daily(9), new RecurringJobOptions { TimeZone = TimeZoneInfo.Local });
        });
    })
    .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddScoped<ProcessJobServiceA>();

        services.AddHangfire(opt =>
        {
            opt.UseInMemoryStorage();
            // OR opt.UseSqlServerStorage("your-connection-string");
        });

        services.AddHangfireServer();
    })
    .Build()
    .RunAsync();