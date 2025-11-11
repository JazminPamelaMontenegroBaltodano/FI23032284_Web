# PP4 — Entity Framework Code First

**Nombre:** Jazmín Pamela Montenegro Baltodano  
**Carné:** FI23032284

## Comandos
```bash
dotnet new sln -n BooksSolution
dotnet new console -n BooksApp --framework net8.0
dotnet sln BooksSolution.sln add BooksApp/BooksApp.csproj
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

## Prompts

**https://learn.microsoft.com/en-us/ef/core/providers/sqlite/?tabs=dotnet-core-cli**
**https://learn.microsoft.com/en-us/ef/core/**
**ChatGPT (OpenAI), Gemini y Copilot para depurar código y adaptar DataLoader y TSV Writer.**

## Preguntas

1) **¿Cómo cree que resultaría el uso de la estrategia de Code First para crear y actualizar una base de datos de tipo NoSQL (como por ejemplo MongoDB)? ¿Y con Database First? ¿Cree que habría complicaciones con las Foreign Keys?**

Pienso que el enfoque Code First podría funcionar bien con una base de datos NoSQL como MongoDB, porque permite definir el modelo directamente desde el código y adaptarlo fácilmente a los esquemas flexibles que usa este tipo de bases.
Por otro lado, el enfoque Database First no se ajusta tanto, ya que está pensado para bases relacionales con estructuras fijas y no para documentos dinámicos.
En cuanto a las Foreign Keys, en las bases NoSQL no existen como tal, pero se pueden representar mediante referencias o documentos anidados que simulan ese tipo de relaciones entre datos. 


---

2) **¿Cuál carácter, además de la coma (,) y el Tab (\t), se podría usar para separar valores en un archivo de texto con el objetivo de ser interpretado como una tabla (matriz)? ¿Qué extensión le pondría y por qué? Por ejemplo: Pipe (|) con extensión .pipe.**

Se podría usar el Pipe (|) porque es un símbolo que casi nunca aparece dentro de los textos y facilita la lectura de los datos. Además, podría guardarse con la extensión .pipe para indicar que el archivo usa ese carácter como separador.
