# Hachshara_Insurance-Backend
This is a repository contains the server side of the exam by Hachshara Insurance dev team

## Technologies Used

- .NET Core 6.0
- Entity Framework Core 6.0.0
- SQL Server Express 2022

## Setup

### Prerequisites

- .NET SDK v6.0
- SQL Server (prefer Management Studio 19)

### Configuration

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/Hachshara_Insurance-Backend.git
   cd Hachshara_Insurance-Backend
   
Navigate to the `InsuranceWebApi` directory:

bash
Copy code
cd backend
Update the appsettings.json file with your database connection string.

Running the Server
bash
Copy code
dotnet run
The server will be hosted at http://localhost:5000 (or https://localhost:5001).

### Database Migration

To apply migrations and create the database: 

1. Open a cmd in the directory project and run those commands:
   
   ```bash
   cd `project-location`

2. Execute these command followed by each other:

   ```bash
   cd project-location
   dotnet ef migrations add InitialCreate
   dotnet ef database update

### API Endpoints

1. UsersController:
* GET: /Find/{id} - get specific user by his id
* GET: /Find/All - get all users in the system
* POST: /Insert - insert new user
* PUT: /Update/{id} - update user by id
* DELETE: /{id} - delete user by id

2. InsurancePoliciesController:
* GET: /Find/{id} - get specific policy by its id
* GET: /Find/AllByUserId/{userId} - get all policies the a specific user own
* POST: /Insert - insert new policy
* PUT: /Update/{id} - update policy by id
* DELETE: /{id} - delete policy by id

### Additional Notes
The server side contains a controllers that are intend to communicate with the SQL Server using full-CRUD Functionallity, it was developed modularly and more functionallity or additional db interactions can be added simply as your own to both of them.
