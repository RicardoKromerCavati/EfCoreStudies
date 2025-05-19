# Entity Framework Core Studies
This repository is being created as I follow the classes from my postgraduate course.

In this README.md I'll include information regarding EF Core that will help me in future, and I hope it will be able to help new developers who are learning about it!

## Infrastructure project
In order to create and use migrations, a few packages must be installed on your project that contains the DbContext.
- [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)
- [Microsoft.EntityFrameworkCore.Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design)
- [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools)
- [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer) - Or the provider of your choice.

### How to create a migration with Package Manager Console
To do this, in your DbContext, it is necessary to create a parameterless constructor.  
`Add-Migration -Name [Migration Name] -StartupProject [Project in which the DbContext is contained]`

### How to apply a migration with Package Manager Console
`Update-Database -StartupProject [Project in which the DbContext is contained] -Connection "Connection String"`

### How to revert database to specific migration with Package Manager Console
`Update-Database [Name of the migration you want to revert to] -StartupProject [Project in which the DbContext is contained] -Connection "Connection String"`

## Infrastructure.Scaffold project
In order to execute the scaffold action, there are three nuget packages that must be installed.

- [Microsoft.EntityFrameworkCore.Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design)
- [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools)
- [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer) - Or the provider of your choice.

The following command is used to retrieve the information from the database and map it to code (with the Package Manager Console):  
`Scaffold-DbContext -StartupProject [Scaffold Project] -Connection "ConnectionString" -Provider [Microsoft.EntityFrameworkCore.ChosenDbProvider] -Project [Scaffold Project]`
