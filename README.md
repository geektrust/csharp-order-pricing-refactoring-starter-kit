# App

A simple C# console application that processes command-line instructions like `PLACE_ORDER` and `TOTAL_COST`.

---

## 🚀 How to Run

### 1. **Restore Dependencies**
```bash
dotnet restore
```

### 2. **Build the Project**
```bash
dotnet build
```

### 3. **Run the App**
Pass commands as arguments inside quotes:

```bash
dotnet run --project App -- "PLACE_ORDER 101 Apple 5" "TOTAL_COST 101"
```

> ✅ Each string represents a command and its arguments.

---

## 🧪 Run Tests

Unit tests are located in the `App.Tests` project.

```bash
dotnet test
```

---

## 🗂️ Project Structure

```
App.sln
├── App/              # Console app source code
│   └── Program.cs
│
├── App.Tests/        # xUnit test project
│   └── UnitTest1.cs
│
└── README.md         # This file
```

---

## 📌 Example Commands

```text
PLACE_ORDER 101 Apple 5
TOTAL_COST 101
```

---

## 🛠️ Implementation Notes

- Commands are parsed in `Program.cs → Handle(string input)`.
- Extend the `Handle` method to implement actual business logic.
- State can be maintained via static dictionaries or service classes.

---
