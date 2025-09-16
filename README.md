# EF Core Database-First com Oracle — Exemplo Didático  
**.NET 8 · Entity Framework Core · Oracle.EntityFrameworkCore**  
<br>

> 📌 Este repositório demonstra **Database-First** com **apenas a tabela `TB_CLIENTE`**.  
> 📂 O **script de criação da tabela** está em: `Scripts/TB_CLIENTE.sql`  
> 🔐 **Não publique** sua *connection string* real. Use `appsettings.json`, *User Secrets* ou variáveis de ambiente.  
<br>

---

## 🇧🇷 Português
### 1) Visão geral  
Exemplo **Database-First** com **Oracle** gerando modelo apenas da tabela `TB_CLIENTE` via *scaffold*.  
<br>

### 2) Requisitos  
- **.NET 8 SDK**  
- **Visual Studio 2022** ou **VS Code**  
- Acesso a um banco **Oracle**  
<br>

### 3) Criar o projeto  
    dotnet new console -n EFCoreDataBaseFirst
    cd EFCoreDataBaseFirst

> 💡 **Não apague** o `Hello World` do `Program.cs` (mantém o projeto compilando).  
<br>

### 4) Pacotes NuGet  
    dotnet add package Microsoft.EntityFrameworkCore --version 8.*
    dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.*
    dotnet add package Oracle.EntityFrameworkCore --version 8.21.121

- `Microsoft.EntityFrameworkCore` — Base do EF Core  
- `Microsoft.EntityFrameworkCore.Tools` — Ferramentas (ex.: `Scaffold-DbContext`)  
- `Oracle.EntityFrameworkCore` — Provider Oracle  
<br>

### 5) Criar a tabela `TB_CLIENTE`  
- Execute o script em **`Scripts/TB_CLIENTE.sql`** no seu Oracle.  
<br>

### 6) Scaffold (engenharia reversa) — apenas `TB_CLIENTE`  
**Package Manager Console (Visual Studio):**
    
    Scaffold-DbContext `
      "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=SEU_HOST:1521/SEU_SERVICO;" `
      Oracle.EntityFrameworkCore `
      -OutputDir Model `
      -ContextDir DBContext `
      -Context AppDbContext `
      -DataAnnotations `
      -UseDatabaseNames `
      -Tables TB_CLIENTE `
      -Force

**CLI (.NET):**
    
    dotnet ef dbcontext scaffold ^
      "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=SEU_HOST:1521/SEU_SERVICO;" ^
      Oracle.EntityFrameworkCore ^
      --output-dir Model ^
      --context-dir DBContext ^
      --context AppDbContext ^
      --data-annotations ^
      --use-database-names ^
      --table TB_CLIENTE ^
      --force

> ⚠️ O aviso amarelo sobre *connection string no código* é uma recomendação de segurança.  
<br>

### 7) Conferir classes geradas  
Abra `Model/TB_CLIENTE.cs` e observe: `[Table]`, `[Key]`, `[Column]`.  
<br>

### 8) Exemplo de uso no `Program.cs`  
    using EFCoreDataBaseFirst.DBContext;

    using (var db = new AppDbContext())
    {
        var clientes = db.TB_CLIENTEs.ToList();
        foreach (var c in clientes)
            Console.WriteLine($"{c.ID_CLIENTE}: {c.NOME} {c.SOBRENOME}");
    }

> ℹ️ `TB_CLIENTEs` é o `DbSet` pluralizado pelo scaffold.  
<br>

### 9) Boas práticas  
- Personalizações: use **`partial class`** em arquivo separado (evite editar arquivos gerados).  
- Se renomear `DbSet`s, o scaffold pode recriar nomes originais — rode para pasta temporária e faça *diff* se necessário.  
- **Segredos**: mantenha fora do repositório.  
<br>

---

## 🇺🇸 English
### 1) Overview  
**Database-First** sample with **Oracle**, generating the model for **`TB_CLIENTE` only** via scaffold.  
<br>

### 2) Requirements  
- **.NET 8 SDK**  
- **Visual Studio 2022** or **VS Code**  
- Access to an **Oracle** database  
<br>

### 3) Create the project  
    dotnet new console -n EFCoreDataBaseFirst
    cd EFCoreDataBaseFirst

> 💡 Keep `Hello World` in `Program.cs` so the project builds.  
<br>

### 4) NuGet packages  
    dotnet add package Microsoft.EntityFrameworkCore --version 8.*
    dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.*
    dotnet add package Oracle.EntityFrameworkCore --version 8.21.121

<br>

### 5) Create `TB_CLIENTE`  
- Run **`Scripts/TB_CLIENTE.sql`** in your Oracle database.  
<br>

### 6) Scaffold — `TB_CLIENTE` only  
**Package Manager Console (Visual Studio):**
    
    Scaffold-DbContext `
      "User Id=YOUR_USER;Password=YOUR_PASS;Data Source=YOUR_HOST:1521/YOUR_SERVICE;" `
      Oracle.EntityFrameworkCore `
      -OutputDir Model `
      -ContextDir DBContext `
      -Context AppDbContext `
      -DataAnnotations `
      -UseDatabaseNames `
      -Tables TB_CLIENTE `
      -Force

