﻿using Microsoft.AspNetCore.Mvc;
using MvcStartAppMy.Models.Db;
using System.Threading.Tasks;

namespace MvcStartAppMy.Controllers
{
    public class UsersController: Controller
    {
        private readonly IBlogRepository _blogRepository;

        public UsersController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _blogRepository.GetUsers();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _blogRepository.AddUser(newUser);
            return View(newUser);
        }
    }
}
