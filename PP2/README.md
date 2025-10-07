# PP2 — Calculadora Binaria (ASP.NET Core MVC, .NET 8)

**Nombre:** Jazmin Pamela Montenegro Baltodano  
**Carné:** FI23032284

## Comandos
```bash
dotnet new sln -n PP2
dotnet new mvc -n BinCalc -f net8.0
dotnet sln PP2.sln add BinCalc/BinCalc.csproj
cd BinCalc
dotnet restore
dotnet run
```

## Prompts

[ChatGPT Share Link](https://chatgpt.com/share/68e49e35-05cc-8011-85a8-cacfbda613c2)

## Preguntas

1) **¿Cuál es el número que resulta al multiplicar, si se introducen los valores máximos permitidos en a y b? Indíquelo en todas las bases.**

Valores máximos permitidos (8 bits):  
- a = `11111111` (255)  
- b = `11111111` (255)  

Cálculo:  
- Producto: `255 * 255 = 65025`  
- **Bin:** `1111111000000001`  
- **Oct:** `177001`  
- **Dec:** `65025`  
- **Hex:** `FE01`  

---

2) **¿Es posible hacer las operaciones en otra capa? ¿Cuál?**

Sí.  
La lógica puede moverse a una **capa de servicios** (por ejemplo, `Services/BinaryService.cs`) o a una **librería de clases separada** (proyecto de clase en la solución).  
El **controlador** invoca esa capa, manteniendo el modelo con validaciones y el controlador siguiendo el **principio de separación de responsabilidades**.
