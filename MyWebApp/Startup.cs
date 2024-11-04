using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyWebApp
{
    public class Startup
    {
        // Этот метод вызывается при запуске приложения для добавления сервисов в контейнер DI.
        public void ConfigureServices(IServiceCollection services)
        {
            // Добавление поддержки MVC
            services.AddControllersWithViews();
        }

        // Этот метод вызывается для конфигурации HTTP-запросов.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Проверка окружения (разработка или продакшен)
            if (env.IsDevelopment())
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
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); // Определение маршрута по умолчанию
            });
        }
    }
}