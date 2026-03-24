1.This project is a complete authentication system.
It includes:

ASP.NET Core Web API (JWT Auth)
PostgreSQL (Docker)
Vite + React Frontend
Material UI + React Hook Form + Yup

Both backend and frontend are fully working and integrated.

📦 How to Run the Project

1️⃣ Start PostgreSQL (Docker)
If container already exists:
   run docker start postgres-db
If you need to create it:
docker run --name postgres-db ^
  -e POSTGRES_PASSWORD=postgres ^
  -e POSTGRES_DB=authdb ^
  -p 5432:5432 ^
  -d postgres

2️⃣ Run the Backend
cd backend/AuthService
dotnet restore
dotnet ef database update
dotnet run

API + Swagger will be available at: https://localhost:<PORT>/swagger (you can also use Postman)

3️⃣ Run the Frontend
cd frontend
npm install
npm run dev
Frontend runs at:http://localhost:5173

🔐 API Endpoints
Register
POST /api/auth/register
Login (returns JWT)
POST /api/auth/login
Get Logged‑In User (Protected)
GET /api/auth/getUser
Header: Authorization: Bearer <token>

🧭 Frontend Pages

/register → Create account
/login → Login + receive token
/getuser → Protected page showing user details

✔ Notes
Backend must be running before login works.
PostgreSQL must be running in Docker.
CORS is configured for http://localhost:5173.
All build artifacts (bin/obj/node_modules/dist) are ignored.

🛠 Tech Stack
Backend: ASP.NET Core 8, EF Core, JWT, BCrypt
Database: PostgreSQL (Docker)
Frontend: Vite + React, Material UI, React Hook Form, Yup
