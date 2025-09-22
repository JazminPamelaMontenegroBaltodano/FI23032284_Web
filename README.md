# Práctica PP1 – Suma de números naturales en C#

**Nombre:** Jazmin Pamela Montenegro Baltodano  
**Carné:** FI23032284  

﻿# Comandos utilizados: 

# Crear solución y proyecto
dotnet new sln -n PP1
dotnet new console -n SumaApp
dotnet sln PP1.sln add SumaApp/SumaApp.csproj

# Compilar y ejecutar
dotnet build
dotnet run --project SumaApp

# Inicializar repositorio Git
git init
git add .
git commit -m "Subir práctica PP1 con solución y proyecto .NET"

# Crear rama main y subir cambios
git branch -M main
git push -u origin main

# Sincronizar con remoto antes de subir
git pull origin main --rebase
git push origin main

# Crear carpeta PP1 y reorganizar proyecto
mkdir PP1
git mv SumaApp PP1/
git mv PP1.sln PP1/
git mv .gitignore PP1/

git commit -m "Reorganizar proyecto dentro de carpeta PP1"
git push origin main

﻿# Páginas web donde halló posibles soluciones a problemas encontrados o Snippets de código.

# Prompts (consultas y respuestas) de los chatbots de IA (Copilot, Gemini, ChatGPT, etc.) que haya utilizado.

**Prompt 1:**  
*"Explícame por qué la fórmula de Gauss (n*(n+1)/2) y la suma iterativa dan resultados diferentes cuando se usan números grandes en C#."*  

**Respuesta resumida:**  
El tipo `int` en C# solo llega hasta 2,147,483,647. Con la fórmula los cálculos crecen más rápido (n²) y ocurre overflow antes; con la iterativa tarda más porque crece paso a paso.  

**Prompt 2:**  
*"¿Qué pasaría si implemento el método de suma usando recursión (SumRec) en lugar de iteración?"*  

**Respuesta resumida:**  
El método recursivo funciona igual que el iterativo para números pequeños, pero cuando `n` es grande provoca **StackOverflowException** porque la pila de llamadas se llena antes de que ocurra el overflow del entero.  

**Prompt 3:**  
*"Necesito un ejemplo completo en C# de una aplicación de consola que incluya dos métodos: uno iterativo (`SumIte`) y otro con fórmula (`SumFor`), y que además los ejecute en el `Main` mostrando los resultados para un valor de prueba de `n = 10`."*  

**Respuesta resumida:**  
El chatbot me dio un ejemplo completo con `Program.cs` listo para ejecutar:

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        int n = 10;

        int sumaIterativa = SumIte(n);
        int sumaFormula = SumFor(n);

        Console.WriteLine($"Suma iterativa de 1 hasta {n}: {sumaIterativa}");
        Console.WriteLine($"Suma con fórmula de 1 hasta {n}: {sumaFormula}");
    }

    static int SumIte(int n)
    {
        int result = 0;
        for (int i = 1; i <= n; i++)
        {
            result += i;
        }
        return result;
    }

    static int SumFor(int n)
    {
        return n * (n + 1) / 2;
    }
}


# La respuesta a la siguientes preguntas:

### ¿Por qué todos los valores resultantes tanto de `n` como de `sum` difieren entre métodos (fórmula e implementación iterativa) y estrategias (ascendente y descendente)?

Los resultados son diferentes porque en C# el tipo `int` tiene un límite máximo, y cuando se pasa de ese valor ocurre un **overflow** y los números empiezan a volverse negativos.

---

### ¿Qué cree que sucedería si se utilizan las mismas estrategias (ascendente y descendente) pero con el método recursivo de suma (SumRec)?

El método recursivo funciona igual que la suma iterativa porque al final hace lo mismo: va sumando de 1 en 1.

