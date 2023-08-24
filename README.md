# .NET 6 Console App with Hangfire as a Windows Service

## About

A simple .NET 6 console app, configured to run Hangfire for recurring jobs as a Windows Service.

The Hangfire dashboard can be viewed http://localhost:5000/job-dashboard

Hangfire is running with an in-memory database but can easily be swapped to use MS SQL Server.

The single recurring job is currently configured to run every day at 9:00am using the Cron expression "0 9 * * *" and this can easily be changed accordingly.

Hangfire does provide a useful static class for generating Cron expressions, for example, Cron.Daily(9) will also run the job every day at 9:00am.
