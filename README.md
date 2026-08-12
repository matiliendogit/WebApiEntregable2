# Entregable Práctico N° 2 - .NET Web API & SQL Server

RESTful Web API desarrollada en .NET con arquitectura **Database-First**, utilizando **Entity Framework Core** y **SQL Server Express** como motor de almacenamiento de datos. El proyecto expone endpoints documentados con **OpenAPI / Swagger** para la gestión de tareas (*TaskManager*).

---

## 🛠️ Tecnologías y Dependencias

* **Framework:** .NET 8.0 / .NET Web API
* **Base de Datos:** SQL Server Express (`TaskManagerDb`)
* **ORM:** Entity Framework Core
* **Documentación API:** Swagger UI / OpenAPI (Swashbuckle)

### Paquetes NuGet (Dependencies)
* `Microsoft.EntityFrameworkCore.SqlServer` — Proveedor de base de datos SQL Server para EF Core.
* `Microsoft.EntityFrameworkCore.Tools` — Herramientas para la ejecución de comandos en la Consola del Administrador de Paquetes (PMC).
* `Microsoft.EntityFrameworkCore.Design` — Componente de diseño para ingeniería inversa (Scaffolding).
* `Swashbuckle.AspNetCore` — Soporte para generación de interfaz Swagger/OpenAPI.

---

## 💡 Consideración de Diseño: Renombrado de Entidad (`ETask`)

> **⚠️ NOTA IMPORTANTE DE ARQUITECTURA:**
> 
> En el entorno de ejecución de .NET, el tipo nativo `System.Threading.Tasks.Task` se utiliza masivamente para el manejo de programación asíncrona (`async` / `await`). 
> 
> Para evitar colisiones de nombres, ambigüedades en la sintaxis y necesidad de utilizar *fully qualified namespaces* a lo largo del proyecto, la entidad mapeada a la tabla `Tasks` fue renombrada a **`ETask`** (Entity Task) y su colección en el `DbContext` a **`ETasks`**.

---

## 🗄️ Estructura de la Base de Datos (`TaskManagerDb`)

La base de datos utiliza el esquema por defecto `dbo` y está optimizada con índices no agrupados para consultas eficientes sobre el estado de las tareas.

### Tabla: `dbo.Tasks`

| Campo | Tipo de Dato (SQL) | Tipo (C# / EF) | Nulo | Descripción / Constraints |
| :--- | :--- | :--- | :---: | :--- |
| **`Id`** | `INT` | `int` | ❌ | **Primary Key** (Asignado manualmente / No-Identity). |
| **`Title`** | `NVARCHAR(200)` | `string` | ❌ | Título de la tarea. Validado mediante `CHECK` (no vacío). |
| **`Description`**| `NVARCHAR(MAX)` | `string?` | ✅ | Detalle o descripción extendida de la tarea. |
| **`IsCompleted`** | `BIT` | `bool` | ❌ | Estado de la tarea (`0` = Pendiente, `1` = Completada). `DEFAULT 0`. |
| **`CreatedAtUtc`**| `DATETIME2(7)` | `DateTime` | ❌ | Fecha de creación en UTC. `DEFAULT SYSUTCDATETIME()`. |
| **`UpdatedAtUtc`**| `DATETIME2(7)` | `DateTime?` | ✅ | Fecha de última modificación en UTC. |

### Índices Registrados
* `IX_Tasks_IsCompleted` (**Non-Clustered**): Creado sobre la columna `IsCompleted` con campos incluidos (`Title`, `CreatedAtUtc`) para optimizar el rendimiento de filtrados frecuentes (`.Where(t => !t.IsCompleted)`).

---

## 🚀 Configuración y Puesta en Marcha

### 1. Preparación de la Base de Datos
Ejecutar los scripts de creación de tabla e inserción de datos iniciales en **SQL Server Management Studio (SSMS)** conectándose a la instancia local de SQL Express (`.\SQLEXPRESS01`).

### 2. Cadena de Conexión (`appsettings.json`)
Asegurarse de que el archivo `appsettings.json` contenga la cadena de conexión apuntando a la instancia local:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS01;Database=TaskManagerDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}