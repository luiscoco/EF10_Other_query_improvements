# Entity Framework v10: Other Query Improvements (.NET10 and Visual Studio Code)

For more information about this post visit this site:

https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-10.0/whatsnew#linq-and-sql-translation

## 1. Create Azure SQL Server database



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


## 4. Download and Install Visual Studio Code and open the C# console application


## 5. Install Nuget packages



## 6. Create the folders and files structure



## 7. Input the Models source code



## 8. Input the Data source code



## 9. Input the Program.cs source code



## 10. Run the application in VSCode and verify the results











