using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Добавление служб в контейнер зависимостей
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Настройка промежуточного ПО
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Страница ошибок для разработки
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Обработчик ошибок для продакшена
    app.UseHsts(); // Использование HSTS
}

app.UseHttpsRedirection(); // Перенаправление на HTTPS
app.UseStaticFiles(); // Поддержка статических файлов

app.UseRouting(); // Поддержка маршрутизации
app.UseAuthorization(); // Поддержка авторизации

// Настройка конечных точек маршрутов
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Определение маршрута по умолчанию

app.Run(); // Запуск приложения