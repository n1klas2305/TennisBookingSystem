# TennisBookingSystem

### Technologien
- Datenbank: MySQL (XAMPP 3.3.0)
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

### API starten
```bash
cd api

dotnet run
```

### Test API
```bash
cd api

dotnet test
```

### Generate C# Classes for O/R-Mapping (Object/Relational-Mapping)
```bash
dotnet ef dbcontext scaffold "Server=localhost;Port=3306;Database=TennisCourtBooking;Uid=root;Pwd=;" Pomelo.EntityFrameworkCore.MySql -o Models
```