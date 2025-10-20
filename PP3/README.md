# PP3 — Minimal API (ASP.NET Core, .NET 8)

**Nombre:** Jazmin Pamela Montenegro Baltodano  
**Carné:** FI23032284

## Comandos
```bash
dotnet new sln -n PP3
dotnet new web -n MinimalApi -f net8.0
dotnet sln PP3.sln add MinimalApi/MinimalApi.csproj
cd MinimalApi
dotnet add package Swashbuckle.AspNetCore
dotnet run
```

## Prompts

https://chatgpt.com/share/68f5c623-a210-8011-b09a-7234424abc69

## Preguntas

1) **¿Es posible enviar valores en el Body (por ejemplo, en el Form) del Request de tipo GET?**

No, no se pueden enviar valores en el **Body** de una solicitud **GET**, porque este método no está hecho para eso.  
El protocolo **HTTP** no define cómo manejar un cuerpo en este tipo de peticiones, así que hacerlo puede generar errores o problemas con el caché y algunos servidores.  
Si se necesita enviar información más compleja, lo correcto es usar el método **POST** o enviar los datos como parámetros en la **URL** del **GET**.  


---

2) **¿Qué ventajas y desventajas observa con el Minimal API si se compara con la opción de utilizar Controllers?**

Las **Minimal APIs** son una forma más sencilla y ligera de crear servicios, ya que usan menos código y permiten desarrollar más rápido.  
Sin embargo, al ser tan simples, pueden tener menos estructura y a veces se necesita escribir más código manual cuando el proyecto se vuelve más complejo.  

Por otro lado, las **APIs con controladores** son más organizadas y prácticas para proyectos grandes, porque ofrecen una estructura más clara y cuentan con mejor soporte para cosas como la vinculación de modelos y el manejo de errores de forma automática.  

