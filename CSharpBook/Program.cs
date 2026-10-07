var builder = WebApplication.CreateBuilder(args);

// Подключаем поддержку Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles(); // Чтобы работал CSS
app.UseRouting();

// Маршрутизация на Razor Pages
app.MapRazorPages();

app.Run();
