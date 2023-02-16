using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using MvcStartAppMy.Models.Db;
using static System.Net.WebRequestMethods;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MvcStartAppMy.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _repo;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IRequestRepository repo)
        {
            _next = next;
            _repo = repo;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            string url = "http://" + context.Request.Host.Value + context.Request.Path;

            var newReqest = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = url
            };

            await _repo.AddRequest(newReqest);
                       
            //// Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }     
    }
}
