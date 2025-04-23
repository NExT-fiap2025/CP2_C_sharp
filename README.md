# 💳 Sistema de Processamento de Pagamentos (Console App em C#)

Este é um projeto de aplicação console utilizando arquitetura MVCS (Model-View-Controller-Service) para simular o processamento de pagamentos com cartão e boleto, com armazenamento em banco de dados SQLite.

---

## 📌 Funcionalidades

- Login de usuário por nome
- Criação automática de novo usuário se não existir
- Registro de pagamentos via:
  - Cartão (processamento imediato)
  - Boleto (pagamento pendente)
- Visualização do histórico de pagamentos
- Armazenamento persistente com SQLite

---

## 🧱 Estrutura do Projeto

```
.
├── Controller
│   ├── LoginController.cs
│   └── PagamentoController.cs
├── Db
│   └── DbService.cs
├── Model
│   ├── Pagamento.cs
│   └── Usuario.cs
├── Program.cs
├── README.md
├── Service
│   ├── PagamentoService.cs
│   └── UsuarioService.cs
├── View
│   ├── LoginView.cs
│   └── Menu.cs
├── bin
│   └── Release
│       └── net9.0
├── cp2.csproj
├── cp2.sln
├── obj
│   ├── Release
│   │   └── net9.0
└── pagamentos.db
```

---

## ▶️ Como Executar

---

## 📦 Dependências

- [.NET SDK 9.0 ou superior](https://dotnet.microsoft.com/en-us/download)
- [Microsoft.Data.Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite)

### Passos:

```bash
git clone https://github.com/NExT-fiap2025/CP2_C_sharp.git
cd pagamento-console
dotnet restore
dotnet run
```
