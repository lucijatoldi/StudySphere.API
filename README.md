# StudySphere API

StudySphere API is a backend service for a study room booking system, built with ASP.NET Core. It provides a complete RESTful API for managing study rooms, users, and handling reservations with conflict detection.


---

## ? Key Features

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

## ??? Tech Stack

- **Framework:** ASP.NET Core 9
- **Language:** C#
- **Database:** PostgreSQL
- **ORM:** Entity Framework Core
- **API Documentation:** Swashbuckle (Swagger)
- **Validation:** FluentValidation

---

## ?? Getting Started

To get a local copy up and running, follow these steps.

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download) 
- [PostgreSQL](https://www.postgresql.org/download/)
- An API testing tool like [Postman](https://www.postman.com/downloads/) or use the built-in Swagger UI.

### Installation & Setup

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/lucijatoldi/StudySphere.API.git
    cd StudySphere.API
    ```

2.  **Set up the database:**
    - Open PostgreSQL (e.g., using `pgAdmin`).
    - Create a new, empty database named `studysphere_db`.

3.  **Configure the connection string:**
    - In the project root, open `appsettings.json`.
    - Modify the `DefaultConnection` string with your PostgreSQL username and password:
      ```json
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=studysphere_db;Username=postgres;Password=YOUR_PASSWORD"
      }
      ```

4.  **Apply database migrations:**
    - Open the project in Visual Studio or use the terminal.
    - Run the following command to apply all existing migrations and create the database schema:
      ```bash
      dotnet ef database update
      ```

5.  **Run the application:**
    - You can run the project directly from Visual Studio by pressing F5 or by using the .NET CLI:
      ```bash
      dotnet run
      ```
    - The API will be available at the URLs specified in `Properties/launchSettings.json` (e.g., `https://localhost:7123`).
    - The interactive Swagger UI will be available at `/swagger`.