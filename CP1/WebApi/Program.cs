using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var list = new List<object>();


app.MapGet("/", () => Results.Redirect("/swagger"));


app.MapPost("/", ([FromHeader(Name = "xml")] bool? xml) =>
{
    xml ??= false;

    if (xml == true)
    {
        var xmlSerializer = new XmlSerializer(typeof(List<object>));
        using var stringWriter = new StringWriter();
        xmlSerializer.Serialize(stringWriter, list);
        var xmlString = stringWriter.ToString();
        return Results.Content(xmlString, "application/xml", Encoding.UTF8);
    }

    return Results.Ok(list);
});


app.MapPut("/", ([FromForm] int quantity, [FromForm] string type) =>
{
    if (quantity <= 0)
        return Results.BadRequest(new { error = "'quantity' must be higher than zero" });

    if (type != "int" && type != "float")
        return Results.BadRequest(new { error = "'type' must be either 'int' or 'float'" });

    var random = new Random();

    if (type == "int")
    {
        for (int i = 0; i < quantity; i++)
            list.Add(random.Next());
    }
    else // float, chatgpt
    {
        for (int i = 0; i < quantity; i++)
            list.Add(random.NextSingle());
    }

    return Results.Ok(list);
}).DisableAntiforgery();


app.MapDelete("/", ([FromForm] int quantity) =>
{
    if (quantity <= 0)
        return Results.BadRequest(new { error = "'quantity' must be higher than zero" });

    if (quantity > list.Count)
        return Results.BadRequest(new { error = "Not enough elements in the list to delete" });

    list.RemoveRange(0, quantity);
    return Results.Ok(list);
}).DisableAntiforgery();


app.MapPatch("/", () =>
{
    list.Clear();
    return Results.Ok(new { message = "List cleared successfully" });
});

app.Run();
