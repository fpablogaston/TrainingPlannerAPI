# TrainingPlannerAPI
API REST para gestión de rutinas de entrenamiento personal desarrollada con ASP.NET Core 8.

## Tecnologías
- ASP.NET Core 8
- Entity Framework Core + Npgsql
- PostgreSQL (Supabase)
- JWT Authentication

## Endpoints
### Autenticación
- POST /api/auth/login — obtener token JWT

### Rutinas
- GET /api/rutinas — listar todas las rutinas
- GET /api/rutinas/{id} — obtener rutina por id
- POST /api/rutinas — crear rutina
- PUT /api/rutinas/{id} — editar rutina
- DELETE /api/rutinas/{id} — eliminar rutina

## Cómo correrlo
1. Clonar el repositorio
2. Configurar los valores en `appsettings.Development.json`
3. Ejecutar migrations: `dotnet ef database update`
4. Correr la API: `dotnet run`

## Demo
API deployada en Azure App Service:  
https://trainingplannerapi-gpa2d9caerfgfpa0.brazilsouth-01.azurewebsites.net/swagger/index.html
