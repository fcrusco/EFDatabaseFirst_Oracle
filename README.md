# EF Core Database-First com Oracle — Exemplo Didático  
**.NET 8 · Entity Framework Core · Oracle.EntityFrameworkCore**  
<br>

> 📚 Este README reúne o passo a passo usado em aula para **engenharia reversa** (Scaffold-DbContext), **listagem de dados** e **simulações de alteração no banco** (adicionar/remover coluna) com Oracle.  
> 🔐 **Atenção**: nunca publique sua *connection string* real no GitHub. Use `appsettings.json`, *user secrets* ou variáveis de ambiente.  
<br>


---

## 🇧🇷 Português
### 1) Visão geral  
Projeto de demonstração **Database-First** com **Entity Framework Core** e **Oracle**. O modelo é gerado a partir do banco via *scaffold*.  
<br>

### 2) Requisitos  
- **.NET 8 SDK**  
- **Visual Studio 2022** ou **VS Code**  
- Acesso a um banco **Oracle** (ex.: `oracle.xxxx.com.br:1521/ORCL`)  
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
- `Oracle.EntityFrameworkCore` — Provider Oracle (traduz LINQ ↔ SQL Oracle)  
<br>

### 5) Scaffold (engenharia reversa)  
**Package Manager Console (Visual Studio):**
    
    Scaffold-DbContext `
      "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=oracle.fiap.com.br:1521/ORCL;" `
      Oracle.EntityFrameworkCore `
      -OutputDir Model `
      -ContextDir DBContext `
      -Context AppDbContext `
      -DataAnnotations `
      -UseDatabaseNames `
      -Tables TB_CLIENTE,USUARIO `
      -Force

**CLI (.NET):**
    
    dotnet ef dbcontext scaffold \
      "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=oracle.fiap.com.br:1521/ORCL;" \
      Oracle.EntityFrameworkCore \
      --output-dir Model \
      --context-dir DBContext \
      --context AppDbContext \
      --data-annotations \
      --use-database-names \
      --table TB_CLIENTE --table USUARIO \
      --force

> ⚠️ O aviso amarelo sobre *connection string no código* é apenas recomendação de segurança. Em produção, use `appsettings.json` ou variáveis de ambiente.  
<br>

### 6) Conferir classes geradas  
Abra `Model/TB_CLIENTE.cs` e `Model/USUARIO.cs` e observe:  
- `[Table]` — mapeia a tabela  
- `[Key]` — chave primária  
- `[Column]` — nome/tipo de coluna  
<br>

### 7) Usar o `AppDbContext` no `Program.cs`  
    using EFCoreDataBaseFirst.DBContext;

    using (var db = new AppDbContext())
    {
        var clientes = db.TB_CLIENTEs.ToList();

        foreach (var c in clientes)
            Console.WriteLine($"{c.ID_CLIENTE}: {c.NOME} {c.SOBRENOME}");
    }

> ℹ️ O nome `TB_CLIENTEs` no `DbSet` é pluralizado pelo scaffold (coleção).  
<br>

### 8) Simular alteração no DB (adicionar coluna)  
**SQL (Oracle):**
    
    ALTER TABLE TB_CLIENTE ADD (EMAIL VARCHAR2(150 CHAR));

**Refaça o scaffold** (mesmos comandos da seção 5).  
Após isso, a entidade `TB_CLIENTE` terá a propriedade `EMAIL`.  
<br>

### 9) Simular remoção de coluna  
**SQL (Oracle):**
    
    ALTER TABLE TB_CLIENTE DROP COLUMN EMAIL;

**Refaça o scaffold** (mesmos comandos da seção 5).  
O modelo volta a compilar **sem** `EMAIL`.  
<br>

### 10) Boas práticas  
- **Não edite** diretamente as classes geradas; use **`partial class`** em arquivos separados.  
- Se renomear `DbSet` (ex.: `Clientes` em vez de `TB_CLIENTEs`), o scaffold pode recriar o nome original — rode para uma pasta temporária e faça *diff* se precisar.  
- **Segredos**: nunca comite usuário/senha/CS.  
<br>

---

## 🇺🇸 English
### 1) Overview  
Demo project for **Database-First** using **Entity Framework Core** with **Oracle**. The model is generated from the database via scaffold.  
<br>

### 2) Requirements  
- **.NET 8 SDK**  
- **Visual Studio 2022** or **VS Code**  
- Access to an **Oracle** database (e.g., `oracle.xxxx.com.br:1521/ORCL`)  
<br>

### 3) Create the project  
    dotnet new console -n EFCoreDataBaseFirst
    cd EFCoreDataBaseFirst

> 💡 Keep the `Hello World` in `Program.cs` so the project builds.  
<br>

### 4) NuGet packages  
    dotnet add package Microsoft.EntityFrameworkCore --version 8.*
    dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.*
    dotnet add package Oracle.EntityFrameworkCore --version 8.21.121

- `Microsoft.EntityFrameworkCore` — EF Core base  
- `Microsoft.EntityFrameworkCore.Tools` — tooling (e.g., `Scaffold-DbContext`)  
- `Oracle.EntityFrameworkCore` — Oracle provider  
<br>

### 5) Scaffold (reverse engineering)  
**Package Manager Console (Visual Studio):**
    
    Scaffold-DbContext `
      "User Id=YOUR_USER;Password=YOUR_PASS;Data Source=oracle.fiap.com.br:1521/ORCL;" `
      Oracle.EntityFrameworkCore `
      -OutputDir Model `
      -ContextDir DBContext `
      -Context AppDbContext `
      -DataAnnotations `
      -UseDatabaseNames `
      -Tables TB_CLIENTE,USUARIO `
      -Force

