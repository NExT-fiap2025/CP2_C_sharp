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

---

## ✅ Evidências de Teste

### 🧪 Cenário 1: Login de novo usuário

```
Digite seu nome: João
Usuário não encontrado. Novo usuário criado.
Login efetuado com sucesso! ID do usuário: 1

--- Pagamentos Pendentes ---
Nenhum pagamento pendente. Obrigado!
```

---

### 🧪 Cenário 2: Pagamento com cartão (status: concluído)

```
***** Sistema de Processamento de Pagamentos *****
1 - Cartão
2 - Boleto
3 - Ver pagamentos
4 - Sair
Escolha uma opção: 1

Informe o número do cartão: 1234-5678-9012-3456
Informe o valor do pagamento: 150.50
Pagamento CONCLUÍDO com cartão. ID Transação: C4A1B2C3
```

---

### 🧪 Cenário 3: Pagamento com boleto (status: pendente)

```
Escolha uma opção: 2

Informe o código de barras: 99998888777766665555444433332222
Informe o valor do pagamento: 200
Pagamento registrado como PENDENTE com boleto. ID Transação: B5F93D21
```

---

### 🧪 Cenário 4: Login com usuário existente e exibição automática de pendentes

```
Digite seu nome: João
Login efetuado com sucesso! ID do usuário: 1

--- Pagamentos Pendentes ---
[3] Boleto | R$ 200.00 | Dados: 99998888777766665555444433332222 | Data: 2025-04-22 19:10:33
```

---

### 🧪 Cenário 5: Consulta de todos os pagamentos

```
Escolha uma opção: 3

--- Pagamentos Realizados ---
[2] Cartão | R$ 150.50 | concluído | Dados: 1234-5678-9012-3456 | Data: 2025-04-22 19:08:50
[3] Boleto | R$ 200.00 | pendente  | Dados: 99998888777766665555444433332222 | Data: 2025-04-22 19:10:33
```

---
