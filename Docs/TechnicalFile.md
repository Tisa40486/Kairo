# 🔒 KAIRO – FICHE TECHNIQUE (PERSONNEL)

## ⚠️ Usage
Document interne

---

## 🧱 Stack technique

### Frontend
- Blazor (Server recommandé pour début)
- Razor Components
- Bootstrap (UI rapide)

### Backend
- ASP.NET Core Web API
- C# (.NET 8 ou +)

### Data
- Entity Framework Core
- SQL Server (dev) / SQLite (local test)

---

## 🏗️ Architecture cible

- UI (Blazor)
- API (REST ASP.NET Core)
- Data Layer (EF Core + DbContext)

👉 Communication via HTTP (JSON)

---

## 📦 Structure projet (solution)

- Kairo.Client (Blazor UI)
- Kairo.Api (Controllers REST)
- Kairo.Data (DbContext + Models)
- Kairo.Shared (DTOs)

---

## 🧠 Modèle principal

- Todo
  - Id (int)
  - Title (string)
  - IsCompleted (bool)
  - CreatedAt (DateTime)

---

## 🔄 Logique métier

- CRUD via API
- EF Core pour persistence
- Mapping DTO ↔ Model
- State UI côté Blazor (refresh après requêtes)

---

## 📡 Endpoints API

- GET /api/todos
- GET /api/todos/{id}
- POST /api/todos
- PUT /api/todos/{id}
- DELETE /api/todos/{id}

---

## ⚙️ Règles importantes

- Pas de logique métier dans Blazor UI
- API = seule source de vérité
- Toujours utiliser DTO (pas les entités directement côté client)
- Migrations obligatoires pour chaque changement DB

---

## 🚧 Points critiques

- Gestion async obligatoire (await partout)
- Ne jamais bloquer le thread UI
- Validation côté API + UI
- Gestion erreurs API propre (try/catch + status codes)

---

## 🚀 Next upgrades (plus tard)

- Auth (JWT + Identity)
- Multi-user system
- Priorité / catégories
- Logs système
- Déploiement cloud (Azure / VPS)