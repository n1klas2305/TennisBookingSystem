# TennisBookingSystem

### Technologien
- Datenbank: MySQL (XAMPP)
- Backend: C# (dotnet 6.0.201)
- Frontend: Reactjs (Node v18.8.0)


### UI starten
```bash
cd ui
# Dependencies installieren
npm i
# Entwicklungsserver starten
npm run dev
```


### Generate C# Classes for O/R-Mapping (Object/Relational-Mapping)
```bash
dotnet ef dbcontext scaffold "Server=localhost;Port=3306;Database=TennisCourtBooking;Uid=root;Pwd=;" Pomelo.EntityFrameworkCore.MySql -o Models
```