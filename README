# Todo API

A simple RESTful Todo API built with:

* ASP.NET Core (.NET 8)
* PostgreSQL
* Entity Framework Core
* C# 12

---

## Features

* Create Todo
* Get All Todos
* Get Todo By Id
* Update Todo
* Delete Todo
* PostgreSQL database integration
* DTO validation
* Service layer architecture

---

## Project Structure

```text
TodoApi/
│
├── Controllers/
├── DTOs/
├── Models/
├── Services/
├── Data/
├── Migrations/
├── Program.cs
└── appsettings.json
```

---

## Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL


---

## Setup Instructions

### 1. Clone the repository

```bash
git clone <repository-url>
cd TodoApi
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure PostgreSQL

Update `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=todo_db;Username=postgres;Password=yourpassword"
}
```

### 4. Apply migrations

```bash
dotnet ef database update
```

### 5. Run the application

```bash
dotnet run
```

---

## API Endpoints

| Method | Endpoint         | Description    |
| ------ | ---------------- | -------------- |
| GET    | `/api/todo`      | Get all todos  |
| GET    | `/api/todo/{id}` | Get todo by id |
| POST   | `/api/todo`      | Create todo    |
| PUT    | `/api/todo/{id}` | Update todo    |
| DELETE | `/api/todo/{id}` | Delete todo    |

---

## Example Request

### Create Todo

```http
POST /api/todo
Content-Type: application/json
```

```json
{
  "Name": "Learn ASP.NET Core"
}
```

---

## Validation

The API validates:

* Required title
* Minimum title length

---

## Author

Nanor Bright Suka
