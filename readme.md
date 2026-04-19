# Code-First Databases with Entity Framework Core

Entity Framework Core (EF Core) is beyond the scope of this course and will be covered in depth in the **.NET Data Access** course.

In this hands-on session, you will learn the steps needed to create the **Friends database** using **EF Core Code-First modeling**.  
The database will be populated with C# code and queried using both **C#** and **SQL**, so you can compare C# logic vs SQL for database work.

## Steps to Build a Code-First Database

1. Create your C# model (classes). Populate and test your model.
2. Define the primary keys for each C# class that will become a table.
3. Specify which C# classes should become tables.
4. Set up the connection string to a database.
5. Run an EF Core migration (create a C# model of the database schema).
6. Run an EF Core database update (generate SQL scripts and apply them to create/update the database).
7. Populate the database by connecting to it, filling the model, and saving changes.

## Hands-On Session Topics

- Database First vs Code First
- Code-First modeling in EF Core
- EF Core migrations
- EF Core database updates to create Code-First databases in:
  - SQL Server
  - MariaDB (MySQL)
  - PostgreSQL
- Querying the database using:
  - C# LINQ
  - SQL
