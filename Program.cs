using EF10_Other_query_improvements.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));
    })
    .Build();

// Using dependency injection correctly:
using var scope = host.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

// Translation for DateOnly.ToDateTime(TimeOnly)
var eventsWithDateTime = context.Events
    .Select(e => new
    {
        e.City,
        EventFullDateTime = e.EventDate.ToDateTime(e.EventTime)
    })
    .ToList();

// Optimization for multiple consecutive LIMITs
var topEvent = context.Events
    .OrderBy(e => e.EventDate)
    .Take(2)
    .Take(1)
    .FirstOrDefault();

// Optimization for use of Count on ICollection<T>
var eventAttendeesCount = context.Events
    .Select(e => new
    {
        e.City,
        AttendeesCount = e.Attendees.Count
    })
    .ToList();

// Optimization for MIN/MAX over DISTINCT
var earliestDistinctEventDate = context.Events
    .Select(e => e.EventDate)
    .Distinct()
    .Min();

//// Translation for DatePart.Microsecond and DatePart.Nanosecond
//var eventMicroseconds = context.Events
//    .Select(e => EF.Functions.DatePart("microsecond", e.EventTime))
//    .ToList();


//var eventNanoseconds = context.Events
//    .Select(e => EF.Functions.DatePart("nanosecond", e.EventTime))
//    .ToList();

// Simplifying parameter names
var cityParam = "Madrid";
var eventsInCity = context.Events
    .Where(e => e.City == cityParam)
    .ToList();

Console.WriteLine("EF10 feature demonstrations completed.");