**.NET CLI:**
    
    dotnet ef dbcontext scaffold \
      "User Id=YOUR_USER;Password=YOUR_PASS;Data Source=oracle.fiap.com.br:1521/ORCL;" \
      Oracle.EntityFrameworkCore \
      --output-dir Model \
      --context-dir DBContext \
      --context AppDbContext \
      --data-annotations \
      --use-database-names \
      --table TB_CLIENTE --table USUARIO \
      --force

> ⚠️ Yellow warning about *connection string in code* is a security recommendation. In production, use `appsettings.json` or environment variables.  
<br>

### 6) Inspect generated classes  
Open `Model/TB_CLIENTE.cs` and `Model/USUARIO.cs`:  
- `[Table]`, `[Key]`, `[Column]` attributes  
<br>

### 7) Use `AppDbContext` in `Program.cs`  
    using EFCoreDataBaseFirst.DBContext;

    using (var db = new AppDbContext())
    {
        var clientes = db.TB_CLIENTEs.ToList();

        foreach (var c in clientes)
            Console.WriteLine($"{c.ID_CLIENTE}: {c.NOME} {c.SOBRENOME}");
    }

> ℹ️ `TB_CLIENTEs` is the pluralized `DbSet` name generated by the scaffold.  
<br>

### 8) Simulate DB change (add column)  
**SQL (Oracle):**
    
    ALTER TABLE TB_CLIENTE ADD (EMAIL VARCHAR2(150 CHAR));

**Re-scaffold** (same commands as section 5) to include `EMAIL`.  
<br>

### 9) Simulate column removal  
**SQL (Oracle):**
    
    ALTER TABLE TB_CLIENTE DROP COLUMN EMAIL;

**Re-scaffold** (same commands as section 5).  
<br>

### 10) Best practices  
- Use **`partial class`** for custom logic; avoid editing generated files.  
- If you rename `DbSet`s, the scaffold can recreate original names — scaffold to a temp folder and *diff* if needed.  
- Keep secrets out of source control.  
<br>

---

