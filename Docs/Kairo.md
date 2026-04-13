# Kairo – Todo List App (Blazor + C#)

## Objectif du projet
Créer **Kairo**, une application web de gestion de tâches permettant d’ajouter, afficher, modifier et supprimer des tâches, avec une base de données persistante.

---

## Technologies utilisées

### Front-end
- Blazor (WebAssembly ou Server)
- Razor Components
- HTML / CSS
- Bootstrap (optionnel)

### Back-end
- C# (.NET)
- ASP.NET Core

### Base de données
- SQL Server (ou SQLite pour dev local)
- Entity Framework Core (ORM)

### Outils
- Visual Studio / VS Code
- .NET SDK
- NuGet Packages

---

## Architecture du projet

### Structure globale
- Client (Blazor UI)
- Server (API ASP.NET Core)
- Data (DbContext + Models)
- Shared (DTOs / modèles communs)

---

## Fonctionnalités

- [ ] Ajouter une tâche
- [ ] Afficher toutes les tâches
- [ ] Modifier une tâche
- [ ] Supprimer une tâche
- [ ] Marquer comme terminée
- [ ] Stockage en base de données

---

##  Modèle de données

```csharp
public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
}