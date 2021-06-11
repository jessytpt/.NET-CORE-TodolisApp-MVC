﻿using Microsoft.AspNetCore.Mvc;
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

        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Tarea> listaTareas = _context.Tareas;
            return View(listaTareas);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http Post Create
        [HttpPost]
        public IActionResult Create(Tarea tarea)
        {
            if (ModelState.IsValid) {
                tarea.EstadoTarea = false;
                _context.Tareas.Add(tarea);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
