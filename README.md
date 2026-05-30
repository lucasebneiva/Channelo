<div align="center">

  <img src="https://github.com/user-attachments/assets/c4f1a97f-c079-4c5c-a0f6-e8658389fd30" alt="Channelo Logo" width="360" />

  <p>
    An open-source team communication platform — clean, fast, and self-hostable.
  </p>

  <!-- Badges -->
  ![Status](https://img.shields.io/badge/status-in%20development-orange?style=flat-square)
  ![License](https://img.shields.io/badge/license-MIT-blue?style=flat-square)
  ![Angular](https://img.shields.io/badge/Angular-21-DD0031?style=flat-square&logo=angular&logoColor=white)
  ![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-10.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)
  ![TypeScript](https://img.shields.io/badge/TypeScript-5.x-3178C6?style=flat-square&logo=typescript&logoColor=white)
  ![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen?style=flat-square)

</div>

---

## 📌 Overview

**Channelo** is an open-source, self-hostable team communication platform inspired by tools like Slack and Discord — but built with simplicity, developer control, and transparency in mind.

Built with **Angular** on the frontend and **ASP.NET Core** on the backend, Channelo is designed to be modular, extensible, and easy to deploy.

> ⚠️ **This project is currently in active development.** Features and APIs are subject to change.

---

## ✨ Features _(planned)_

- 💬 Real-time messaging via **SignalR**
- 🔐 Authentication & role-based access control
- 📁 Channels
- 📎 File sharing
- 🔔 Notifications
- 🔍 Message search
- 🌐 Self-hostable — your data, your server

---

## 🛠️ Tech Stack

| Layer | Technology |
|-|-|
| Frontend | Angular 21, TypeScript, SCSS |
| Backend | ASP.NET Core 10, C# |
| Real-time | SignalR (WebSockets) |
| Database | PostgreSQL | 
| Auth | JWT |
| Deployment | Docker |

---

## 🏗️ Architecture

> Diagrams coming soon.

Channelo follows a clean client/server architecture:
```
channelo/
├── client/          # Angular frontend
├── server/          # ASP.NET Core backend
└── docker-compose.yml
```
---

## 🚀 Getting Started

> Full setup instructions will be added as the project matures.

### Prerequisites

- [Node.js](https://nodejs.org/) (v24+)
- [.NET SDK](https://dotnet.microsoft.com/) (v10.0+)
- [Angular CLI](https://angular.io/cli)

### Frontend

```bash
cd client
npm install
ng serve
```

### Backend

```bash
cd server
dotnet restore
dotnet run
```

---

## 🖼️ Screenshots

> UI previews coming soon. Stay tuned!

---

## 📄 License

Distributed under the **MIT License**. See [`LICENSE`](./LICENSE) for more information.

---

<div align="center">
  <sub>Built with 💙 — contributions, ideas, and feedback are always welcome.</sub>
</div>
