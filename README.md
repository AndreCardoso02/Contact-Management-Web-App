# Contact Management Web App

Contact Manager is an application developed in aspnet core MVC responsible for controlling and managing cell phone contacts

## Requirements

- Visual Studio 2022 or Visual Studio Code
- .Net 6.0 or highter
- MariaDB 10.6 or highter

## Executing

Change de connection string in appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionString": {
    "MariaDB": "Server=10.25.3.19;DataBase=db;Uid=root;Pwd=root;"
  }
}

```

## Migratin database


Open cmd or teminal control to migrate database (if not exists migrations in your directory) execute

```bash
add-migration "Name of you migration"
```

before just update your database and is done

That will execute the application to

```bash
update-database
```

## Executing Seed

Open cmd or teminal control to seed te user
Username = andremirandacardoso02@gmail.com
Password = 12345

```bash
dotnet run seeddata
```

That will execute the application to

```bash
dotnet run urls=https://localhost:5001
```

