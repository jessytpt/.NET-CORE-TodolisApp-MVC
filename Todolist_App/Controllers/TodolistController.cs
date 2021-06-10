using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todolist_App.Models;

namespace Todolist_App.Controllers
{
    public class TodolistController : Controller
    {
        private readonly TodolistContext _context; //contexto de la base de datos, debe estar en modesl con la terminación context

        public TodolistController(TodolistContext context)
        {
            _context = context;
        }

        public string Index()
        {
            return "test";
        }
    }
}
