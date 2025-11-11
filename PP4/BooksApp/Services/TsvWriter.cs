using BooksApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Services
{
    public static class TsvWriter
    {
        public static void WriteFiles(BooksContext context)
        {
            Console.WriteLine("La base de datos se está leyendo para crear los archivos TSV...");
            var query = context.Titles
                .Include(t => t.Author)
                .Include(t => t.TitlesTags).ThenInclude(tt => tt.Tag)
                .ToList()
                .OrderByDescending(t => t.Author.AuthorName)
                .ThenByDescending(t => t.TitleName);

            var grouped = query.GroupBy(t => t.Author.AuthorName[0].ToString().ToUpper());

            foreach (var group in grouped)
            {
                string filePath = Path.Combine("data", $"{group.Key}.tsv");
                using var writer = new StreamWriter(filePath);
                writer.WriteLine("AuthorName\tTitleName\tTagName");

                foreach (var title in group)
                {
                    foreach (var tag in title.TitlesTags.Select(tt => tt.Tag))
                    {
                        writer.WriteLine($"{title.Author.AuthorName}\t{title.TitleName}\t{tag.TagName}");
                    }
                }
            }

            Console.WriteLine("Procesando... Listo.");
        }
    }
}
