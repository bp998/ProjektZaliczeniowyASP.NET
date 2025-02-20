# ProjektZaliczeniowyASP.NET

## Opis projektu
ProjektZaliczeniowyASP.NET to aplikacja webowa stworzona w technologii **ASP.NET Core MVC**, umożliwiająca zarządzanie studentami, kursami i zapisami na kursy. W projekcie zaimplementowano:
- **CRUD** dla Studentów, Kursów i Zapisów na Kursy
- **Partial Views** dla lepszego zarządzania widokami
- **Web API Controller** dla komunikacji z aplikacjami zewnętrznymi
- **Custom Middleware** do logowania żądań HTTP
- **Uwierzytelnianie i autoryzacja** za pomocą **ASP.NET Identity**
- **Testy jednostkowe** w **NUnit**, z wykorzystaniem **Moq** i **InMemoryDatabase**

---

### **Instalacja zależności**
Przed uruchomieniem projektu, upewnij się, że masz zainstalowane wszystkie wymagane pakiety NuGet:
```bash
dotnet restore
```

### **Budowanie i uruchamianie**
Jeśli projekt nie chce się uruchomić, warto przeprowadzić pełne czyszczenie i odbudowanie:
```bash
dotnet clean
dotnet build
dotnet run
```
Aplikacja powinna być dostępna pod adresem:  
➡ **`https://localhost:5001`** (lub `http://localhost:5000` dla HTTP)

---

## Uruchamianie testów
Projekt zawiera testy jednostkowe napisane w **NUnit**. Możesz je uruchomić za pomocą:
```bash
dotnet test
```
Jeśli chcesz przetestować tylko pojedynczy test, użyj:
```bash
dotnet test --filter "NazwaTestu"
```

---

## 🛠️ Technologie użyte w projekcie
- **ASP.NET Core 8.0 MVC**
- **Entity Framework Core + SQLite**
- **ASP.NET Identity**
- **InMemoryDatabase (do testów)**
- **NUnit + Moq**