**.NET CLI:**
    
    dotnet ef dbcontext scaffold ^
      "User Id=YOUR_USER;Password=YOUR_PASS;Data Source=YOUR_HOST:1521/YOUR_SERVICE;" ^
      Oracle.EntityFrameworkCore ^
      --output-dir Model ^
      --context-dir DBContext ^
      --context AppDbContext ^
      --data-annotations ^
      --use-database-names ^
      --table TB_CLIENTE ^
      --force

<br>

### 7) Quick usage in `Program.cs`  
    using EFCoreDataBaseFirst.DBContext;

    using (var db = new AppDbContext())
    {
        var clientes = db.TB_CLIENTEs.ToList();
        foreach (var c in clientes)
            Console.WriteLine($"{c.ID_CLIENTE}: {c.NOME} {c.SOBRENOME}");
    }

<br>

### 8) Best practices  
- Use **`partial class`** for custom logic; avoid editing generated files.  
- If you rename `DbSet`s, the scaffold may recreate original names — scaffold to a temp folder and *diff*.  
- Keep secrets out of source control.  
<br>

---

## 🇪🇸 Español
### 1) Descripción  
Ejemplo **Database-First** con **Oracle**, generando el modelo **solo para `TB_CLIENTE`** mediante *scaffold*.  
<br>

### 2) Requisitos  
- **.NET 8 SDK**  
- **Visual Studio 2022** o **VS Code**  
- Acceso a una base **Oracle**  
<br>

### 3) Crear el proyecto  
    dotnet new console -n EFCoreDataBaseFirst
    cd EFCoreDataBaseFirst

> 💡 Mantén `Hello World` en `Program.cs` para asegurar la compilación.  
<br>

### 4) Paquetes NuGet  
    dotnet add package Microsoft.EntityFrameworkCore --version 8.*
    dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.*
    dotnet add package Oracle.EntityFrameworkCore --version 8.21.121

<br>

### 5) Crear `TB_CLIENTE`  
- Ejecuta **`Scripts/TB_CLIENTE.sql`** en tu Oracle.  
<br>

### 6) Scaffold — solo `TB_CLIENTE`  
**Package Manager Console (Visual Studio):**
    
    Scaffold-DbContext `
      "User Id=TU_USUARIO;Password=TU_CLAVE;Data Source=TU_HOST:1521/TU_SERVICIO;" `
      Oracle.EntityFrameworkCore `
      -OutputDir Model `
      -ContextDir DBContext `
      -Context AppDbContext `
      -DataAnnotations `
      -UseDatabaseNames `
      -Tables TB_CLIENTE `
      -Force

**CLI de .NET:**
    
    dotnet ef dbcontext scaffold ^
      "User Id=TU_USUARIO;Password=TU_CLAVE;Data Source=TU_HOST:1521/TU_SERVICIO;" ^
      Oracle.EntityFrameworkCore ^
      --output-dir Model ^
      --context-dir DBContext ^
      --context AppDbContext ^
      --data-annotations ^
      --use-database-names ^
      --table TB_CLIENTE ^
      --force

<br>

### 7) Uso rápido en `Program.cs`  
    using EFCoreDataBaseFirst.DBContext;

    using (var db = new AppDbContext())
    {
        var clientes = db.TB_CLIENTEs.ToList();
        foreach (var c in clientes)
            Console.WriteLine($"{c.ID_CLIENTE}: {c.NOME} {c.SOBRENOME}");
    }

<br>

### 8) Buenas prácticas  
- Usa **`partial class`** para personalizaciones; evita editar archivos generados.  
- Si renombras `DbSet`s, el scaffold puede recrear nombres originales — genera en una carpeta temporal y compara.  
- No publiques secretos en el repositorio.  
<br>
