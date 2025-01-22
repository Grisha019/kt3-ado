using Microsoft.AspNetCore.Mvc;

namespace kt3_ado.Controllers
{
    public class TestController : Controller
    {
        public async Task Text()
        {
            // Устанавливаем ContentType
            Response.ContentType = "text/plain";

            // Пишем строку в ответ
            await Response.WriteAsync("Hello, world!");
        }
        public async Task Html()
        {
            Response.ContentType = "text/html";
            string htmlContent = "<html><head><title>HTML Response</title></head><body><h1>Заголовок</h1><p>Это абзац текста.</p></body></html>";
            await Response.WriteAsync(htmlContent);
        }

        // Действие Json: возвращает JSON-ответ
        public async Task Json()
        {
            Response.ContentType = "application/json";
            var jsonObject = new { Name = "Answer", Age = 25 };
            await Response.WriteAsJsonAsync(jsonObject);
        }

        // Действие File: возвращает файл test.txt
        public async Task File()
        {
            Response.ContentType = "text/plain";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "test.txt");
            if (!System.IO.File.Exists(filePath))
            {
                await System.IO.File.WriteAllTextAsync(filePath, "This is a test file");
            }
            await Response.SendFileAsync(filePath);
        }

        // Действие Status: возвращает статус 404
        public async Task Status()
        {
            Response.StatusCode = 404;
            Response.ContentType = "text/plain";
            await Response.WriteAsync("Error 404: Not Found");
        }

        // Действие Cookie: устанавливает куки
        public async Task Cookie()
        {
            Response.Cookies.Append("user", "Answer");
            Response.ContentType = "text/plain";
            await Response.WriteAsync("Cookie has been set: user=Answer");
        }

    }
}
