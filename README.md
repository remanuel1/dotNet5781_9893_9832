# 🚌 Bus Management System

A desktop application for managing a public bus transportation system, built with WPF and .NET Framework 4.8.  
Developed as part of an academic project (dotNet 5781).

---

## 📋 Overview

The system allows two types of users — **administrators** and **regular users** — to manage and interact with a public bus network. It supports managing buses, lines, stations, schedules, and users through a graphical interface.

---

## ✨ Features

### 👤 User Management
- User registration and login (with password visibility toggle)
- Two roles: **Manager** and **User**
- Add, update, and delete users

### 🚌 Bus Management
- Add, update, and delete buses
- License plate validation based on registration year (pre/post 2018 format)
- Track fuel level — refuel action
- Track maintenance — last treatment date and km since last treatment
- Bus status tracking (Ready / In Ride / Needs Treatment)

### 🛣️ Bus Lines
- Add and manage bus lines
- Assign stations to lines with ordering
- Group lines by area
- Remove stations from lines

### 🏠 Bus Stations
- Add, update, and delete bus stations
- View which lines pass through each station
- Geographic coordinates support (latitude/longitude)

### ⏱️ Line Timing
- View upcoming departures from a station by time
- Schedule-based ride planning

### 💾 Data Storage
- Dual storage support: **In-Memory objects** (DLObject) and **XML files** (DLXML)
- Configurable via `DLConfig`

---

## 🏗️ Architecture

The project follows a clean **layered architecture**:

```
PL  (Presentation Layer — WPF UI)
 └── BL  (Business Logic Layer)
      └── APIDAL  (DAL Interface)
           ├── DLObject  (In-memory data)
           └── DLXML     (XML-based persistence)
                └── DS  (Data Source / seed data)
```

| Project | Role |
|---------|------|
| `PL` | WPF Windows — all UI screens |
| `BL` | Business rules, validation, adapters |
| `APIDAL` | Interfaces and data objects (DO) |
| `DLObject` | Data access — in-memory |
| `DLXML` | Data access — XML files |
| `DS` | Static data source with initial data |

Design patterns used: **Singleton**, **Factory**, **Adapter (DO↔BO)**.

---

## 🖥️ Requirements

- **OS:** Windows 10 / 11
- **Runtime:** .NET Framework 4.8 (included in Windows by default)
- **IDE:** Visual Studio 2019 or 2022 (Community edition is free)
  - Required workload: **.NET desktop development**

---

## 🚀 Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/remanuel1/dotNet5781_9893_9832.git
   ```

2. Open the solution file in Visual Studio:
   ```
   dotNet5781_9893_9832.sln
   ```

3. Set **PL** as the startup project (right-click → *Set as Startup Project*)

4. Build the solution: `Ctrl + Shift + B`

5. Run: `F5`

---

## 📁 Project Structure

```
dotNet5781_9893_9832/
├── PL/              # WPF UI (windows, forms)
├── BL/              # Business logic
├── APIDAL/          # DAL interfaces & data objects
├── DLObject/        # In-memory data layer
├── DLXML/           # XML-based data layer
├── DS/              # Data source (initial seed data)
├── bin/
│   └── xml/         # XML data files
└── dotNet5781_9893_9832.sln
```

---

## 👩‍💻 Authors

Developed by students 9893 & 9832 as part of the dotNet 5781 course.
