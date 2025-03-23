# EF10_Other_query_improvements

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
