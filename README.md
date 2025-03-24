# Entity Framework v10: Other Query Improvements (.NET10 and Visual Studio Code)

For more information about this post visit this site:

https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-10.0/whatsnew#linq-and-sql-translation

## 1. Create Azure SQL Server database

Please follow the steps explained in this github repo:

https://github.com/luiscoco/Azure_SQL_database_sample

## 2. Connect to SQL Server with SSMS

Download SSMS (SQL Server Management Studio) and install it:

https://learn.microsoft.com/en-us/ssms/download-sql-server-management-studio-ssms

We connect to the SSMS with the password: Luiscoco123456



## 3. Create the Database and Tables with SSMS

```sql
-- Create the database
CREATE DATABASE Ef10EventsDb;
GO

-- Use the newly created database
USE Ef10EventsDb;
GO

-- Create Events table
CREATE TABLE Events (
    Id INT PRIMARY KEY IDENTITY(1,1),
    City NVARCHAR(100) NOT NULL,
    EventDate DATE NOT NULL,
    EventTime TIME(7) NOT NULL
);

-- Create Attendees table
CREATE TABLE Attendees (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    FOREIGN KEY (EventId) REFERENCES Events(Id)
);

-- Insert sample data into Events
INSERT INTO Events (City, EventDate, EventTime) VALUES
('Madrid', '2025-05-01', '09:00:00.1234567'),
('Barcelona', '2025-06-15', '14:30:00.2345678'),
('Valencia', '2025-07-20', '18:45:00.3456789');

-- Insert sample data into Attendees
INSERT INTO Attendees (Name, EventId) VALUES
('Alice', 1),
('Bob', 1),
('Charlie', 2),
('Diana', 2),
('Eve', 3);
```

```sql
SELECT TOP (1000) [Id]
      ,[Name]
      ,[EventId]
  FROM [Ef10EventsDb].[dbo].[Attendees]
```

```sql
SELECT TOP (1000) [Id]
      ,[City]
      ,[EventDate]
      ,[EventTime]
  FROM [Ef10EventsDb].[dbo].[Events]
```

## 3. Create a new C# Console application with dotnet

We navigate in our hard disk to the location where we would like to create the new C# Console application

Here's the dotnet command to create a new .NET 10 C# console application named EF10_Other_query_improvements:

```
dotnet new console -n EF10_Other_query_improvements -f net10.0
```

After creating the application we review the generated code in the Command Prompt:



## 4. Download and Install Visual Studio Code and open the C# console application

Navigate to the VSCode web page and download it for Windows Operating System

https://code.visualstudio.com/download

![image](https://github.com/user-attachments/assets/08efd3c7-d1e5-422b-ad29-15b316de7ba5)

Install VSCode double clicking on the downloaded file

Navigate to the C# console application location and open it with this command

```
code .
```

## 5. Install Nuget packages

In VSCode in the Terminal window run these commands to install the Entity Framework Nuget packages

```
dotnet add package Microsoft.EntityFrameworkCore --version 10.0.0-preview.2.25163.8
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 10.0.0-preview.2.25163.8
```

We open the csproj file and we confirm both Nuget libraries were already installed in our application

![image](https://github.com/user-attachments/assets/5ab7a35f-3cbf-4210-9bff-e46c803b2cfd)

## 6. Create the folders and files structure

![image](https://github.com/user-attachments/assets/40aa9be4-b8f2-451c-adde-c944a5236ccd)

## 7. Input the Models source code

```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_Other_query_improvements.Models
{
    public class Attendees
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
```

```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_Other_query_improvements.Models
{
    // Entity Definition
    public class Event
    {
        public int Id { get; set; }
        public string City { get; set; }
        public DateOnly EventDate { get; set; }
        public TimeOnly EventTime { get; set; }
        public ICollection<Attendees> Attendees { get; set; }
    }
}
```

## 8. Input the Data source code

```csharp
using EF10_Other_query_improvements.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_Other_query_improvements.Data
{
    // DbContext Definition
    public class AppDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Ef10EventsDb;User Id=sa;Password=Luiscoco123456;TrustServerCertificate=True;");
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().OwnsMany(e => e.Attendees);
        }
    }
}
```

## 9. Input the Program.cs source code

```csharp
using EF10_Other_query_improvements.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer; // Añadir esta directiva using

using var context = new AppDbContext();

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
```

## 10. Run the application in VSCode and verify the results



## 11. Modify the project configuration adding a appsettings.json file to define the database connection string

Please select the soultion frame

![image](https://github.com/user-attachments/assets/0f3eb6e5-b9c9-4d03-804d-0e5fa71da580)

Then we create a new csharp appsettings.json file

![image](https://github.com/user-attachments/assets/56b39f22-8ca7-4aa8-89f3-305948393f02)

![image](https://github.com/user-attachments/assets/719cfcf4-c500-419f-b098-20f5605011f7)

We input the database string configuration in the appsettings.json file

```json
{
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost,1433;Database=Ef10EventsDb;User Id=sa;Password=Luiscoco123456;TrustServerCertificate=True;"
    }
}
```

![image](https://github.com/user-attachments/assets/ce6fcfe2-5eb2-496d-9fe5-44060e2ff83d)

We install the following Nuget package to configure the database connection from Program.cs file

```
dotnet add package Microsoft.Extensions.Hosting
```

![image](https://github.com/user-attachments/assets/d94bf957-4260-47b4-a4eb-2cd875445135)






