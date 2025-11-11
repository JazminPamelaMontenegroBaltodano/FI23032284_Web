using BooksApp.Data;
using BooksApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Services
{
    public static class DataLoader
    {
        public static void LoadCsvIfEmpty(BooksContext context)
        {
            if (context.Authors.Any())
            {
                Console.WriteLine("La base de datos ya contiene información.");
                return;
            }

            string dataPath = Path.Combine(Directory.GetCurrentDirectory(), "data", "books.csv");

            if (!File.Exists(dataPath))
            {
                Console.WriteLine("No se encontró el archivo books.csv en la carpeta data.");
                return;
            }

            Console.WriteLine("La base de datos está vacía, cargando datos desde el CSV...");
            using var reader = new StreamReader(dataPath);
            string? line;
            bool first = true;
            int total = 0;

            while ((line = reader.ReadLine()) != null)
            {
                // Saltar encabezado
                if (first)
                {
                    first = false;
                    continue;
                }

                // Saltar líneas vacías
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Parsear la línea respetando comillas
                string[] parts = SplitCsvLine(line);

                // Validar formato correcto (3 columnas)
                if (parts.Length < 3)
                {
                    Console.WriteLine($"Línea ignorada (formato incorrecto): {line}");
                    continue;
                }

                string authorName = parts[0].Trim();
                string titleName = parts[1].Trim();
                string[] tags = parts[2].Split('|', StringSplitOptions.TrimEntries);

                // Buscar o crear autor
                var author = context.Authors.FirstOrDefault(a => a.AuthorName == authorName);
                if (author == null)
                {
                    author = new Author { AuthorName = authorName };
                    context.Authors.Add(author);
                }

                // Crear título
                var title = new Title { TitleName = titleName, Author = author };
                context.Titles.Add(title);

                // Crear etiquetas
                foreach (var tagName in tags)
                {
                    if (string.IsNullOrWhiteSpace(tagName))
                        continue;

                    var tag = context.Tags.FirstOrDefault(t => t.TagName == tagName);
                    if (tag == null)
                    {
                        tag = new Tag { TagName = tagName };
                        context.Tags.Add(tag);
                    }

                    context.TitlesTags.Add(new TitleTag { Title = title, Tag = tag });
                }

                total++;
            }

            context.SaveChanges();
            Console.WriteLine($"Procesando... Listo. {total} registros insertados.");
        }

        // Función auxiliar para dividir respetando comillas dobles
        private static string[] SplitCsvLine(string line)
        {
            var parts = new List<string>();
            bool inQuotes = false;
            string current = "";

            foreach (char c in line)
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (c == ',' && !inQuotes)
                {
                    parts.Add(current);
                    current = "";
                }
                else
                {
                    current += c;
                }
            }

            parts.Add(current);
            return parts.ToArray();
        }
    }
}
