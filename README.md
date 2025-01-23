# BlogMaker api

## Install .NET

Download the latest SDK .NET (v9.0.1) here: [SDK .NET](https://dotnet.microsoft.com/fr-fr/download)

Check if it's properly installed by running:

```
dotnet --version
```

## Install Database

Install globally dotnet-ef to its latest version (matching your .NET major version v9.0.1)

Here is a link: [dotnet-ef](https://www.nuget.org/packages/dotnet-ef)

Run a migration update, it will create the database:

```bash
dotnet ef database update
```

## Launch the webapi server

To start the api server, make sure you're in the webapi folder in your terminal and run:

```
dotnet run
```

The webapi server is launched ! :D

The app is running on http://localhost:5090. If you go to this URL, you'll get the swagger.

## Additionnal infos

To add migrations, run:

```bash
dotnet ef add migration-name -o Data/Migrations
```

To drop the database, run:

```bash
dotnet ef database drop
```

then run update:

```bash
dotnet ef database update
```
