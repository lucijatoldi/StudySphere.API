# StudySphere API

StudySphere API is a backend service for a study room booking system, built with ASP.NET Core. It provides a complete RESTful API for managing study rooms, users, and handling reservations with conflict detection.


---

## ✨ Key Features

- **Full CRUD Operations:** Complete Create, Read, Update, and Delete functionality for both `StudyRooms` and `Users`.
- **Intelligent Reservation System:**
  - Prevents double-booking by checking for time slot overlaps for a specific room.
  - Returns clear `409 Conflict` errors for overlapping requests.
- **Robust Input Validation:**
  - Utilizes `FluentValidation` to ensure data integrity.
  - Validates business rules, such as ensuring reservation end times are after start times and that reservations are not made in the past.
- **Relational Database:**
  - Uses Entity Framework Core to manage a PostgreSQL database.
  - Clearly defines relationships between rooms, users, and reservations.
- **Clean Architecture:**
  - Uses Data Transfer Objects (DTOs) to separate API models from database models, ensuring a secure and maintainable structure.
- **API Documentation:**
  - Integrated `Swashbuckle` for automatic Swagger/OpenAPI documentation, providing an interactive UI for testing the endpoints.

---

## 🛠️ Tech Stack

- **Framework:** ASP.NET Core 9
- **Language:** C#
- **Database:** PostgreSQL
- **ORM:** Entity Framework Core
- **API Documentation:** Swashbuckle (Swagger)
- **Validation:** FluentValidation

---

## 🚀 Getting Started

There are two ways to run this project:

1.  **Using Docker Compose (Recommended):** The easiest way to get up and running.
2.  **Manually (Local Development):** If you prefer to manage the database on your own machine.

---

### Method 1: Running with Docker Compose (Recommended)

This method will automatically build the API, create a PostgreSQL database in a separate container, and run the entire application stack with a single command.

#### Prerequisites

- [Docker Desktop](https://www.docker.com/products/docker-desktop/) installed and running.

#### Steps

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/lucijatoldi/StudySphere.API.git
    cd StudySphere.API
    ```

2.  **Create an environment file:**
    - Create a file named `.env` in the root directory of the project.
    - Add the following line to the file, replacing `your_super_secret_password` with a password of your choice. This password will be used for the PostgreSQL container.
      ```
      POSTGRES_PASSWORD=your_super_secret_password
      ```

3.  **Launch the application:**
    - Run the following command from the root directory:
      ```bash
      docker-compose up --build
      ```
    - The first time you run this, it will download the necessary Docker images and build the API image. Please be patient.
    - The API will automatically apply database migrations on startup.

4.  **You're ready!**
    - The API will be available at `http://localhost:8080`.
    - The interactive Swagger UI will be available at `http://localhost:8080/swagger`.
    - To stop the application, press `Ctrl + C` in the terminal and then run `docker-compose down`.

---

### Method 2: Running Manually on Local Machine

Use this method if you want to run the API directly using the .NET SDK and connect to a PostgreSQL instance running on your host machine.

#### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download) (or your version)
- [PostgreSQL](https://www.postgresql.org/download/)

#### Steps

1.  **Clone and set up the database** as described in the Docker Compose method.
2.  **Configure User Secrets:**
    - This project uses User Secrets to store the connection string for local development.
    - Initialize user secrets from the project directory:
      ```bash
      dotnet user-secrets init
      ```
    - Set the connection string (replace with your actual password):
      ```bash
      dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Database=studysphere_db;Username=postgres;Password=YOUR_PASSWORD"
      ```
3.  **Apply database migrations:**
    ```bash
    dotnet ef database update
    ```
4.  **Run the application:**
    - You can run the project from Visual Studio (F5) or using the .NET CLI:
      ```bash
      dotnet run
      ```