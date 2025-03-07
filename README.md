**ExpensesBackend**
**Overview**
ExpensesBackend is a .NET 8 web API project designed to manage user authentication and expense entries. It uses Entity Framework Core for data access and JWT for authentication.
**Features**
•	User registration and login with JWT authentication.
•	CRUD operations for expense entries.
•	CORS support for cross-origin requests.
•	Swagger for API documentation.
**Technologies Used**
•	.NET 8
•	Entity Framework Core
•	Microsoft SQL Server
•	JWT (JSON Web Tokens)
•	Swagger
•	CORS
**Prerequisites**
•	.NET 8 SDK
•	SQL Server
•	Visual Studio 2022 or later

**Setup Instructions**
1.	**Clone the repository:**
   git clone https://github.com/Srivani-chigurupati/ExpensesBackend.git
   cd ExpensesBackend
2.	**Install the required packages:**
    dotnet restore
3.	Update the database connection string: Update the appsettings.json file with your SQL Server connection string.
4.	**Run database migrations:**
   dotnet ef migrations add InitialCreate
   dotnet ef database update
5.	**Run the application:**
   dotnet run
6.	Access the API documentation: Open your browser and navigate to https://localhost:7047/swagger to view the Swagger UI.

**API Endpoints**
**Authentication**
•	POST /api/Auth/register: Register a new user.
  Request Body: { "UserName": "string", "Password": "string" }
  Response: { "username": "string", "token": "string" }
•	POST /api/Auth/login: Login a user.
  Request Body: { "UserName": "string", "Password": "string" }
  Response: { "username": "string", "token": "string" }

**Entries**
•	GET /api/entries: Get all entries.
  GET /api/entries/{id}: Get an entry by ID.
•	POST /api/entries: Create a new entry.
  Request Body: { "Description": "string", "IsExpense": "bool", "Value": "double" }
•	PUT /api/entries/{id}: Update an entry by ID.
  Request Body: { "Id": "int", "Description": "string", "IsExpense": "bool", "Value": "double" }
•	DELETE /api/entries/{id}: Delete an entry by ID.

**License**
This project is licensed under the MIT License.

   
   

   
   
