# Finance Tracker Backend

This is the backend for a finance tracking application.
## Tools
- C#
- ASP.NET
- Entity Framework
- PostgreSQL

## Installation
1. Clone this repository to your local machine using `git clone https://github.com/s04v/finance-tracker-backend.git`.
2. Open the solution in Visual Studio.
3. Restore the NuGet packages.
4. Set up a PostgreSQL database and update the connection string in `appsettings.json`.
5. Run the migration by executing `Update-Database` command in Package Manager Console.
6. Build and run the application.

## Endpoints

### User
- POST `/api/user/register`: Create a new user.
- POST `/asi/user/login`: Authorization.
- GET `/api/user`: Get current user.

### Budget
- POST `/api/budget`: Create a new budget.
- GET `/api/budget/{id}`: Create budget by ID.
- GET `/api/budget`: Get all budgets for current user.

### Transaction
- POST `/api/budget/{budgetId}/transaction`: Create a new transaction.
- GET `/api/budget/{budgetId}/transaction`: Get all transactions for a budget by budget ID.
- GET `/api/budget/{budgetId}/transaction/{id}`: Get transaction by ID.
## Database Schema

User
- Id (int)
- Name (string)
- Login (string)
- Password (string)

Budget
- Id (int)
- Name (string)
- Amount (float)
- UserId (int)

Transaction
- Id (int)
- Type (enum)
- Category (enum)
- Amount (float)
- BudgetId (int)
- Time (datetime)
