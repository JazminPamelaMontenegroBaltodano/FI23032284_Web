﻿using BooksApp.Data;
using BooksApp.Services;

using var context = new BooksContext();
context.Database.EnsureCreated();

if (!context.Authors.Any())
{
    DataLoader.LoadCsvIfEmpty(context);
}
else
{
    TsvWriter.WriteFiles(context);
}