## 🇪🇸 Español
### 1) Descripción  
Proyecto de demostración **Database-First** con **Entity Framework Core** y **Oracle**. El modelo se genera desde la base de datos mediante *scaffold*.  
<br>

### 2) Requisitos  
- **.NET 8 SDK**  
- **Visual Studio 2022** o **VS Code**  
- Acceso a una base **Oracle** (ej.: `oracle.xxx.com.br:1521/ORCL`)  
<br>

### 3) Crear el proyecto  
    dotnet new console -n EFCoreDataBaseFirst
    cd EFCoreDataBaseFirst

> 💡 Mantén el `Hello World` en `Program.cs` para asegurar la compilación.  
<br>

### 4) Paquetes NuGet  
    dotnet add package Microsoft.EntityFrameworkCore --version 8.*
    dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.*
    dotnet add package Oracle.EntityFrameworkCore --version 8.21.121

- `Microsoft.EntityFrameworkCore` — Base de EF Core  
- `Microsoft.EntityFrameworkCore.Tools` — Herramientas (ej.: `Scaffold-DbContext`)  
- `Oracle.EntityFrameworkCore` — Proveedor Oracle  
<br>

### 5) Scaffold (ingeniería inversa)  
**Package Manager Console (Visual Studio):**
    
    Scaffold-DbContext `
      "User Id=TU_USUARIO;Password=TU_CLAVE;Data Source=oracle.fiap.com.br:1521/ORCL;" `
      Oracle.EntityFrameworkCore `
      -OutputDir Model `
      -ContextDir DBContext `
      -Context AppDbContext `
      -DataAnnotations `
      -UseDatabaseNames `
      -Tables TB_CLIENTE,USUARIO `
      -Force

**CLI de .NET:**
    
    dotnet ef dbcontext scaffold \
      "User Id=TU_USUARIO;Password=TU_CLAVE;Data Source=oracle.fiap.com.br:1521/ORCL;" \
      Oracle.EntityFrameworkCore \
      --output-dir Model \
      --context-dir DBContext \
      --context AppDbContext \
      --data-annotations \
      --use-database-names \
      --table TB_CLIENTE --table USUARIO \
      --force

> ⚠️ La advertencia sobre *connection string en el código* es una recomendación de seguridad. En producción, usa `appsettings.json` o variables de entorno.  
<br>

### 6) Revisar clases generadas  
Abre `Model/TB_CLIENTE.cs` y `Model/USUARIO.cs` y observa `[Table]`, `[Key]`, `[Column]`.  
<br>

### 7) Usar `AppDbContext` en `Program.cs`  
    using EFCoreDataBaseFirst.DBContext;

    using (var db = new AppDbContext())
    {
        var clientes = db.TB_CLIENTEs.ToList();

        foreach (var c in clientes)
            Console.WriteLine($"{c.ID_CLIENTE}: {c.NOME} {c.SOBRENOME}");
    }

> ℹ️ `TB_CLIENTEs` es el nombre pluralizado del `DbSet` generado por el scaffold.  
<br>

### 8) Simular cambio en la BD (agregar columna)  
**SQL (Oracle):**
    
    ALTER TABLE TB_CLIENTE ADD (EMAIL VARCHAR2(150 CHAR));

**Vuelve a ejecutar el scaffold** (mismos comandos de la sección 5) para incluir `EMAIL`.  
<br>

### 9) Simular eliminación de columna  
**SQL (Oracle):**
    
    ALTER TABLE TB_CLIENTE DROP COLUMN EMAIL;

**Vuelve a ejecutar el scaffold** (mismos comandos de la sección 5).  
<br>

### 10) Buenas prácticas  
- Usa **`partial class`** para personalizaciones; evita editar archivos generados.  
- Si renombras `DbSet`s, el scaffold puede recrear los nombres originales — genera en una carpeta temporal y compara.  
- No publiques secretos en el repositorio.  
<br>
