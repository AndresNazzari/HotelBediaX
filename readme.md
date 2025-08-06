# 🏨 HotelBediaX - Backend API

This is the backend of the HotelBediaX application — a RESTful API built using **.NET 7** as part of a technical assessment by FDSA. The goal is to manage tourist destinations by providing full CRUD operations with support for pagination and filtering. It uses **Entity Framework Core** and **SQLite** as the database engine.

---

## 📦 Tech Stack

* [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
* Entity Framework Core
* SQLite
* MediatR
* FluentValidation
* Swagger (Swashbuckle)
* Clean Architecture / Hexagonal Architecture
* Manual mapping between Entities and DTOs
* Dependency Injection via constructors
* SOLID principles

---

## 📁 Project Structure

```bash
HotelBediaX/
│
├── BediaX.API                # HTTP entrypoint (Controllers)
├── BediaX.Application        # Use Cases, DTOs, Interfaces
├── BediaX.Domain             # Domain Entities
├── BediaX.Infrastructure     # Repositories, DbContext, Migrations, SQLITE database
├── BediaX.Shared             # Shared utilities (e.g. Pagination)
└── README.md                 # This file
```

---

## ⚙️ Prerequisites

* [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
* Visual Studio 2022 / JetBrains Rider / VS Code
* Git

---

## 🚀 Run Locally

### 1. Clone the repository

```bash
git clone https://github.com/YOUR-USERNAME/HotelBediaX.git
cd HotelBediaX
```

### 2. Restore NuGet packages

```bash
dotnet restore
```

### 3. Apply Migrations and Create SQLite DB

By default, the application uses SQLite with the connection string:

```
Data Source=./data/bediax.db
```

If the database does not exist, it will be created automatically when running the migration.

To apply the migrations and create the database, run:

```bash
dotnet ef database update --project BediaX.Infrastructure --startup-project BediaX.API
```

> 💡 Make sure you have the `dotnet-ef` tool installed:
>
> ```bash
> dotnet tool install --global dotnet-ef
> ```

---

## ▶️ Run the API

```bash
dotnet run --project BediaX.API
```

The API will be available at:

```
https://localhost:7029
http://localhost:5029
```

---

## 🧲 Swagger UI

Once the application is running, navigate to:

```
https://localhost:7029/swagger
```

There you can explore and test all the endpoints interactively.

---

## 📌 Features

* ✅ Create a new destination
* 📄 List all destinations
* 🔄 Update existing destinations
* ❌ Delete destinations
* 🔍 Filter by name / country / type
* 📃 Paginated results
* 🧲 Fully documented endpoints via Swagger
* 🧱 Built using Clean Architecture principles

---

## 🧼 Notes

* The database file `bediax.db` is automatically created in the `BediaX.Infrastructure/data` folder.
* You can delete the file and rerun migrations to reset the state.
* The API is prepared to handle large datasets (> 200,000 records).

---

## 📢 Contact

For any questions or feedback, feel free to reach out to the project author.
