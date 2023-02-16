using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcStartAppMy.Models;
using MvcStartAppMy.Models.Db;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MvcStartAppMy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // ссылка на репозиторий
        private readonly IBlogRepository _blogRepository;
        private readonly IRequestRepository _requestRepository;

        public HomeController(ILogger<HomeController> logger, IBlogRepository blogRepository, IRequestRepository requestRepository)
        {
            _logger = logger;
            _blogRepository = blogRepository;
            _requestRepository = requestRepository;
        }
        
        // сделаем метод асинхронным
        public async Task  <IActionResult> Index()
        {
            // добавим создание нового пользователя
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Andrey",
                LastName = "Petrov",
                JoinDate = DateTime.Now
            };

            // добавим в базу
            await _blogRepository.AddUser(newUser);

            // Выведем результат
            Console.WriteLine($"User with id {newUser.Id}, named {newUser.FirstName} was successfully added on {newUser.JoinDate}");
            return View();
        }

        //public async Task<IActionResult> Authors()
        //{ 
        //    var authors = await _blogRepository.GetUsers();
        //    Console.WriteLine("See all blog authors:");
        //    //foreach (var author in authors)
        //    //    Console.WriteLine($"Author with id {author.Id}, named {author.FirstName}, joined {author.JoinDate}");

        //    return View(authors);
        //}

        public async Task<IActionResult> Logs()
        {
            var logs = await _requestRepository.GetRequests();
            return View(logs);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
