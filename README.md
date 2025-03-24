# Entity Framework v10: Other Query Improvements (.NET10 and Visual Studio Code)

For more information about this post visit this site:

https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-10.0/whatsnew#linq-and-sql-translation

## Prerequisite: install .NET 10 

We download .NET 10 from this website:

https://dotnet.microsoft.com/en-us/download/dotnet/10.0

![image](https://github.com/user-attachments/assets/2d967cec-2407-4f67-95c6-de86fe486563)

We install the downloaded file double clicking on it

## 1. Create Azure SQL Server database

Please follow the steps explained in this github repo:

https://github.com/luiscoco/Azure_SQL_database_sample

We first search for Azure SQL resource

![image](https://github.com/user-attachments/assets/1e18d42e-2382-4212-bd68-61412d7e0720)

We press the Create Azure SQL resource button

![image](https://github.com/user-attachments/assets/148d7f15-07e8-421b-8df1-64c99781f367)

We have to create a Single database 

![image](https://github.com/user-attachments/assets/69f566b6-393b-4868-a6ee-b5bed6b7afc8)

We press the Apply Offer button

![image](https://github.com/user-attachments/assets/e0d6209e-62bd-4cee-8fca-e557b2418ab3)

We set the subscription name, resource group name, region and the database name

![image](https://github.com/user-attachments/assets/19343c8b-4b3a-41aa-b77f-4608bc04766a)

We also have to create a server name

![image](https://github.com/user-attachments/assets/7495643e-985e-4ecf-8a96-6d73b1c0cfe9)

![image](https://github.com/user-attachments/assets/157526de-7503-48cf-935b-59144ff1e528)

![image](https://github.com/user-attachments/assets/17bcf7c6-735d-4d4c-998f-fe1f0a28ed58)

When we select the free option the Auto-pause the database until next month option is automatically selected

![image](https://github.com/user-attachments/assets/ebf9a7a3-57f2-4348-be12-046ff129aa0e)

We set the Networking options

![image](https://github.com/user-attachments/assets/6983865f-fb9a-4166-a6e4-8b3425ac3275)

![image](https://github.com/user-attachments/assets/fe0a18c5-c165-4972-9c6e-e92e8ed4c0c2)

We leave the default values in the rest of options and finally we press the Create button 

![image](https://github.com/user-attachments/assets/01403a13-d7f4-4011-b93c-cc6030f064c5)

We press the Go to resource button

![image](https://github.com/user-attachments/assets/5b056a20-f1ac-4886-9475-8fbcbda5875f)

We select the Query Editor and connect to the database

![image](https://github.com/user-attachments/assets/3e9d390c-5c26-4119-b9a2-b659a95e8607)

We have now available a Query window to input and run the SQL commands

![image](https://github.com/user-attachments/assets/32bda14e-918d-420a-9392-33f025721f3b)

## 2. Connect to Azure SQL database with SSMS or VSCode

Download SSMS (SQL Server Management Studio) and install it:

https://learn.microsoft.com/en-us/ssms/download-sql-server-management-studio-ssms

We connect to the SSMS with the password: Luiscoco123456

Server type: Database Engine

Server name: myserverluis.database.windows.net,1433

Authentication:SQL Server Authentication

Login: adminluis

Password:Luiscoco123456

![image](https://github.com/user-attachments/assets/97b1a886-5a93-4aaa-8ed8-cea5425c135c)

For connecting to the Azure SQL database from VSCode install this extension

![image](https://github.com/user-attachments/assets/822fd8b6-4bda-4d40-b518-6064851de640)

We have to click on SQL Server button in left hand side menu and we create a new connection clicking on the + button

![image](https://github.com/user-attachments/assets/ef468ef8-190c-4fcd-8b3b-8105b9b64e6e)

We input the Azure SQL database connection information. 

We select the connection string option and we press the connect button

```
Server=tcp:myserverluis.database.windows.net,1433;Initial Catalog=Ef10EventsDb;Persist Security Info=False;User ID=adminluis;Password=Luiscoco123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
```

![image](https://github.com/user-attachments/assets/8b595829-5903-4764-bf9b-88d0c432bd3c)

## 3. Create the Database and Tables with SSMS

We run this sql query for creating a new database

```sql
-- Create the database
CREATE DATABASE Ef10EventsDb;
GO

-- Use the newly created database
USE Ef10EventsDb;
GO
```

![image](https://github.com/user-attachments/assets/7522b332-9968-4575-bcd2-cfc9ab1ce7a6)

We run this sql query for creating the new tables

```sql
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
```

We run this sql query for populating the new tables with data

```sql
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

We verify the database and tables created running these sql queries

```sql
SELECT TOP (1000) [Id]
      ,[Name]
      ,[EventId]
  FROM [Ef10EventsDb].[dbo].[Attendees]
```

![image](https://github.com/user-attachments/assets/cd04b3e5-30af-4124-b5f6-f6c86a054583)

```sql
SELECT TOP (1000) [Id]
      ,[City]
      ,[EventDate]
      ,[EventTime]
  FROM [Ef10EventsDb].[dbo].[Events]
```

![image](https://github.com/user-attachments/assets/73f00191-3532-4afc-9d86-90284ed32fdf)

We can also run the above sql queries from VSCode

![image](https://github.com/user-attachments/assets/1e58b37e-357e-45e4-9499-c4263d063a61)

## 4. Create a new C# Console application with dotnet

We navigate in our hard disk to the location where we would like to create the new C# Console application

Here's the dotnet command to create a new .NET 10 C# console application named EF10_Other_query_improvements:

```
dotnet new console -n EF10_Other_query_improvements -f net10.0
```

After creating the application we review the generated code in the Command Prompt

## 5. Download and Install Visual Studio Code and open the C# console application

Navigate to the VSCode web page and download it for Windows Operating System

https://code.visualstudio.com/download

![image](https://github.com/user-attachments/assets/08efd3c7-d1e5-422b-ad29-15b316de7ba5)

Install VSCode double clicking on the downloaded file

Navigate to the C# console application location and open it with this command

```
code .
```

## 6. Install Nuget packages

In VSCode in the Terminal window run these commands to install the Entity Framework Nuget packages

```
dotnet add package Microsoft.EntityFrameworkCore --version 10.0.0-preview.2.25163.8
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 10.0.0-preview.2.25163.8
```

We open the csproj file and we confirm both Nuget libraries were already installed in our application

![image](https://github.com/user-attachments/assets/5ab7a35f-3cbf-4210-9bff-e46c803b2cfd)

## 7. Create the folders and files structure

![image](https://github.com/user-attachments/assets/40aa9be4-b8f2-451c-adde-c944a5236ccd)

## 8. Input the Models source code

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

## 9. Input the Data source code

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
            optionsBuilder.UseSqlServer("Server=tcp:myserverluis.database.windows.net,1433;Initial Catalog=Ef10EventsDb;Persist Security Info=False;User ID=adminluis;Password=Luiscoco123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().OwnsMany(e => e.Attendees);
        }
    }
}
```

## 10. Input the Program.cs source code

We are going to define the code for the new EF10 features


### 10.1. Translation for DateOnly.ToDateTime(TimeOnly)

EF10 now supports translating the combination of DateOnly and TimeOnly into a proper SQL DATETIME type.

**EF10 C# code**

```csharp
var eventsWithDateTime = context.Events
    .Select(e => new
    {
        e.City,
        EventFullDateTime = e.EventDate.ToDateTime(e.EventTime)
    })
    .ToList();
```

**SQL Query**

```sql
SELECT [e].[City],
       DATEADD(MILLISECOND, 
               DATEDIFF(MILLISECOND, '00:00:00', CAST([e].[EventTime] AS time)), 
               CAST([e].[EventDate] AS datetime)) AS [EventFullDateTime]
FROM [Events] AS [e];
```

![image](https://github.com/user-attachments/assets/3f52c54d-b634-4c8d-80ce-0ddaa3135352)

### 10.2. Optimization for multiple consecutive .Take() calls

Prior to EF10, multiple .Take() calls would result in nested or redundant SQL.

Now EF optimizes it into a single LIMIT/TOP clause.

**EF10 C# code**

```csharp
var topEvent = context.Events
    .OrderBy(e => e.EventDate)
    .Take(2)
    .Take(1)
    .FirstOrDefault();
```

**SQL Query**

```sql
SELECT TOP(1) [e].[Id], [e].[City], [e].[EventDate], [e].[EventTime]
FROM [Events] AS [e]
ORDER BY [e].[EventDate];
```

![image](https://github.com/user-attachments/assets/3d2a9db2-be39-4ba3-b7d8-2125f49964c6)

### 10.3. Optimization for Count on ICollection<T>

Now efficiently translates .Count on a navigation collection (ICollection<T>) without loading related entities.

**EF10 C# code**

```csharp
var eventAttendeesCount = context.Events
    .Select(e => new
    {
        e.City,
        AttendeesCount = e.Attendees.Count
    })
    .ToList();
```

**SQL Query**

```sql
SELECT [e].[City],
       (SELECT COUNT(*)
        FROM [Attendees] AS [a]
        WHERE [e].[Id] = [a].[EventId]) AS [AttendeesCount]
FROM [Events] AS [e];
```

![image](https://github.com/user-attachments/assets/09351232-9fbd-4900-ab3e-b1acb36c5225)

### 10.4. Optimization for MIN/MAX over DISTINCT

EF10 can now combine DISTINCT with MIN or MAX efficiently — previously might fetch all distinct values and calculate in memory.

**EF10 C# code**

```csharp
var earliestDistinctEventDate = context.Events
    .Select(e => e.EventDate)
    .Distinct()
    .Min();
```

**SQL Query**

```sql
SELECT MIN([t].[EventDate]) AS [MinEventDate]
FROM (
    SELECT DISTINCT [e].[EventDate]
    FROM [Events] AS [e]
) AS [t];
```

![image](https://github.com/user-attachments/assets/3ccf6ab6-2d61-4bc0-bd9a-00fa4c287f69)

### 10.5. Translation for DatePart.Microsecond and DatePart.Nanosecond

EF.Functions.DatePart() now supports new parts like "microsecond" and "nanosecond" — this was unsupported in earlier versions.

**EF10 C# code**

```csharp
var eventMicroseconds = context.Events
    .Select(e => EF.Functions.DatePart("microsecond", e.EventTime))
    .ToList();

var eventNanoseconds = context.Events
    .Select(e => EF.Functions.DatePart("nanosecond", e.EventTime))
    .ToList();
```

**SQL Query**

```sql
SELECT DATEPART(MICROSECOND, [e].[EventTime]) AS [Microseconds]
FROM [Events] AS [e];

SELECT DATEPART(NANOSECOND, [e].[EventTime]) AS [Nanoseconds]
FROM [Events] AS [e];
```

![image](https://github.com/user-attachments/assets/fb5940f5-32a3-404a-bc30-d23e3161fcc8)

![image](https://github.com/user-attachments/assets/797a34be-4f85-4497-85cf-c64fda7014db)

### 10.6. Simplified parameter usage

EF10 improves parameter naming and reuse for better SQL clarity and caching efficiency.

**EF10 C# code**

```csharp
var cityParam = "Madrid";
var eventsInCity = context.Events
    .Where(e => e.City == cityParam)
    .ToList();
```

**SQL Query**

```sql
DECLARE @__cityParam_0 nvarchar(max) = N'Madrid';

SELECT [e].[Id], [e].[City], [e].[EventDate], [e].[EventTime]
FROM [Events] AS [e]
WHERE [e].[City] = @__cityParam_0;
```

![image](https://github.com/user-attachments/assets/d5290bea-d557-4770-b1e3-f004204fd5f4)

### 10.7. Whole EF10 new features source code 

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

## 11. Run the application in VSCode and verify the results

Execute this command in the **Terminal** for running the application

```
dotnet run
```

## 12. Modify the project configuration adding a appsettings.json file to define the database connection string

Please select the soultion frame

![image](https://github.com/user-attachments/assets/0f3eb6e5-b9c9-4d03-804d-0e5fa71da580)

Then we create a new csharp **appsettings.json** file

![image](https://github.com/user-attachments/assets/56b39f22-8ca7-4aa8-89f3-305948393f02)

![image](https://github.com/user-attachments/assets/719cfcf4-c500-419f-b098-20f5605011f7)

Copy from Azure the database string configuration in the **appsettings.json** file

![image](https://github.com/user-attachments/assets/5775ba2d-c362-462e-bf32-bd97771eb962)

```json
{
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost,1433;Database=Ef10EventsDb;User Id=adminluis;Password=Luiscoco123456;TrustServerCertificate=True;"
    }
}
```

![image](https://github.com/user-attachments/assets/ce6fcfe2-5eb2-496d-9fe5-44060e2ff83d)

We install the following **Nuget package** to configure the database connection from **Program.cs** file

```
dotnet add package Microsoft.Extensions.Hosting
```

![image](https://github.com/user-attachments/assets/d94bf957-4260-47b4-a4eb-2cd875445135)


We input the following additional code in Program.cs:

```csharp
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
```

We also have to modify the DbContext file

```csharp
using EF10_Other_query_improvements.Models;
using Microsoft.EntityFrameworkCore;

namespace EF10_Other_query_improvements.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().OwnsMany(e => e.Attendees);
        }
    }
}
```

![image](https://github.com/user-attachments/assets/8bf78f61-3bc0-4041-8d50-4ef4b8d2a058)

We run the application with the following command and we verify the results

```
dotnet run
```

![image](https://github.com/user-attachments/assets/0878e200-0ce4-4043-ad87-a03ff4d08610)

![image](https://github.com/user-attachments/assets/30c4563f-f224-495a-b89d-4cb392f28b82)

## 13. How to debug your C# Console application in VSCode

First we have to modify the csproj file and add the following item in the project tag:

```
  <ItemGroup>
    <None Update="appsettings.json">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
  </ItemGroup>
```

See the updated csproj file

![image](https://github.com/user-attachments/assets/e18777a4-3ecd-4118-9fe1-88cbe244b279)

Then we set the breakpoint in the code

![image](https://github.com/user-attachments/assets/9aae4622-3369-4d97-abbb-b07f8eddba9d)

Finally we select the Debug menu option 

![image](https://github.com/user-attachments/assets/d8af3e06-0a68-4691-864f-566a1756d328)

Or we can click on the Debug green triangle icon in the left hand side menu

![image](https://github.com/user-attachments/assets/4368799c-d5dd-4a2d-8ae4-3c2b9967e83c)

![image](https://github.com/user-attachments/assets/11a2ecf5-da1f-4366-a97f-0fe2397acad0)

Now appears the Debug toolbar and we can start debut our code

![image](https://github.com/user-attachments/assets/0f410f8f-e9ab-414b-b121-dccd8a1c39e2)

We can inspect the variables content

We select the variable name and we select the Add to Watch

![image](https://github.com/user-attachments/assets/f89a2052-558e-4b48-92f4-7c9f82af812d)

![image](https://github.com/user-attachments/assets/f1d94440-9112-455f-a4fd-62b9a7772a96)





